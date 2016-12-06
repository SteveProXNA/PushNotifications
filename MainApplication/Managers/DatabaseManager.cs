using System;
using System.Collections.Generic;
using System.Linq;
using MainApplication.Databases;
using MainApplication.Domain;

namespace MainApplication.Managers
{
	public interface IDatabaseManager
	{
		// SELECT statements.
		AMsgObject SelectPlayerNotifyAMsg(DateTime dateTime);
		IList<DataObject> SelectPlayerNotifyData(Int32 dataMessageId);
		IList<DataObject> FilterPlayerNotifyData(IList<DataObject> dataObjectList);
		Int32 CountPlayerNotifyData(Int32 dataMessageId);

		// DELETE statements.
		Int32 DeletePlayerNotifyAMsg(Int32 messageId);

		Int32 DeletePlayerNotifyData(Int32 dataMessageId);
		Int32 DeletePlayerNotifyData(Int32 dataMessageId, Int32 maxData, Int32 index);
		Int32 DeletePlayerNotifyData(Int32 dataId, Int32 dataMessageId, String dataAccountToken);
	}

	public class DatabaseManager : TheBaseDatabase, IDatabaseManager
	{
		public DatabaseManager(IDatabaseFactory databaseFactory) : base(databaseFactory)
		{
		}

		// SELECT statements.
		public AMsgObject SelectPlayerNotifyAMsg(DateTime dateTime)
		{
			String dateText = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
			String query =
				String.Format(
					"SELECT * FROM pending_player_notify_amsg WHERE '{0}' >= message_date ORDER BY message_id ASC LIMIT 1", dateText);

			AMsgObject aMsgObject = null;
			ExecuteQueryWithDataReader(query, null, reader =>
			{
				if (reader.Read())
				{
					var messageId = TryParseFromReader<Int32>(reader, "message_id");
					var messageText = TryParseFromReader<String>(reader, "message_text");
					var messageDate = TryParseFromReader<DateTime>(reader, "message_date");

					aMsgObject = new AMsgObject(messageId, messageText, messageDate);
				}
			});

			return aMsgObject;
		}
		public IList<DataObject> SelectPlayerNotifyData(Int32 dataMessageId)
		{
			String query = String.Format("SELECT * FROM pending_player_notify_data WHERE data_message_id = {0} ORDER BY data_id", dataMessageId);

			IList<DataObject> dataObjectList = new List<DataObject>();
			ExecuteQueryWithDataReader(query, null, reader =>
			{
				while (reader.Read())
				{
					var dataId = TryParseFromReader<Int32>(reader, "data_id");
					//var dataMessageId = TryParseFromReader<Int32>(reader, "data_message_id");
					var dataAccountToken = TryParseFromReader<String>(reader, "data_account_token");

					DataObject dataObject = new DataObject(dataId, dataMessageId, dataAccountToken);
					dataObjectList.Add(dataObject);
				}
			});

			return dataObjectList;
		}

		public IList<DataObject> FilterPlayerNotifyData(IList<DataObject> dataObjectList)
		{
			// http://stackoverflow.com/questions/1606679/remove-duplicates-in-the-list-using-linq
			return dataObjectList.GroupBy(x => x.DataAccountToken).Select(y => y.First()).ToList();
		}

		public Int32 CountPlayerNotifyData(Int32 dataMessageId)
		{
			String query = String.Format("SELECT COUNT(1) AS count FROM pending_player_notify_data WHERE data_message_id = {0}", dataMessageId);

			Int32 count = 0;
			ExecuteQueryWithDataScalar(query, null, obj => count = Convert.ToInt32(obj));

			return count;
		}

		// DELETE statements.
		public Int32 DeletePlayerNotifyAMsg(Int32 messageId)
		{
			String sql = String.Format("DELETE FROM pending_player_notify_amsg WHERE message_id = {0}", messageId);
			return ExecuteAdhocNonQuery(sql);
		}

		public Int32 DeletePlayerNotifyData(Int32 dataMessageId)
		{
			String sql = String.Format("DELETE FROM pending_player_notify_data WHERE data_message_id = {0}", dataMessageId);
			return ExecuteAdhocNonQuery(sql);
		}
		public Int32 DeletePlayerNotifyData(Int32 dataMessageId, Int32 maxData, Int32 index)
		{
			String sql =
				String.Format(
					"DELETE FROM pending_player_notify_data WHERE data_message_id = {0} AND data_id <= {1} AND data_id LIKE '%{2}'",
					dataMessageId, maxData, index);

			return ExecuteAdhocNonQuery(sql);
		}
		public Int32 DeletePlayerNotifyData(Int32 dataId, Int32 dataMessageId, String dataAccountToken)
		{
			String sql =
				String.Format(
					"DELETE FROM pending_player_notify_data WHERE data_id <> {0} AND data_message_id = {1} AND data_account_token = '{2}'",
					dataId, dataMessageId, dataAccountToken);

			return ExecuteAdhocNonQuery(sql);
		}

	}
}