using System;
using System.Runtime.InteropServices;

namespace MainApplication
{
	public static class NativeMethods
	{
		[DllImport("Kernel32", EntryPoint = "GetCurrentThreadId", ExactSpelling = true)]
		internal static extern Int32 GetCurrentWin32ThreadId();
	}
}