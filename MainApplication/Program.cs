using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MainApplication.Notifications;
using MainApplication.Static;
using MainApplication.TheForm;

namespace MainApplication
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Application.ApplicationExit += Application_ApplicationExit;
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

			// Initialize application.
			Registration.Initialize();

			IFormManager manager = FormFactory.Resolve();
			WinForm.Construct(manager);

			WinForm.Manager.LogManager.Initialize();
			WinForm.Manager.LogManager.Info("Program Main() START");

			WinForm.Manager.ConfigManager.Initialize();
			PlatformType platformType = WinForm.Manager.ConfigManager.PlatformType;
			if (PlatformType.None == platformType)
			{
				MessageBox.Show(Localization.NO_PLATFORM_CFG, Localization.WINFORM_CAPTION);
				Application.Exit();
				return;
			}

			// Substitute the notification manager at runtime depending on configuration.
			INotificationManager notificationManager = GetNotificationManager(platformType);

			Boolean sendMessage = WinForm.Manager.ConfigManager.SendMessage;
			IList<String> configuration = GetNotificationConfiguration(platformType);
			Int32 maxBatch = WinForm.Manager.ConfigManager.MaxBatch;

			WinForm.Manager.UpdateNotificationManager(notificationManager);
			WinForm.Manager.NotificationManager.Initialize(sendMessage, configuration, maxBatch);
			UpdateLog(platformType, configuration, sendMessage, maxBatch);

			WinForm.Manager.EventManager.Initialize();
			WinForm.Manager.InfoManager.Initialize();
			WinForm.Manager.NumberManager.Initialize();
			WinForm.Manager.StopwatchManager.Initialize();
			WinForm.Manager.ThreadManager.Initialize();
			WinForm.Manager.TimerManager.Initialize();
			WinForm.Manager.WorkManager.Initialize();

			// Initialize and run main form.
			MainForm mainForm = new MainForm();
			mainForm.Initialize();
			WinForm.Manager.RenderManager.Initialize(mainForm);
			WinForm.Manager.LogManager.Info("Program Main() -END-");

			Application.Run(mainForm);
		}

		private static void Application_ApplicationExit(object sender, EventArgs e)
		{
			WinForm.Manager.LogManager.Info("DatabaseManager Delete()");
			WinForm.Manager.InfoManager.Delete();

			WinForm.Manager.LogManager.Info("EventManager Close()");
			WinForm.Manager.EventManager.Close();

			WinForm.Manager.LogManager.Info("ThreadManager Abort()");
			WinForm.Manager.ThreadManager.Abort();

			WinForm.Manager.LogManager.Info("Application Exit()");
			FormFactory.Release();
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			WinForm.Manager.LogManager.Fatal("CurrentDomain_UnhandledException! " + e.ExceptionObject.ToString());
		}

		private static INotificationManager GetNotificationManager(PlatformType platformType)
		{
			if (platformType == PlatformType.Android)
			{
				return new GoogleNotificationManager();
			}
			if (platformType == PlatformType.iOS)
			{
				return new AppleNotificationManager();
			}

			return null;
		}

		private static IList<String> GetNotificationConfiguration(PlatformType platformType)
		{
			if (platformType == PlatformType.Android)
			{
				return new List<String>
				{
					Constants.GOOGLE_APPLICATION,
					Constants.GOOGLE_SENDERID,
					Constants.GOOGLE_REQUESTURL
				};
			}
			if (platformType == PlatformType.iOS)
			{
				return new List<String>
				{
					Constants.APPLE_FILENAME, 
					Constants.APPLE_PASSWORD
				};
			}

			return null;
		}

		private static void UpdateLog(PlatformType platformType, IList<String> configuration, Boolean sendMessage, Int32 maxBatch)
		{
			WinForm.Manager.LogManager.Info("Platform  : " + platformType);
			WinForm.Manager.LogManager.Info("SendMsgs  : " + sendMessage.ToString().ToUpper());
			WinForm.Manager.LogManager.Info("MaxBatch  : " + maxBatch);

			for (Byte index = 0; index < configuration.Count; ++index)
			{
				WinForm.Manager.LogManager.Info("Config[" + index + "] : " + configuration[index]);
			}
		}

	}
}