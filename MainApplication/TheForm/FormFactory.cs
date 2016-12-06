using MainApplication.Library;

namespace MainApplication.TheForm
{
	public static class FormFactory
	{
		public static IFormManager Resolve()
		{
			return IoCContainer.Resolve<IFormManager>();
		}

		public static void Release()
		{
			IoCContainer.Release();
		}
	}
}