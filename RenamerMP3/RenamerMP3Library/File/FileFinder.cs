using RenamerMP3Library.File;
using System.Collections.Generic;
using System.IO;

namespace RenamerMP3Library
{
    public class FileFinder: IFileFinder
    {
        private string _directory;
        private bool _recirsive;
        private string _pattern;

        public FileFinder(string directory, bool recursive, string pattern)
        {
            _directory = directory;
            _recirsive = recursive;
            _pattern = pattern;
        }

        public IEnumerable<IMP3File> GetAllFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(_directory);

            var option = _recirsive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            foreach (FileInfo file in dir.GetFiles(_pattern, option))
            {
                yield return new MP3File(file.FullName);
            }
        }
    }
}
