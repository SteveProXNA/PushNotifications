using System.Collections.Generic;
using MainApplication.Domain;
using MainApplication.Managers;
using NUnit.Framework;

namespace MainApplication.UnitTests.Managers
{
	[TestFixture]
	public class InfoManagerUnitTests : BaseUnitTests
	{
		[SetUp]
		public new void SetUp()
		{
			// System under test.
			InfoManager = new InfoManager();
			InfoManager.Initialize();
			base.SetUp();
		}

		[Test]
		public void SplitTest()
		{
			// Arrange.
			IList<DataObject> dataObjectList = GetDataObjectList();

			// Act.
			InfoManager.Split(dataObjectList);

			// Assert.
			Assert.That(10, Is.EqualTo(InfoManager.ItemObjectList.Length));

			Assert.That(5, Is.EqualTo(InfoManager.ItemObjectList[0].Count));
			Assert.That(5, Is.EqualTo(InfoManager.ItemObjectList[1].Count));
			Assert.That(5, Is.EqualTo(InfoManager.ItemObjectList[2].Count));
			Assert.That(5, Is.EqualTo(InfoManager.ItemObjectList[3].Count));
			Assert.That(5, Is.EqualTo(InfoManager.ItemObjectList[4].Count));
			Assert.That(5, Is.EqualTo(InfoManager.ItemObjectList[5].Count));
			Assert.That(5, Is.EqualTo(InfoManager.ItemObjectList[6].Count));
			Assert.That(5, Is.EqualTo(InfoManager.ItemObjectList[7].Count));
			Assert.That(5, Is.EqualTo(InfoManager.ItemObjectList[8].Count));
			Assert.That(5, Is.EqualTo(InfoManager.ItemObjectList[9].Count));
		}

		[Test]
		public void TokenTest()
		{
			// Arrange.
			IList<DataObject> dataObjectList = GetDataObjectList();

			// Act.
			InfoManager.Token(dataObjectList);

			// Assert.
			Assert.That(50, Is.EqualTo(InfoManager.TokenStringList.Count));
			Assert.That("a95710564a697882756d2ce4a1b0d79a0ad44a97e5dd713c6b61027138531802", Is.EqualTo(InfoManager.TokenStringList[0]));
		}

		[TearDown]
		public void TearDown()
		{
			InfoManager = null;
		}

		#region Data Object List.
		private static IList<DataObject> GetDataObjectList()
		{
			return new List<DataObject>
			{
				new DataObject(1, 4, "a95710564a697882756d2ce4a1b0d79a0ad44a97e5dd713c6b61027138531802"),
				new DataObject(2, 4, "0c489b215a72b2d0eeccd35c9df2b0e61de80880091fa9f0fa00fe54472d4d1c"),
				new DataObject(3, 4, "5f4b58a840c1807731884996c27dc909d3eef2d91e3be3152ba74601b43ede25"),
				new DataObject(4, 4, "99dbc05917d1b98fd3a3d48e10492fd6dec7ab23bca6c8497d7daf0160210948"),
				new DataObject(5, 4, "c001bf5466a1b2277bcaa1a6ffa6954eccdc70a92b5fcfb54dc0576c0bae8822"),
				new DataObject(6, 4, "5cefe2419424ef237854b1a30be6e8e6d94a8bd4d376fd7157c0e87af770d9b1"),
				new DataObject(7, 4, "8456d952c670c35577b3fb40090f16abf5fd0f1ca1baad26a941a6b0015c9a07"),
				new DataObject(8, 4, "b5aea75f6c17c0f38b05762d08de2b62d3552409cba9bb6afbdf234fa01c8907"),
				new DataObject(9, 4, "0b9ffb07ec789cf69bf84f03c12fbf98a46db0a8765c4d43ebdabf54241d6ff2"),
				new DataObject(10, 4, "9a720ff5c8310f1ca24c96f65eab2a710e576ca72fe14af5adf1ac91b8e5dcf7"),
				new DataObject(11, 4, "8788d77c52b2ac6d1e05a4d9c97850992ee4657e939e63edcf6b95b73e216968"),
				new DataObject(12, 4, "34ca26f1bac4e773547e104707629025f5ddd8f1f5e46119a903cc3ea494fb83"),
				new DataObject(13, 4, "5a41e0a988122cc35cae1c27edabed98661855a53fc6cedb7e0790f4def9ca99"),
				new DataObject(14, 4, "e45126ebec29fa704949fc4a6a122406fc3a4e9e1f87a2a7c3c33b89e270cb26"),
				new DataObject(15, 4, "71dc783194c6af7db9302e57e0dea53fcb44ad942f7cb67df3eb835566569cf4"),
				new DataObject(16, 4, "0505e45b3aeb4f2c7603b7030e091ff551dd8483404b272590b40ef1449f172e"),
				new DataObject(17, 4, "815e1c93c40b35b283d1d4b4887cf28711728abeda1e3edfdb0ae0a4d96083e9"),
				new DataObject(18, 4, "ca161c752cc307291dc89685617258311b023d9120ac2ccdcd5313706df21a3b"),
				new DataObject(19, 4, "5c31ae5e473e4a750711734372810013c0eb2fd1ab74a4dee7e2ca303e808cca"),
				new DataObject(20, 4, "95f5d5e284f9a4c0a2e7c64f56003bb544ed55edbca92c1f208fb0810e4288df"),
				new DataObject(21, 4, "c216d9222b63121098071d6b47665ea50a269a03b225a6d097f94483ad7aac56"),
				new DataObject(22, 4, "45caf05ea22444a46ef3d8b75571d6c66757ca5caa0fa225527b2916ec4cfec0"),
				new DataObject(23, 4, "2b41ed005b6e446189ea38ad1f143548813275a3d2e3cdebc5e6acc6a003c74d"),
				new DataObject(24, 4, "d5f6042581960e2567b311de62d6b5d6eec755033ec7631186777033c2b56016"),
				new DataObject(25, 4, "523e0645e4869ddd2f0423994f0a5c8dbe058a8af2cb90cf12da52e757b9a470"),
				new DataObject(26, 4, "407e41c1504592ac843644586133e358d888f7f764179d9cd6b8a0e667b0073c"),
				new DataObject(27, 4, "73a4ad8b13af6bb1873dd05a9d71a13867798f6ca8c9f37b7399f2ba519252d7"),
				new DataObject(28, 4, "73a4ad8b13af6bb1873dd05a9d71a13867798f6ca8c9f37b7399f2ba519252d7"),
				new DataObject(29, 4, "ac980103da06a987f44fe19e5a8bd03c8d9172322af884fbb0dc828ef59e4e63"),
				new DataObject(30, 4, "39ade900e8bb54b34d7495522d6ecb8ee1bd9b8036f291ad501fad47d8265a8f"),
				new DataObject(31, 4, "c613edd7a07708783aa11b0ea0158fdd2bfc26d98394e17d0d3b9ba9b28d73eb"),
				new DataObject(32, 4, "83b8469af6502ea3694efa8be23dad20441ed3b3df21247d06156a660ff5d3e4"),
				new DataObject(33, 4, "f15135b2641538a77356de9f03e09bda79d5a6cdd45f69a7062bcb8170514525"),
				new DataObject(34, 4, "0e0ff01c846fff01aee2b000d4be5242188cab6ba3f801eea1e9349c90ac7ed2"),
				new DataObject(35, 4, "58422c5a42ced3a163cf4d4627e921939be51c7e574a90922a7d8a936c8a1942"),
				new DataObject(36, 4, "5a6ba9285a9fd0d01215f0635775a86e84307794bd9e3eb6cada2db65775268c"),
				new DataObject(37, 4, "28bd75090b378bf757e9bd452dcb91fd8852a43fb4c4d3d14d3cb1cf7459103a"),
				new DataObject(38, 4, "0bf3d58d934a4f318cef82867d21b09466e473c74a7fe4a466888d0efced3875"),
				new DataObject(39, 4, "cc36b9b966ff9672cc05c2ad0039e75c8811ee0c651a7325884bc68e71a0caab"),
				new DataObject(40, 4, "b8a8d6d52edd55ff57b21ce180df39abe14f6352a785c5d4fb815dfa991dace6"),
				new DataObject(41, 4, "3dcfc0f2815caf2912ad0044306f64d9613ab5512be5253f7d903dcf19de3990"),
				new DataObject(42, 4, "0c0d33c058f5a07cde2a22c99a331f68960e1da2e30617180c59fbdaaedb048b"),
				new DataObject(43, 4, "86eb0134adaf1309f0bfd845e2f7dd761f0075062f3f63de83e0fb5d812e23a4"),
				new DataObject(44, 4, "ddbdfcf4f4d26b38c9c22b2ecdc6236956445bf7686855fa6d3c783211ca5d7f"),
				new DataObject(45, 4, "8711775b7747c0479f5598fbbe7b7a2ea6e445af860fb935d7c2324f4e32f027"),
				new DataObject(46, 4, "bb828d82414a33bfdb99239b875373718b6d01f83123beae0ac9920c3398b052"),
				new DataObject(47, 4, "4f46ed714e361438aebc18af1ccc871b4fe23f460e804796db9fa390b7e6372e"),
				new DataObject(48, 4, "bae313a61c5ce83ecd688d68f0e0477207a23bac20ed7617132a4ecd5728aee8"),
				new DataObject(49, 4, "b5a0294f39bf248b3f4a07fd2af95ad7017c2f5b676fe86a1c8eea1afe0cf721"),
				new DataObject(50, 4, "ac35a0aa373d7cde000f9d6f09210db91fffabbfb7e0a91b407cf9fc1a24d945"),
			};
		}
		#endregion
	}
}