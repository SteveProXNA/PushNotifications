using System;
using System.Diagnostics;

namespace MainApplication.Managers
{
	public interface IStopwatchManager
	{
		void Initialize();
		void Start();
		void Stop();
		TimeSpan GetElapsed();
		String ToString();
	}

	public class StopwatchManager : IStopwatchManager
	{
		private Stopwatch stopwatch;

		public void Initialize()
		{
			stopwatch = new Stopwatch();
		}

		public void Start()
		{
			stopwatch.Start();
		}

		public void Stop()
		{
			stopwatch.Stop();
		}

		public TimeSpan GetElapsed()
		{
			return stopwatch.Elapsed;
		}

		public new String ToString()
		{
			TimeSpan elapsed = stopwatch.Elapsed;
			if (TimeSpan.Zero == elapsed)
			{
				return String.Empty;
			}

			String day = 0 == elapsed.Days ? String.Empty : elapsed.Days + "day ";
			String hrs = 0 == elapsed.Hours ? String.Empty : elapsed.Hours + "hrs ";
			String min = 0 == elapsed.Minutes ? String.Empty : elapsed.Minutes + "min ";
			String sec = 0 == elapsed.Seconds ? String.Empty : elapsed.Seconds + "sec";

			return String.Format("{0}{1}{2}{3}", day, hrs, min, sec);
		}

	}
}