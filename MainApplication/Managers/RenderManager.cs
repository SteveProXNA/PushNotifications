using System.Windows.Forms;

namespace MainApplication.Managers
{
	public interface IRenderManager
	{
		void Initialize(Form theForm);
		void Complete();
	}

	public class RenderManager : IRenderManager
	{
		private MainForm mainForm;

		public void Initialize(Form theForm)
		{
			mainForm = theForm as MainForm;
		}
		public void Complete()
		{
			mainForm.Complete();
		}
	}
}