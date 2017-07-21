using RenamerMP3Library.File;

namespace RenamerMP3Library
{
    public interface IRenamer
    {
        bool Rename(IMP3File file);
    }
}
