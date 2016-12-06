using MainApplication.Static;
using NUnit.Framework;

namespace MainApplication.SystemTests.Managers
{
	[TestFixture]
	public class ConfigManagerSystemTests : BaseSystemTests
	{
		[SetUp]
		public void SetUp()
		{
			// System under test.
			ConfigManager = WinForm.Manager.ConfigManager;
		}

		[Test]
		public void InitializeTest()
		{
			ConfigManager.Initialize();

			Assert.That(ConfigManager.PlatformType, Is.EqualTo(PlatformType.iOS));
			Assert.That(ConfigManager.SendMessage, Is.False);
			Assert.That(ConfigManager.MaxBatch, Is.EqualTo(20));
			Assert.That(ConfigManager.CommandTimeout, Is.EqualTo(600));
			Assert.That(ConfigManager.ConnectionString, Is.Not.Null);
		}

		[TearDown]
		public void TearDown()
		{
			ConfigManager = null;
		}

	}
}