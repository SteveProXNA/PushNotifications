using System;
using System.Threading;
using MainApplication.Static;

namespace MainApplication.Managers
{
	public interface IEventManager
	{
		void Initialize();
		void Set(UInt16 index);
		void Reset(UInt16 index);
		void WaitOne(UInt16 index);
		void WaitAll();
		void Close();
	}

	public class EventManager : IEventManager
	{
		private WaitHandle[] events;

		public void Initialize()
		{
			events = new WaitHandle[Constants.MAX_THREADS];
			for (UInt16 index = 0; index < Constants.MAX_THREADS; ++index)
			{
				events[index] = new ManualResetEvent(false);
			}
		}

		public void Set(UInt16 index)
		{
			ManualResetEvent ev = events[index] as ManualResetEvent;
			if (null != ev)
			{
				ev.Set();
			}
		}
		public void Reset(UInt16 index)
		{
			ManualResetEvent ev = events[index] as ManualResetEvent;
			if (null != ev)
			{
				ev.Reset();
			}
		}

		public void WaitOne(UInt16 index)
		{
			ManualResetEvent ev = events[index] as ManualResetEvent;
			if (null != ev)
			{
				ev.WaitOne();
			}
		}
		public void WaitAll()
		{
			WaitHandle.WaitAll(events);
		}

		public void Close()
		{
			if (null == events)
			{
				return;
			}

			// Close all the events.
			for (UInt16 index = 0; index < Constants.MAX_THREADS; ++index)
			{
				events[index].Close();
			}

			events = null;
		}

	}
}