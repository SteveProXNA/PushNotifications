using System;
using System.Collections.Generic;
using System.Linq;
using MainApplication.Domain;

namespace MainApplication.Managers
{
	public interface IWorkManager
	{
		void Initialize();
		void Work(int index);
	}

	public class WorkManager : IWorkManager
	{
		public void Initialize()
		{
		}

		public void Work(int index)
		{
			WinForm.Manager.LogManager.Info(index, "START working..." + index);

			Int32 maxBatch = WinForm.Manager.ConfigManager.MaxBatch;
			List<DataObject> workObjectList = new List<DataObject>();
			IList<DataObject> dataObjectList = WinForm.Manager.InfoManager.ItemObjectList[index] as List<DataObject>;

			Int32 increment = WinForm.Manager.ConfigManager.Increment;
			Int32 percent = 0;
			if (null != dataObjectList)
			{
				Int32 totalng = dataObjectList.Count;
				String messageText = WinForm.Manager.InfoManager.MessageText;
				while (true)
				{
					workObjectList.Clear();
					if (dataObjectList.Count > 0)
					{
						Int32 numBatch = Math.Min(maxBatch, dataObjectList.Count);
						workObjectList.AddRange(dataObjectList.Take(numBatch));

						List<String> notificationTokenList = dataObjectList.Select(da => da.DataAccountToken).ToList();
						((List<DataObject>)dataObjectList).RemoveRange(0, numBatch);
						Int32 maxData = workObjectList.Max(da => da.DataId);

						WinForm.Manager.InfoManager.UpdateMaxData(index, maxData);
						WinForm.Manager.NotificationManager.ProcessList(notificationTokenList, messageText, index);

						//Int32 number = WinForm.Manager.NumberManager.Generate(1);
						//System.Threading.Thread.Sleep((index + number) + MainApplication.Static.Constants.THREAD_SLEEP);

						percent += numBatch;
						WinForm.Manager.InfoManager.UpdatePercent(index, percent);

						if (0 == percent % increment)
						{
							// Defend against potential Division by Zero exception.
							float percentage = 0;
							if (0 != totalng)
							{
								percentage = (float)percent / totalng;
							}

							String message = String.Format("progress [{0}/{1}={2:0.00}]", percent, totalng, percentage);
							WinForm.Manager.LogManager.Debug(index, message);
						}
					}

					if (dataObjectList.Count <= 0)
					{
						// Defend against potential Division by Zero exception.
						float percentage = 0;
						if (0 != totalng)
						{
							percentage = (float)percent / totalng;
						}

						String message = String.Format("progress [{0}/{1}={2:0.00}]", percent, totalng, percentage);
						WinForm.Manager.LogManager.Debug(index, message);
						break;
					}
				}
			}

			WinForm.Manager.LogManager.Info(index, "stop! working..." + index);
		}

	}
}