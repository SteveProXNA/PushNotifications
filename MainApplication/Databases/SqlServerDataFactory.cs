using System.Data;
using System.Data.SqlClient;
using MainApplication.Managers;

namespace MainApplication.Databases
{
	public class SqlServerDataFactory : IDatabaseFactory
	{
		private readonly IConfigManager configManager;

		public SqlServerDataFactory(IConfigManager configManager)
		{
			this.configManager = configManager;
		}

		public IDbConnection GetDbConnection()
		{
			return new SqlConnection(configManager.ConnectionString);
		}

		public IDbCommand GetDbCommand(string cmdText, IDbConnection connection)
		{
			var sqlConnection = connection as SqlConnection;
			return new SqlCommand(cmdText, sqlConnection)
			{
				CommandTimeout = configManager.CommandTimeout
			};
		}

		public IDbDataParameter GetParameter(string name, object value)
		{
			return new SqlParameter(name, value);
		}
	}
}