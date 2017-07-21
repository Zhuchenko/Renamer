using Microsoft.VisualStudio.TestTools.UnitTesting;
using RenamerMP3Library;

namespace RenamerUnitTest
{
    [TestClass]
    public class FilePathTest
    {
        [TestMethod]
        public void SuccessfulCreation()
        {
            var path = "C:\\Users\\Somebody\\Documents\\";
            var name = "mp3File";
            var extension = "mp3";
            
            var fullPath = path + name + '.' + extension;

            FilePath actual = new FilePath(fullPath);

            Assert.AreEqual(path, actual.Path);

            Assert.AreEqual(name, actual.Name);

            Assert.AreEqual(extension, actual.Extension);

            Assert.AreEqual(fullPath, actual.Full);
        }

        [TestMethod]
        public void SuccessfulChangeName()
        {
            var path = "C:\\Users\\Somebody\\Documents\\";
            var name = "mp3File";
            var extension = "mp3";

            var fullPath = path + name + '.' + extension;

            FilePath actual = new FilePath(fullPath);

            var newName = "newName";

            actual.ChangeName(newName);

            var expected = path + newName + '.' + extension;

            Assert.AreEqual(newName, actual.Name);

            Assert.AreEqual(expected, actual.Full);
        }
    }
}
