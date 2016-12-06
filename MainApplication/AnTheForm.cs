using MainApplication.TheForm;

namespace MainApplication
{
	public static class WinForm
	{
		public static void Construct(IFormManager manager)
		{
			Manager = manager;
		}

		public static IFormManager Manager { get; private set; }
	}
}