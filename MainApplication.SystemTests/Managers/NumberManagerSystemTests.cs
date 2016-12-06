using System;
using NUnit.Framework;

namespace MainApplication.SystemTests.Managers
{
	[TestFixture]
	public class NumberManagerSystemTests : BaseSystemTests
	{
		[SetUp]
		public void SetUp()
		{
			// System under test.
			NumberManager = WinForm.Manager.NumberManager;
			NumberManager.Initialize();
		}

		[Test]
		public void GenerateOne()
		{
			Int32 result = NumberManager.Generate(10);
			Print(result);
		}

		[Test]
		public void GenerateTwo()
		{
			Int32 result = NumberManager.Generate(1, 10);
			Print(result);
		}

	}
}