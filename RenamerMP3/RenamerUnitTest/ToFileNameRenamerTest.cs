using Microsoft.VisualStudio.TestTools.UnitTesting;
using RenamerMP3Library;

namespace RenamerUnitTest
{
    [TestClass]
    public class ToFileNameRenamerTest
    {
        [TestMethod]
        public void SuccessfulRenaming()
        {
            var artist = "SomeFamousArtist";
            var title = "LovelySong";

            var mp3File = new MP3FileForTest(artist: artist, title: title);
            var renamer = new ToFileNameRenamer();

            var isSuccessful = renamer.Rename(mp3File);
            Assert.IsTrue(isSuccessful);
            
            var expectedName = artist + " - " + title;
            var actual = mp3File.GetName();
            Assert.AreEqual(expectedName, actual);
        }

        [TestMethod]
        public void FailedRenaming()
        {
            var artist = "SomeFamousArtist";
            var title = "";
            var name = "oldName";

            var mp3File = new MP3FileForTest(name: name, artist: artist, title: title);
            var renamer = new ToFileNameRenamer();

            var isSuccessful = renamer.Rename(mp3File);
            Assert.IsFalse(isSuccessful);

            var expectedName = name;
            var actual = mp3File.GetName();
            Assert.AreEqual(expectedName, actual);
        }
    }
}
