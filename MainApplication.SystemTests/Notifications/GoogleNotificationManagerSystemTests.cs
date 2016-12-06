using System;
using System.Collections.Generic;
using MainApplication.Notifications;
using MainApplication.Static;
using NUnit.Framework;

namespace MainApplication.SystemTests.Notifications
{
	[TestFixture]
	public class GoogleNotificationManagerSystemTests
	{
		// System under test.
		private INotificationManager googleNotificationManager;
		
		// Test notification token.
		private const String NotificationToken = "APA91bF1KcqRS0aghyaMPt1RkUrvYquslCvZ0MHP-xJHxeZS2u3olhezaq9415HnaGSnlSVXU-MBo3fJWFahGwK2c95MAHcRxJAyKb_N69F5e8yEp9cA4iETNUsxAxD1A4sBiYAfvvLNb4u2SIRV-pS0wx2rWdHrlw";
		private const int Queue = 1;

		[SetUp]
		public void SetUp()
		{
			googleNotificationManager = new GoogleNotificationManager();

			IList<String> configuration = GetConfiguration();
			googleNotificationManager.Initialize(configuration, 20);
		}

		[Test]
		public void ProcessDataTwoTest()
		{
			const string message = "GOOGLE Test push notification!";
			googleNotificationManager.ProcessData(0, NotificationToken, message, Queue);
		}

		[Test]
		public void ProcessListTest()
		{
			const string message = "GOOGLE Test push notification list!";
			var notificationTokenList = new List<string>
			{
				NotificationToken,
				NotificationToken,
				NotificationToken
			};

			googleNotificationManager.ProcessList(notificationTokenList, message, Queue);
		}

		private static IList<String> GetConfiguration()
		{
			return new List<String>
			{
				Constants.GOOGLE_APPLICATION,
				Constants.GOOGLE_SENDERID,
				Constants.GOOGLE_REQUESTURL
			};
		}

		[TearDown]
		public void TearDown()
		{
			googleNotificationManager = null;
		}

	}
}