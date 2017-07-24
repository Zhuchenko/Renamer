using RenamerMP3Library.File;

namespace RenamerMP3Library.Renamer
{
    public class MP3FilesRenamingProcessor
    {
        private IFileFinder _finder;
        private IRenamer _renamer;

        public MP3FilesRenamingProcessor(IFileFinder finder, IRenamer renamer)
        {
            _finder = finder;
            _renamer = renamer;
        }

        public int[] Rename()
        {
            int successful = 0;
            int failed = 0;

            foreach (var file in _finder.GetAllFiles())
            {
                if (_renamer.Rename(file))
                {
                    successful++;
                }
                else failed++;
            }

            return new[] { successful, failed };
        }
    }
}
