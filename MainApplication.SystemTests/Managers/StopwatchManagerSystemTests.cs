using System;
using NUnit.Framework;

namespace MainApplication.SystemTests.Managers
{
	[TestFixture]
	public class StopwatchManagerSystemTests : BaseSystemTests
	{
		[SetUp]
		public void SetUp()
		{
			// System under test.
			StopwatchManager = WinForm.Manager.StopwatchManager;
			StopwatchManager.Initialize();
		}

		[Test]
		public void GenerateOne()
		{
			StopwatchManager.Start();
			StopwatchManager.Stop();
			Assert.That(String.Empty, Is.EqualTo(StopwatchManager.ToString()));
			TimeSpan timeSpan = StopwatchManager.GetElapsed();
			Print(timeSpan.Seconds);
		}
	}
}