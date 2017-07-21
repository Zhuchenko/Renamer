using System.Collections.Generic;

namespace RenamerMP3Library.File
{
    public interface IFileFinder
    {
        IEnumerable<IMP3File> GetAllFiles();
    }
}
