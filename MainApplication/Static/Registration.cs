using MainApplication.Databases;
using MainApplication.Library;
using MainApplication.Managers;
using MainApplication.Notifications;
using MainApplication.TheForm;

namespace MainApplication.Static
{
	public static class Registration
	{
		public static void Initialize()
		{
			// General.
			IoCContainer.Initialize<IFormManager, FormManager>();

			// Managers.
			IoCContainer.Initialize<IConfigManager, ConfigManager>();
			IoCContainer.Initialize<IDatabaseManager, DatabaseManager>();
			IoCContainer.Initialize<IEventManager, EventManager>();
			IoCContainer.Initialize<IInfoManager, InfoManager>();
			IoCContainer.Initialize<INumberManager, NumberManager>();
			IoCContainer.Initialize<IProgramManager, ProgramManager>();
			IoCContainer.Initialize<IRenderManager, RenderManager>();
			IoCContainer.Initialize<IStopwatchManager, StopwatchManager>();
			IoCContainer.Initialize<IThreadManager, ThreadManager>();
			IoCContainer.Initialize<ITimerManager, TimerManager>();
			IoCContainer.Initialize<IWorkManager, WorkManager>();
			IoCContainer.Initialize<ILogManager, LogManager>();

			// Notifications.
			IoCContainer.Initialize<INotificationManager, DummyNotificationManager>();

			// Databases.
			IoCContainer.Initialize<IDatabaseFactory, MySqlWorkDataFactory>();
		}
	}
}