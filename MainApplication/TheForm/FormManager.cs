using MainApplication.Managers;
using MainApplication.Notifications;

namespace MainApplication.TheForm
{
	public interface IFormManager
	{
		void UpdateNotificationManager(INotificationManager notificationManager);

		IConfigManager ConfigManager { get; }
		IDatabaseManager DatabaseManager { get; }
		IEventManager EventManager { get; }
		IInfoManager InfoManager { get; }
		INotificationManager NotificationManager { get; }
		INumberManager NumberManager { get; }
		IProgramManager ProgramManager { get; }
		IRenderManager RenderManager { get; }
		IStopwatchManager StopwatchManager { get; }
		IThreadManager ThreadManager { get; }
		ITimerManager TimerManager { get; }
		IWorkManager WorkManager { get; }
		ILogManager LogManager { get; }
	}

	public class FormManager : IFormManager
	{
		public FormManager
		(
			IConfigManager configManager,
			IDatabaseManager databaseManager,
			IEventManager eventManager,
			IInfoManager infoManager,
			INotificationManager notificationManager,
			INumberManager numberManager,
			IProgramManager programManager,
			IRenderManager renderManager,
			IStopwatchManager stopwatchManager,
			IThreadManager threadManager,
			ITimerManager timerManager,
			IWorkManager workManager,
			ILogManager logManager
		)
		{
			ConfigManager = configManager;
			DatabaseManager = databaseManager;
			EventManager = eventManager;
			InfoManager = infoManager;
			NotificationManager = notificationManager;
			NumberManager = numberManager;
			ProgramManager = programManager;
			RenderManager = renderManager;
			StopwatchManager = stopwatchManager;
			ThreadManager = threadManager;
			TimerManager = timerManager;
			WorkManager = workManager;
			LogManager = logManager;
		}

		public void UpdateNotificationManager(INotificationManager notificationManager)
		{
			NotificationManager = notificationManager;
		}

		public IConfigManager ConfigManager { get; private set; }
		public IDatabaseManager DatabaseManager { get; private set; }
		public IEventManager EventManager { get; private set; }
		public IInfoManager InfoManager { get; private set; }
		public INotificationManager NotificationManager { get; private set; }
		public INumberManager NumberManager { get; private set; }
		public IProgramManager ProgramManager { get; private set; }
		public IRenderManager RenderManager { get; private set; }
		public IStopwatchManager StopwatchManager { get; private set; }
		public IThreadManager ThreadManager { get; private set; }
		public ITimerManager TimerManager { get; private set; }
		public IWorkManager WorkManager { get; private set; }
		public ILogManager LogManager { get; private set; }
	}
}