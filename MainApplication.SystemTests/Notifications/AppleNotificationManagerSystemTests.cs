using System;
using System.Collections.Generic;
using MainApplication.Notifications;
using MainApplication.Static;
using NUnit.Framework;

namespace MainApplication.SystemTests.Notifications
{
	[TestFixture]
	public class AppleNotificationManagerSystemTests
	{
		// System under test.
		private INotificationManager appleNotificationManager;

		// Test notification token.
		private const String NotificationToken = "8d3a28654bb40255d53edc1d430d20ba66fb233e92c96e28cb277b78318d61d6";
		private const int Queue = 1;

		[SetUp]
		public void SetUp()
		{
			appleNotificationManager = new AppleNotificationManager();

			IList<String> configuration = GetConfiguration();
			appleNotificationManager.Initialize(configuration, 20);
		}

		[Test]
		public void ProcessDataTest()
		{
			const string message = "APPLE Test push notification!";
			appleNotificationManager.ProcessData(0, NotificationToken, message, Queue);
		}

		[Test]
		public void ProcessListTest()
		{
			const string message = "APPLE Test push notification list!";
			var notificationTokenList = new List<string>
			{
				NotificationToken,
				NotificationToken,
				NotificationToken
			};

			appleNotificationManager.ProcessList(notificationTokenList, message, Queue);
		}

		private static IList<String> GetConfiguration()
		{
			return new List<String>
			{
				Constants.APPLE_FILENAME, 
				Constants.APPLE_PASSWORD
			};
		}

		[TearDown]
		public void TearDown()
		{
			appleNotificationManager = null;
		}

	}
}