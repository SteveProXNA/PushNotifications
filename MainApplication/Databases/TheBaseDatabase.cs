using System;
using System.Collections.Generic;
using System.Data;

namespace MainApplication.Databases
{
	public abstract class TheBaseDatabase
	{
		private readonly IDatabaseFactory databaseFactory;

		protected TheBaseDatabase(IDatabaseFactory databaseFactory)
		{
			this.databaseFactory = databaseFactory;
		}

		protected void ExecuteQueryWithDataReader(string query, IDbDataParameter[] dbParams, Action<IDataReader> action)
		{
			using (IDbConnection connection = GetDbConnection())
			{
				connection.Open();
				using (IDbCommand command = GetDbCommand(query, connection))
				{
					if (null != dbParams)
					{
						AddParameters(command, dbParams);
					}

					using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
					{
						action(reader);
					}
				}
			}
		}

		protected void ExecuteQueryWithDataScalar(string query, IDbDataParameter[] dbParams, Action<object> action)
		{
			using (IDbConnection connection = GetDbConnection())
			{
				connection.Open();
				using (IDbCommand command = GetDbCommand(query, connection))
				{
					if (null != dbParams)
					{
						AddParameters(command, dbParams);
					}

					var obj = command.ExecuteScalar();
					action(obj);
				}
			}
		}

		protected void ExecuteSprocWithDataReader(string sprocName, IDbDataParameter[] dbParams, Action<IDataReader> action)
		{
			using (var connection = GetDbConnection())
			{
				connection.Open();
				using (var command = GetDbProcedureCommand(sprocName, connection))
				{
					if (null != dbParams)
					{
						AddParameters(command, dbParams);
					}

					using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
					{
						action(reader);
					}
				}
			}
		}

		protected int ExecuteAdhocNonQuery(string sql)
		{
			using (var connection = GetDbConnection())
			{
				connection.Open();
				using (var command = GetDbAdhocSqlCommand(sql, connection))
				{
					return command.ExecuteNonQuery();
				}
			}
		}

		protected int ExecuteSprocNonQuery(string sprocName, IDbDataParameter[] dbParams)
		{
			using (var connection = GetDbConnection())
			{
				connection.Open();
				using (var command = GetDbProcedureCommand(sprocName, connection))
				{
					if (dbParams != null)
					{
						AddParameters(command, dbParams);
					}

					return command.ExecuteNonQuery();
				}
			}
		}

		protected IDbDataParameter[] GetParameters(string[] names, object[] values)
		{
			var length = names.Length;
			var parameters = new IDbDataParameter[length];

			for (var index = 0; index < length; index++)
			{
				string name = names[index];
				if (!name.StartsWith("@"))
				{
					name = "@" + name;
				}

				var value = values[index];

				var parameter = databaseFactory.GetParameter(name, value);
				parameters[index] = parameter;
			}

			return parameters;
		}

		protected T TryParseFromReader<T>(IDataReader reader, string key)
		{
			return reader.IsDBNull(reader.GetOrdinal(key)) ? default(T) : (T)reader[key];
		}

		private IDbCommand GetDbAdhocSqlCommand(string cmdText, IDbConnection connection)
		{
			return GetDbCommandType(cmdText, connection, CommandType.Text);
		}
		private IDbCommand GetDbProcedureCommand(string cmdText, IDbConnection connection)
		{
			return GetDbCommandType(cmdText, connection, CommandType.StoredProcedure);
		}
		private IDbCommand GetDbCommandType(string cmdText, IDbConnection connection, CommandType commandType)
		{
			var command = GetDbCommand(cmdText, connection);
			command.CommandType = commandType;
			return command;
		}

		private IDbConnection GetDbConnection()
		{
			return databaseFactory.GetDbConnection();
		}
		private IDbCommand GetDbCommand(string cmdText, IDbConnection connection)
		{
			return databaseFactory.GetDbCommand(cmdText, connection);
		}
		private static void AddParameters(IDbCommand command, IEnumerable<IDbDataParameter> dbDataParameters)
		{
			if (null == dbDataParameters)
			{
				return;
			}

			foreach (var parameter in dbDataParameters)
			{
				command.Parameters.Add(parameter);
			}
		}

	}
}