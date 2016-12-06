using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MainApplication.Notifications
{
	public class GoogleNotificationManager : ANotificationManager
	{
		private string applicationId;
		private string senderId;
		private string requestUriString;

		public override void Initialize(IList<String> configuration, Int32 maxBatch)
		{
			Initialize(false, configuration, maxBatch);
		}
		public override void Initialize(Boolean sendMessage, IList<String> configuration, Int32 maxBatch)
		{
			applicationId = configuration[0];
			senderId = configuration[1];
			requestUriString = configuration[2];

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
				ProcessData(index, notificationToken, message, queue);
			}
		}

		public override void ProcessData(Int32 index, String notificationToken, String message, int queue)
		{
			if (!SendMessage)
			{
				return;
			}

			Stream dataStream = null;
			WebResponse response = null;
			StreamReader reader = null;
			try
			{
				WebRequest request = WebRequest.Create(requestUriString);
				request.Method = "post";
				request.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
				request.Headers.Add(string.Format("Authorization: key={0}", applicationId));
				request.Headers.Add(string.Format("Sender: id={0}", senderId));

				String postData =
					String.Format("time_to_live=108&delay_while_idle=1&data.message={0}&data.time={1}&registration_id={2}", message,
						DateTime.Now, notificationToken);
				Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
				request.ContentLength = byteArray.Length;

				dataStream = request.GetRequestStream();
				dataStream.Write(byteArray, 0, byteArray.Length);

				response = request.GetResponse();
				dataStream = response.GetResponseStream();

				if (dataStream != null)
				{
					reader = new StreamReader(dataStream);
					//String responseFromServer = reader.ReadToEnd();
				}
			}
			catch
			{
				//RejectedList.Add(notificationToken);
			}
			finally
			{
				if (null != reader)
				{
					reader.Close();
				}
				if (null != response)
				{
					response.Close();
				}
				if (null != dataStream)
				{
					dataStream.Close();
				}
			}
		}

	}
}