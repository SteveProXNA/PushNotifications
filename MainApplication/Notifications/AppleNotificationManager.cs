using System;
using System.Collections.Generic;
using MainApplication.Static;
using MainApplication.MoonAPNS;

namespace MainApplication.Notifications
{
	public class AppleNotificationManager : ANotificationManager
	{
		private PushNotification[] pushNotification;

		public override void Initialize(IList<String> configuration, Int32 maxBatch)
		{
			Initialize(false, configuration, maxBatch);
		}
		public override void Initialize(Boolean sendMessage, IList<String> configuration, Int32 maxBatch)
		{
			string p12File = configuration[0];
			string p12FilePassword = configuration[1];

			pushNotification = new PushNotification[Constants.MAX_QUEUES];
			for (int queue = 0; queue < Constants.MAX_QUEUES; ++queue)
			{
				pushNotification[queue] = new PushNotification(false, p12File, p12FilePassword);
			}

			base.Initialize(sendMessage, configuration, maxBatch);
			//RejectedList.Clear();
		}

		public override void ProcessList(List<String> notificationTokenList, String message, int queue)
		{
			ResetPayloadList(queue);

			Int32 batch = Math.Min(MaxBatch, notificationTokenList.Count);
			for (int index = 0; index < batch; ++index)
			{
				String notificationToken = notificationTokenList[index];
				PayloadList[queue][index].DeviceToken = notificationToken;
				PayloadList[queue][index].Alert.Body = message;
			}

			if (SendMessage)
			{
				//RejectedList = pushNotification[queue].SendToApple(PayloadList);
				pushNotification[queue].SendToApple(PayloadList[queue]);
			}
		}

		public override void ProcessData(Int32 index, String notificationToken, String message, int queue)
		{
			ResetPayloadList(queue);

			PayloadList[queue][index].DeviceToken = notificationToken;
			PayloadList[queue][index].Alert.Body = message;

			if (SendMessage)
			{
				//RejectedList = pushNotification[queue].SendToApple(PayloadList);
				pushNotification[queue].SendToApple(PayloadList[queue]);
			}
		}

	}
}