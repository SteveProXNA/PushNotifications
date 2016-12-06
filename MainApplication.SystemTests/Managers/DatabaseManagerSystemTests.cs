using System;
using System.Collections.Generic;
using MainApplication.Domain;
using NUnit.Framework;

namespace MainApplication.SystemTests.Managers
{
	[TestFixture]
	public class DatabaseManagerSystemTests : BaseSystemTests
	{
		[SetUp]
		public void SetUp()
		{
			// System under test.
			DatabaseManager = WinForm.Manager.DatabaseManager;
		}

		// SELECT statements.
		[Test]
		public void SelectPlayerNotifyAMsgTest()
		{
			DateTime dateTime = new DateTime(2016, 07, 04);
			AMsgObject aMsgObject = DatabaseManager.SelectPlayerNotifyAMsg(dateTime);
			Assert.That(aMsgObject, Is.Not.Null);
			Print(aMsgObject.MessageText);
		}
		[Test]
		public void SelectPlayerNotifyDataTest()
		{
			const Int32 dataMessageId = 4;
			IList<DataObject> dataObjectList = DatabaseManager.SelectPlayerNotifyData(dataMessageId);
			Assert.That(dataObjectList, Is.Not.Null);
			Int32 result = dataObjectList.Count;
			Print(result);
		}
		[Test]
		public void FilterPlayerNotifyDataTest()
		{
			const Int32 dataMessageId = 4;
			IList<DataObject> selectDataObjectList = DatabaseManager.SelectPlayerNotifyData(dataMessageId);
			IList<DataObject> filterDataObjectList = DatabaseManager.FilterPlayerNotifyData(selectDataObjectList);
			Assert.That(filterDataObjectList, Is.Not.Null);
			Int32 result = filterDataObjectList.Count;
			Print(result);
		}

		[Test]
		public void CountPlayerNotifyDataTest()
		{
			const Int32 dataMessageId = 1;
			Int32 count = DatabaseManager.CountPlayerNotifyData(dataMessageId);
			Assert.That(count, Is.GreaterThanOrEqualTo(0));
			Print(count);
		}

		// DELETE statements.
		[Test]
		public void DeletePlayerNotifyAMsgTest()
		{
			const Int32 messageId = 4;
			Int32 result = DatabaseManager.DeletePlayerNotifyAMsg(messageId);
			Print(result);
		}
		[Test]
		public void DeletePlayerNotifyData01Test()
		{
			const Int32 dataMessageId = 4;
			Int32 result = DatabaseManager.DeletePlayerNotifyData(dataMessageId);
			Print(result);
		}
		[Test]
		public void DeletePlayerNotifyData02Test()
		{
			const Int32 dataMessageId = 1;
			const Int32 maxData = 20;
			const Int32 index = 0;
			Int32 result = DatabaseManager.DeletePlayerNotifyData(dataMessageId, maxData, index);
			Print(result);
		}
		[Test]
		public void DeletePlayerNotifyData03Test()
		{
			const Int32 dataId = 3;
			const Int32 dataMessageId = 4;
			const String dataAccountToken = "520763af6845fb0b9cf13dc152c5e3729f329c9e8ea0416690698593b699318c";
			Int32 result = DatabaseManager.DeletePlayerNotifyData(dataId, dataMessageId, dataAccountToken);
			Print(result);
		}

		[TearDown]
		public void TearDown()
		{
			DatabaseManager = null;
		}

	}
}