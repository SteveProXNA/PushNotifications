using System.Data;
using MainApplication.Managers;
using MySql.Data.MySqlClient;

namespace MainApplication.Databases
{
	public class MySqlWorkDataFactory : IDatabaseFactory
	{
		private readonly IConfigManager configManager;

		public MySqlWorkDataFactory(IConfigManager configManager)
		{
			this.configManager = configManager;
		}

		public IDbConnection GetDbConnection()
		{
			return new MySqlConnection(configManager.ConnectionString);
		}

		public IDbCommand GetDbCommand(string cmdText, IDbConnection connection)
		{
			var mySqlConnection = connection as MySqlConnection;
			return new MySqlCommand(cmdText, mySqlConnection)
			{
				CommandTimeout = configManager.CommandTimeout
			};
		}

		public IDbDataParameter GetParameter(string name, object value)
		{
			return new MySqlParameter(name, value);
		}
	}
}