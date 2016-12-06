using System;
using System.Diagnostics;
using System.Reflection;

namespace MainApplication.Managers
{
	public interface IProgramManager
	{
		Int32 GetCurrentProcessId();
		String GetAssemblyFileVersion();
	}

	public class ProgramManager : IProgramManager
	{
		public Int32 GetCurrentProcessId()
		{
			return Process.GetCurrentProcess().Id;
		}

		public String GetAssemblyFileVersion()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			if (null == assembly.Location)
			{
				return "1.0.0.0";
			}

			FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			return fileVersionInfo.FileVersion;
		}

	}
}