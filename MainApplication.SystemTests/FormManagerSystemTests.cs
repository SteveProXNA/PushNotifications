using System.Reflection;
using NUnit.Framework;

namespace MainApplication.SystemTests
{
	[TestFixture]
	public class FormManagerSystemTests : BaseSystemTests
	{
		[Test]
		public void RegistrationTest()
		{
			var manager = WinForm.Manager;
			var properties = manager.GetType().GetProperties();

			foreach (PropertyInfo property in properties)
			{
				object obj = property.GetValue(manager, null);
				Assert.That(obj, Is.Not.Null, property.ToString(), manager);
			}
		}

	}
}