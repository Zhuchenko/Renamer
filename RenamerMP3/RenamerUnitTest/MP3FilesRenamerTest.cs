using Microsoft.VisualStudio.TestTools.UnitTesting;
using RenamerMP3Library;
using RenamerMP3Library.Renamer;

namespace RenamerUnitTest
{
    [TestClass]
    public class MP3FilesRenamerTest
    {
        [TestMethod]
        public void AllToTagSuccessful()
        {
            var successful = 4;
            var failed = 0;

            var finder = FinderBuilder.BuildForToTag(successful, failed);

            var renamer = new ToTagRenamer();

            var mp3FilesRenamer = new MP3FilesRenamer(finder, renamer);

            var actual = mp3FilesRenamer.Rename();
            var expected = new[] { successful, failed };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AllToFileNameSuccessful()
        {
            var successful = 4;
            var failed = 0;

            var finder = FinderBuilder.BuildForToFileName(successful, failed);

            var renamer = new ToFileNameRenamer();

            var mp3FilesRenamer = new MP3FilesRenamer(finder, renamer);

            var actual = mp3FilesRenamer.Rename();
            var expected = new[] { successful, failed };

            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void NotAllToTagSuccessful()
        {
            var successful = 4;
            var failed = 3;

            var finder = FinderBuilder.BuildForToTag(successful, failed);

            var renamer = new ToTagRenamer();

            var mp3FilesRenamer = new MP3FilesRenamer(finder, renamer);

            var actual = mp3FilesRenamer.Rename();
            var expected = new[] { successful, failed };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NotAllToFileNameSuccessful()
        {
            var successful = 4;
            var failed = 3;

            var finder = FinderBuilder.BuildForToFileName(successful, failed);

            var renamer = new ToFileNameRenamer();

            var mp3FilesRenamer = new MP3FilesRenamer(finder, renamer);

            var actual = mp3FilesRenamer.Rename();
            var expected = new[] { successful, failed };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
