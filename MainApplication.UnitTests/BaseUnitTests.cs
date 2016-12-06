using MainApplication.Managers;
using MainApplication.Notifications;
using MainApplication.TheForm;
using NUnit.Framework;
using Rhino.Mocks;

namespace MainApplication.UnitTests
{
	public class BaseUnitTests
	{
		protected IConfigManager ConfigManager;
		protected IDatabaseManager DatabaseManager;
		protected IEventManager EventManager;
		protected IInfoManager InfoManager;
		protected INotificationManager NotificationManager;
		protected INumberManager NumberManager;
		protected IProgramManager ProgramManager;
		protected IRenderManager RenderManager;
		protected IStopwatchManager StopwatchManager;
		protected IThreadManager ThreadManager;
		protected ITimerManager TimerManager;
		protected IWorkManager WorkManager;
		protected ILogManager LogManager;

		// OneTimeSetup does not seem to execute!
#pragma warning disable 618
		[TestFixtureSetUp]
#pragma warning restore 618
		public void TestFixtureSetUp()
		{
			ConfigManager = MockRepository.GenerateStub<IConfigManager>();
			DatabaseManager = MockRepository.GenerateStub<IDatabaseManager>();
			EventManager = MockRepository.GenerateStub<IEventManager>();
			InfoManager = MockRepository.GenerateStub<IInfoManager>();
			NotificationManager = MockRepository.GenerateStub<INotificationManager>();
			NumberManager = MockRepository.GenerateStub<INumberManager>();
			ProgramManager = MockRepository.GenerateStub<IProgramManager>();
			RenderManager = MockRepository.GenerateStub<IRenderManager>();
			StopwatchManager = MockRepository.GenerateStub<IStopwatchManager>();
			ThreadManager = MockRepository.GenerateStub<IThreadManager>();
			TimerManager = MockRepository.GenerateStub<ITimerManager>();
			WorkManager = MockRepository.GenerateStub<IWorkManager>();
			LogManager = MockRepository.GenerateStub<ILogManager>();
		}

		protected void SetUp()
		{
			IFormManager manager = new FormManager(
				ConfigManager,
				DatabaseManager,
				EventManager,
				InfoManager,
				NotificationManager,
				NumberManager,
				ProgramManager,
				RenderManager,
				StopwatchManager,
				ThreadManager,
				TimerManager,
				WorkManager,
				LogManager
				);

			WinForm.Construct(manager);
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