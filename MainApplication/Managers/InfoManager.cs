using System;
using System.Collections.Generic;
using System.Linq;
using MainApplication.Domain;
using MainApplication.Static;

namespace MainApplication.Managers
{
	public interface IInfoManager
	{
		void Initialize();
		void Split(IList<DataObject> dataObjectList);
		void Token(IList<DataObject> dataObjectList);
		void UpdateMaxData(int index, int maxData);
		void UpdatePercent(int index, int maxData);
		void Delete();
		void SetMsgObject(AMsgObject msgObject);

		IList<DataObject> DataObjectList { get; }
		IList<DataObject>[] ItemObjectList { get; }
		IList<String> TokenStringList { get; }
		Int32[] MaxDataArray { get; }
		Int32[] TotalngArray { get; }
		Int32[] PercentArray { get; }
		Int32 MessageId { get; }
		String MessageText { get; }
	}

	public class InfoManager : IInfoManager
	{
		private readonly object maxDataLock = new object();
		private readonly object percentLock = new object();

		public void Initialize()
		{
			DataObjectList = new List<DataObject>();
			ItemObjectList = new IList<DataObject>[Constants.MAX_QUEUES];
			MaxDataArray = new Int32[Constants.MAX_QUEUES];
			TotalngArray = new Int32[Constants.MAX_QUEUES];
			PercentArray = new Int32[Constants.MAX_QUEUES];
		}

		public void Split(IList<DataObject> dataObjectList)
		{
			DataObjectList = dataObjectList;
			for (int index = 0; index < Constants.MAX_QUEUES; ++index)
			{
				ItemObjectList[index] = dataObjectList.Where(da => da.DataId % Constants.MAX_QUEUES == index).ToList();
				TotalngArray[index] = ItemObjectList[index].Count;
			}
		}

		public void Token(IList<DataObject> dataObjectList)
		{
			TokenStringList = dataObjectList.Select(da => da.DataAccountToken).ToList();
		}

		public void UpdateMaxData(int index, int maxData)
		{
			lock (maxDataLock)
			{
				MaxDataArray[index] = maxData;
			}
		}
		public void UpdatePercent(int index, int percent)
		{
			lock (percentLock)
			{
				PercentArray[index] = percent;
			}
		}

		public void Delete()
		{
			// If no messages sent then do not delete data.
			if (!WinForm.Manager.ConfigManager.SendMessage)
			{
				return;
			}

			try
			{
				for (int index = 0; index < Constants.MAX_QUEUES; ++index)
				{
					int maxData = MaxDataArray[index];
					if (0 != maxData)
					{
						WinForm.Manager.DatabaseManager.DeletePlayerNotifyData(MessageId, maxData, index);
					}
				}

				Int32 count = WinForm.Manager.DatabaseManager.CountPlayerNotifyData(MessageId);
				if (0 == count)
				{
					WinForm.Manager.DatabaseManager.DeletePlayerNotifyAMsg(MessageId);
				}
			}
			catch (Exception ex)
			{
				WinForm.Manager.LogManager.Error(ex.ToString());
			}
		}

		public void SetMsgObject(AMsgObject msgObject)
		{
			MessageId = msgObject.MessageId;
			MessageText = msgObject.MessageText;
		}

		public IList<DataObject> DataObjectList { get; private set; }
		public IList<DataObject>[] ItemObjectList { get; private set; }
		public IList<String> TokenStringList { get; private set; }
		public Int32[] MaxDataArray { get; private set; }
		public Int32[] TotalngArray { get; private set; }
		public Int32[] PercentArray { get; private set; }
		public Int32 MessageId { get; private set; }
		public String MessageText { get; private set; }
	}
}