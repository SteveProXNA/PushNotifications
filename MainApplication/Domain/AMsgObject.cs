using System;

namespace MainApplication.Domain
{
	public class AMsgObject
	{
		public AMsgObject(int messageId, string messageText, DateTime messageDate)
		{
			MessageId = messageId;
			MessageText = messageText;
			MessageDate = messageDate;
		}

		public int MessageId { get; private set; }
		public string MessageText { get; private set; }
		public DateTime MessageDate { get; private set; }
	}
}