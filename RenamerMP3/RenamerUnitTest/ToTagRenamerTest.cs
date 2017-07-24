using Microsoft.VisualStudio.TestTools.UnitTesting;
using RenamerMP3Library;

namespace RenamerUnitTest
{
    [TestClass]
    public class ToTagRenamerTest
    {
        [TestMethod]
        public void SuccessfulRenaming()
        {
            var expectedArtist = "SomeFamousArtist";
            var expectedTitle = "LovelySong";
            var name = expectedArtist + " - " + expectedTitle;

            var mp3File = new MP3FileForTest(name: name);
            var renamer = new ToTagRenamer();

            var isSuccessful = renamer.Rename(mp3File);
            Assert.IsTrue(isSuccessful);
            
            var actualArtist = mp3File.Artist;
            var actualTitle = mp3File.Title;

            Assert.AreEqual(expectedArtist, actualArtist);
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod]
        public void FailedRenaming()
        {
            var expectedArtist = "oldArtist";
            var expectedTitle = "oldName";
            var name = "someIncorrectName";

            var mp3File = new MP3FileForTest(name: name, artist: expectedArtist, title: expectedTitle);
            var renamer = new ToTagRenamer();

            var isSuccessful = renamer.Rename(mp3File);
            Assert.IsFalse(isSuccessful);

            var actualArtist = mp3File.Artist;
            var actualTitle = mp3File.Title;

            Assert.AreEqual(expectedArtist, actualArtist);
            Assert.AreEqual(expectedTitle, actualTitle);
        }
    }
}
