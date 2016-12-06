using System;
using System.Timers;
using MainApplication.Static;

namespace MainApplication.Managers
{
	public interface ITimerManager
	{
		void Initialize();

		void Start();
		void Stop();
	}

	public class TimerManager : ITimerManager
	{
		private Timer timer;

		public void Initialize()
		{
			UInt16 interval = Constants.TIMER_INTERVAL;
			timer = new Timer(interval) { AutoReset = true };
			timer.Elapsed += TimerOnElapsed;
		}

		public void Start()
		{
			WinForm.Manager.LogManager.Info("Timer start...");
			timer.Start();
		}
		public void Stop()
		{
			WinForm.Manager.LogManager.Info("Timer STOP!");
			timer.Stop();
		}

		private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
		{
			timer.Enabled = false;

			for (UInt16 index = 0; index < Constants.MAX_THREADS; ++index)
			{
				WinForm.Manager.ThreadManager.Start(index);
			}

			// Timer thread blocked until all worker threads set (complete).
			WinForm.Manager.EventManager.WaitAll();
			WinForm.Manager.RenderManager.Complete();
		}

	}
}