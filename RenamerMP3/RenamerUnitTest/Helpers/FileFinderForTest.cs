using RenamerMP3Library.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamerUnitTest
{
    class FileFinderForTest : IFileFinder
    {
        private readonly IMP3File[] _files;

        public FileFinderForTest(IEnumerable<IMP3File> files)
        {
            _files = files?.ToArray() ?? new IMP3File[0];
        }

        public IEnumerable<IMP3File> GetAllFiles()
        {
            foreach (var item in _files)
            {
                yield return item;
            }
        }
    }
}
