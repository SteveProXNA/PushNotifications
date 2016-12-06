using System;
using MainApplication.Managers;
using MainApplication.Static;
using MainApplication.TheForm;
using NUnit.Framework;

namespace MainApplication.SystemTests
{
	public class BaseSystemTests
	{
		protected IConfigManager ConfigManager;
		protected IDatabaseManager DatabaseManager;
		protected IInfoManager InfoManager;
		protected INumberManager NumberManager;
		protected IStopwatchManager StopwatchManager;
		protected ILogManager LogManager;

		// OneTimeSetup does not seem to execute!
#pragma warning disable 618
		[TestFixtureSetUp]
#pragma warning restore 618
		public void TestFixtureSetUp()
		{
			Registration.Initialize();

			IFormManager manager = FormFactory.Resolve();
			WinForm.Construct(manager);

			WinForm.Manager.LogManager.Initialize();
			WinForm.Manager.ConfigManager.Initialize();
		}

		protected static void Print(object result)
		{
			Console.WriteLine(result);
		}

		// OneTimeTearDown does not seem to execute!
#pragma warning disable 618
		[TestFixtureTearDown]
#pragma warning restore 618
		public void TestFixtureTearDown()
		{
			FormFactory.Release();
		}
	}
}