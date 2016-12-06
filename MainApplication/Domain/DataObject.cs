namespace MainApplication.Domain
{
	public class DataObject
	{
		public DataObject(int dataId, int dataMessageId, string dataAccountToken)// : this(dataId, dataMessageId, 0, dataAccountToken)
		{
			DataId = dataId;
			DataMessageId = dataMessageId;
			DataAccountToken = dataAccountToken;
		}

		public int DataId { get; private set; }
		public int DataMessageId { get; private set; }
		public string DataAccountToken { get; private set; }
	}
}