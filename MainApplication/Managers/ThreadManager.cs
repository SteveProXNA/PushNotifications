using System;
using System.Threading;
using MainApplication.Static;

namespace MainApplication.Managers
{
	public interface IThreadManager
	{
		void Initialize();
		void Start(object parameter);
		void Sleep(int millisecondsTimeout);
		void Abort();
	}

	public class ThreadManager : IThreadManager
	{
		private Thread[] threads;

		public void Initialize()
		{
			threads = new Thread[Constants.MAX_THREADS];
			for (UInt16 index = 0; index < Constants.MAX_THREADS; ++index)
			{
				threads[index] = new Thread(BackgroundThread)
				{
					Name = "Thread" + index,
					IsBackground = true
				};
			}
		}

		public void Start(object parameter)
		{
			UInt16 index = Convert.ToUInt16(parameter);
			threads[index].Start(parameter);
		}

		public void Sleep(int millisecondsTimeout)
		{
			Thread.Sleep(millisecondsTimeout);
		}

		public void Abort()
		{
			if (null == threads)
			{
				return;
			}

			// Abort all the threads.
			for (UInt16 index = 0; index < Constants.MAX_THREADS; ++index)
			{
				threads[index].Abort();
			}

			threads = null;
		}

		private static void BackgroundThread(object parameter)
		{
			UInt16 index = Convert.ToUInt16(parameter);
			WinForm.Manager.WorkManager.Work(index);
			WinForm.Manager.EventManager.Set(index);
		}

	}
}