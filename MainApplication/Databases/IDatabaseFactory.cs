using System.Data;

namespace MainApplication.Databases
{
	public interface IDatabaseFactory
	{
		IDbConnection GetDbConnection();
		IDbCommand GetDbCommand(string text, IDbConnection connection);
		IDbDataParameter GetParameter(string name, object value);
	}
}