using System;
using System.Collections.Generic;
using MainApplication.Static;
using MainApplication.MoonAPNS;

namespace MainApplication.Notifications
{
	public interface INotificationManager
	{
		void Initialize(IList<string> configuration, Int32 maxBatch);
		void Initialize(Boolean sendMessage, IList<String> configuration, Int32 maxBatch);
		void ResetPayloadList(int queue);

		// Factory methods.
		void ProcessList(List<String> notificationTokenList, String message, Int32 queue);
		void ProcessData(Int32 index, String notificationToken, String message, Int32 queue);

		// Properties.
		List<NotificationPayload>[] PayloadList { get; }
		//List<String> RejectedList { get; }
		Boolean SendMessage { get; }
		Int32 MaxBatch { get; }
	}

	public abstract class ANotificationManager : INotificationManager
	{
		public virtual void Initialize(IList<String> configuration, Int32 maxBatch)
		{
			Initialize(false, configuration, maxBatch);
		}
		public virtual void Initialize(Boolean sendMessage, IList<String> configuration, Int32 maxBatch)
		{
			PayloadList = new List<NotificationPayload>[Constants.MAX_QUEUES];
			for (int queue = 0; queue < Constants.MAX_QUEUES; ++queue)
			{
				PayloadList[queue] = new List<NotificationPayload>(maxBatch);
			}

			//RejectedList = new List<String>();
			SendMessage = sendMessage;
			MaxBatch = maxBatch;

			for (int queue = 0; queue < Constants.MAX_QUEUES; ++queue)
			{
				for (int index = 0; index < MaxBatch; ++index)
				{
					var payload = new NotificationPayload(String.Empty, String.Empty, 0, String.Empty);
					PayloadList[queue].Add(payload);
				}
			}
		}

		public void ResetPayloadList(int queue)
		{
			for (int index = 0; index < MaxBatch; ++index)
			{
				PayloadList[queue][index].DeviceToken = String.Empty;
				PayloadList[queue][index].Alert.Body = String.Empty;
			}
		}

		// Factory methods.
		public abstract void ProcessList(List<String> notificationTokenList, String message, Int32 queue);
		public abstract void ProcessData(Int32 index, String notificationToken, String message, Int32 queue);

		// Properties.
		public List<NotificationPayload>[] PayloadList { get; protected set; }
		//public List<String> RejectedList { get; protected set; }
		public Boolean SendMessage { get; protected set; }
		public Int32 MaxBatch { get; protected set; }
	}

	public class DummyNotificationManager : INotificationManager
	{
		public void Initialize(IList<string> configuration, int maxBatch)
		{
			throw new NotImplementedException();
		}

		public void Initialize(bool sendMessage, IList<string> configuration, int maxBatch)
		{
			throw new NotImplementedException();
		}

		public void ProcessData(string notificationToken, string message)
		{
			throw new NotImplementedException();
		}

		public void ResetPayloadList(int queue)
		{
			throw new NotImplementedException();
		}

		public void ProcessList(List<string> notificationTokenList, string message, int queue)
		{
			throw new NotImplementedException();
		}

		public void ProcessData(int index, string notificationToken, string message, int queue)
		{
			throw new NotImplementedException();
		}

		public List<NotificationPayload>[] PayloadList
		{
			get { throw new NotImplementedException(); }
		}

		public List<string> RejectedList
		{
			get { throw new NotImplementedException(); }
		}

		public bool SendMessage
		{
			get { throw new NotImplementedException(); }
		}

		public int MaxBatch
		{
			get { throw new NotImplementedException(); }
		}
	}

}