using System;
using System.Globalization;

namespace MainApplication.Managers
{
	public interface ILogManager
	{
		void Initialize();

		void Debug(String message);
		void Info(String message);
		void Warn(String message);
		void Error(String message);
		void Fatal(String message);

		void Debug(int index, String message);
		void Info(int index, String message);
		void Warn(int index, String message);
		void Error(int index, String message);
		void Fatal(int index, String message);
	}

	public class LogManager : ILogManager
	{
		private static readonly log4net.ILog OUTPUT = log4net.LogManager.GetLogger(typeof(ILogManager));
		private Int32 threadId;
		private const Int32 Dummy = -1;

		public void Initialize()
		{
			log4net.Config.XmlConfigurator.Configure();
			threadId = NativeMethods.GetCurrentWin32ThreadId();
		}

		public void Debug(String message)
		{
			Debug(Dummy, message);
		}
		public void Info(String message)
		{
			Info(Dummy, message);
		}
		public void Warn(String message)
		{
			Warn(Dummy, message);
		}
		public void Error(String message)
		{
			Error(Dummy, message);
		}
		public void Fatal(String message)
		{
			Fatal(Dummy, message);
		}

		public void Debug(int index, String message)
		{
			OUTPUT.Debug(Prefix(index) + message);
		}
		public void Info(int index, String message)
		{
			OUTPUT.Info(Prefix(index) + message);
		}
		public void Warn(int index, String message)
		{
			OUTPUT.Warn(Prefix(index) + message);
		}
		public void Error(int index, String message)
		{
			OUTPUT.Error(Prefix(index) + message);
		}
		public void Fatal(int index, String message)
		{
			OUTPUT.Fatal(Prefix(index) + message);
		}

		private String Prefix(int index)
		{
			Int32 nextThreadId = NativeMethods.GetCurrentWin32ThreadId();
			String prefix = threadId == nextThreadId ? "MAIN" : "work";

			String value = Dummy == index ? " " : index.ToString();
			return String.Format("[{0}][{1}][{2}] ", value, prefix, nextThreadId.ToString(CultureInfo.InvariantCulture).PadLeft(5, ' '));
		}

	}
}