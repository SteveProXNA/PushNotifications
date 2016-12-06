using System;
using System.Configuration;
using MainApplication.Static;

namespace MainApplication.Managers
{
	public interface IConfigManager
	{
		void Initialize();

		PlatformType PlatformType { get; }
		Boolean SendMessage { get; }
		Int32 MaxBatch{ get; }
		Int32 Increment { get; }
		Int32 CommandTimeout { get; }
		String ConnectionString { get; }
	}

	public class ConfigManager : IConfigManager
	{
		public void Initialize()
		{
			String platformText = GetAppSettings(Constants.CONFIG_PLATFORM_TYPE);

			PlatformType platformType;
			if (Enum.TryParse(platformText, true, out platformType))
			{
				PlatformType = platformType;
			}

			SendMessage = false;
			String sendMessageText = GetAppSettings(Constants.CONFIG_SEND_MESSAGE);

			Boolean sendMessage;
			if (Boolean.TryParse(sendMessageText, out sendMessage))
			{
				SendMessage = sendMessage;
			}

			String maxBatchText = GetAppSettings(Constants.CONFIG_MAX_BATCH);
			MaxBatch = Convert.ToInt32(maxBatchText);
			if (0 == MaxBatch)
			{
				MaxBatch = 20;
			}

			String incrementText = GetAppSettings(Constants.CONFIG_INCREMENT);
			Increment = Convert.ToInt32(incrementText);
			if (0 == Increment)
			{
				Increment = 1000;
			}

			String commandTimeoutText = GetAppSettings(Constants.CONFIG_CMD_TIMEOUT);
			CommandTimeout = Convert.ToInt32(commandTimeoutText);
			if (0 == CommandTimeout)
			{
				CommandTimeout = 30;
			}

			ConnectionString = ConfigurationManager.ConnectionStrings[Constants.CONFIG_CONNECTION_STRING].ConnectionString;
		}

		public PlatformType PlatformType { get; private set; }
		public Boolean SendMessage { get; private set; }
		public Int32 MaxBatch { get; private set; }
		public Int32 Increment { get; private set; }
		public Int32 CommandTimeout { get; private set; }
		public String ConnectionString { get; private set; }

		private static String GetAppSettings(String key)
		{
			return ConfigurationManager.AppSettings[key];
		}
	}

}