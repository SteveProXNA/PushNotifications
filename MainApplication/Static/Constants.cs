using System;

namespace MainApplication.Static
{
	public static class Constants
	{
		// Configuration.
		public static readonly String CONFIG_PLATFORM_TYPE = "Platform";
		public static readonly String CONFIG_SEND_MESSAGE = "SendMessage";
		public static readonly String CONFIG_MAX_BATCH = "MaxBatch";
		public static readonly String CONFIG_INCREMENT = "Increment";
		public static readonly String CONFIG_CMD_TIMEOUT = "CommandTimeout";
		public static readonly String CONFIG_CONNECTION_STRING = "LocalMySqlServer";

		public static readonly UInt16 MAX_QUEUES = 10;
		public static readonly UInt16 MAX_THREADS = 10;

		public static readonly UInt16 TIMER_INTERVAL = 1000;
		public static readonly UInt16 THREAD_SLEEP = 50;


		// Apple.
		public static readonly String APPLE_FILENAME = "APPLE_FILENAME.p12";
		public static readonly String APPLE_PASSWORD = "APPLE_PASSWORD";


		// Google.
		public static readonly String GOOGLE_APPLICATION = "GOOGLE_APPLICATION_KEY";
		public static readonly String GOOGLE_SENDERID = "GOOGLE_SENDERID_KEY";
		public static readonly String GOOGLE_REQUESTURL = "https://android.googleapis.com/gcm/send";
	}
}