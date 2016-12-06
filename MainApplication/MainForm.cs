using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using MainApplication.Domain;
using MainApplication.Static;
using DataObject = MainApplication.Domain.DataObject;
using Timer = System.Timers.Timer;

namespace MainApplication
{
	public partial class MainForm : Form
	{
		private IList<DataObject> datatObjectList;
		private readonly IDictionary<Int32, ProgressBar> progressBarDictionary;
		private readonly IDictionary<Int32, Label> resultLabelDictionary;
		private readonly Timer timer;
		private readonly object updateLock = new object();

		public MainForm()
		{
			InitializeComponent();

			progressBarDictionary = GetProgressBarDictionary();
			resultLabelDictionary = GetResultLabelDictionary();
			ResetResultLabels();
			ResetStatusLabel();
			ResetTotalsLabel();

			timer = new Timer(2000) { AutoReset = true };
			timer.Elapsed += TimerOnElapsed;
		}

		public void Initialize()
		{
			Text = String.Format(Localization.WINFORM_TITLE, WinForm.Manager.ConfigManager.PlatformType,
				WinForm.Manager.ProgramManager.GetCurrentProcessId(), WinForm.Manager.ProgramManager.GetAssemblyFileVersion());
		}

		public void MessageBoxShow(string text)
		{
			WinForm.Manager.LogManager.Info(text);
			PlatformType platformType = WinForm.Manager.ConfigManager.PlatformType;
			MessageBox.Show(text, platformType + Localization.WINFORM_CAPTION, MessageBoxButtons.OK);
		}

		public void UpdateUI()
		{
			for (int key = 0; key < Constants.MAX_THREADS; ++key)
			{
				lock (updateLock)
				{
					int percentArray = WinForm.Manager.InfoManager.PercentArray[key];
					int totalngArray = WinForm.Manager.InfoManager.TotalngArray[key];

					// Defend against potential Division by Zero exception.
					if (0 != totalngArray)
					{
						float percentageFloat = (float)percentArray / totalngArray;
						int percentage = (int)(100 * percentageFloat);
						ProgressBar progressBar = progressBarDictionary[key];
						progressBar.Invoke((MethodInvoker)(() => progressBar.Value = percentage));

						Label resultLabel = resultLabelDictionary[key];
						String message = String.Format(@"{0} / {1} [{2}%]", percentArray, totalngArray, percentage);
						resultLabel.Invoke((MethodInvoker)(() => resultLabel.Text = message));
					}
				}
			}
		}

		public void Complete()
		{
			WinForm.Manager.LogManager.Info("DatabaseManager Delete()");
			WinForm.Manager.InfoManager.Delete();

			UpdateUI();
			StopTimer();

			StatusLabel.Invoke((MethodInvoker)(() => StatusLabel.Text = Localization.STATUS_ENDED));
			StatusLabel.Invoke((MethodInvoker)(() => StatusLabel.Refresh()));

			WinForm.Manager.StopwatchManager.Stop();
			TimeSpan ts = WinForm.Manager.StopwatchManager.GetElapsed();

			String elapsed = WinForm.Manager.StopwatchManager.ToString();
			String message1 = String.Format("{0}  [{1}]", Localization.STATUS_ENDED, elapsed);
			WinForm.Manager.LogManager.Info(message1);

			String message2 = String.Format("{0}{1}[{2}]", Localization.STATUS_ENDED, Environment.NewLine, elapsed);
			PlatformType platformType = WinForm.Manager.ConfigManager.PlatformType;
			MessageBox.Show(message2, platformType + Localization.WINFORM_CAPTION, MessageBoxButtons.OK);
		}

		public void StopTimer()
		{
			timer.Enabled = false;
		}

		private void DataButton_Click(object sender, EventArgs e)
		{
			WinForm.Manager.LogManager.Info("DataButton() START");
			DataButton.Enabled = false;

			// Check for notifications.
			DateTime now = DateTime.Now;
			UpdateStatusLabel(@"SELECT notifications <= " + now.ToString("yyyy-MM-dd HH:mm:ss"));
			AMsgObject aMsgObject = WinForm.Manager.DatabaseManager.SelectPlayerNotifyAMsg(now);
			if (null == aMsgObject)
			{
				MessageBoxShow(Localization.NO_NOTIFICATIONS);
				DataButton.Enabled = true;
				ResetStatusLabel();
				WinForm.Manager.LogManager.Info("DataButton_Click() -END-");
				return;
			}

			// Check for accounts.
			WinForm.Manager.InfoManager.SetMsgObject(aMsgObject);
			Int32 dataMessageId = aMsgObject.MessageId;
			WinForm.Manager.LogManager.Info("DATA message : " + dataMessageId);
			UpdateStatusLabel(@"SELECT accounts for MessageId : " + dataMessageId);
			UpdateTotalsLabel(Localization.ALL_PROCESSING);
			Int32 count = WinForm.Manager.DatabaseManager.CountPlayerNotifyData(dataMessageId);
			if (0 == count)
			{
				String message = String.Format("{0}{1}", Localization.NO_PLAYER_DATA, dataMessageId);
				MessageBoxShow(message);
				DataButton.Enabled = true;
				ResetStatusLabel();
				ResetTotalsLabel();
				WinForm.Manager.LogManager.Info("DataButton_Click() -END-");
				return;
			}

			// Populate account data but Filter out duplicates.
			IList<DataObject> selectDatatObjectList = WinForm.Manager.DatabaseManager.SelectPlayerNotifyData(dataMessageId);
			WinForm.Manager.LogManager.Info("DATA selectd : " + selectDatatObjectList.Count);

			// Filter out duplicate notification token entries!
			datatObjectList = WinForm.Manager.DatabaseManager.FilterPlayerNotifyData(selectDatatObjectList);

			// Calculate delta list and delete duplicate entries.
			// Note: in theory there should not be any duplicate.
			IList<DataObject> exceptDatatObjectList = selectDatatObjectList.Except(datatObjectList).ToList();
			IList<String> dataAccountTokenList = exceptDatatObjectList.Select(x => x.DataAccountToken).Distinct().ToList();
			foreach (String dataAccountToken in dataAccountTokenList)
			{
				DataObject dataObject = selectDatatObjectList.First(x => x.DataAccountToken == dataAccountToken);
				WinForm.Manager.DatabaseManager.DeletePlayerNotifyData(dataObject.DataId, dataMessageId, dataAccountToken);
			}

			// Finally, populate the actual list of unique device tokens.
			count = datatObjectList.Count;
			WinForm.Manager.LogManager.Info("DATA results : " + count);

			// Ready to send data.
			WinForm.Manager.InfoManager.Split(datatObjectList);
			DefaultProgressUI();

			UpdateStatusLabel(Localization.STATUS_READY);
			UpdateTotalsLabel(Localization.ALL_RESULTS + count);
			SendButton.Enabled = true;
			WinForm.Manager.LogManager.Info("DataButton() -END-");
		}

		private void SendButton_Click(object sender, EventArgs e)
		{
			WinForm.Manager.LogManager.Info("SendButton() START");
			SendButton.Enabled = false;
			UpdateStatusLabel(Localization.STATUS_SENDX);

			WinForm.Manager.StopwatchManager.Start();
			WinForm.Manager.LogManager.Info("SendButton() -END-");
			WinForm.Manager.TimerManager.Start();
			timer.Start();
		}

		private void ExitButton_Click(object sender, EventArgs e)
		{
			timer.Enabled = false;
			Application.Exit();
		}

		private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
		{
			UpdateUI();
		}

		#region Helper methods.
		private IDictionary<Int32, ProgressBar> GetProgressBarDictionary()
		{
			return new Dictionary<Int32, ProgressBar>
			{
				{0, ProgressBar0},
				{1, ProgressBar1},
				{2, ProgressBar2},
				{3, ProgressBar3},
				{4, ProgressBar4},
				{5, ProgressBar5},
				{6, ProgressBar6},
				{7, ProgressBar7},
				{8, ProgressBar8},
				{9, ProgressBar9},
			};
		}
		private IDictionary<Int32, Label> GetResultLabelDictionary()
		{
			return new Dictionary<Int32, Label>
			{
				{0, ResultLabel0},
				{1, ResultLabel1},
				{2, ResultLabel2},
				{3, ResultLabel3},
				{4, ResultLabel4},
				{5, ResultLabel5},
				{6, ResultLabel6},
				{7, ResultLabel7},
				{8, ResultLabel8},
				{9, ResultLabel9},
			};
		}

		private void ResetResultLabels()
		{
			for (int key = 0; key < Constants.MAX_THREADS; ++key)
			{
				Label resultLabel = resultLabelDictionary[key];
				resultLabel.Size = new Size(125, 15);
				resultLabel.Text = String.Empty;
				resultLabel.TextAlign = ContentAlignment.TopRight;
			}
		}
		private void ResetStatusLabel()
		{
			UpdateStatusLabel(String.Empty);
		}
		private void UpdateStatusLabel(String text)
		{
			StatusLabel.Text = text;
			StatusLabel.Refresh();
		}
		private void ResetTotalsLabel()
		{
			UpdateTotalsLabel(String.Empty);
		}
		private void UpdateTotalsLabel(String text)
		{
			TotalsLabel.Text = text;
			TotalsLabel.Refresh();
		}
		private void DefaultProgressUI()
		{
			for (int key = 0; key < Constants.MAX_THREADS; ++key)
			{
				Int32 total = WinForm.Manager.InfoManager.TotalngArray[key];
				if (0 != total)
				{
					continue;
				}

				ProgressBar progressBar = progressBarDictionary[key];
				progressBar.Value = 100;
				progressBar.Refresh();

				Label resultLabel = resultLabelDictionary[key];
				resultLabel.Text = @"0 / 0 [100%]";
				resultLabel.Refresh();
			}
		}
		#endregion
	}
}