using RenamerMP3Library.File;
using System;

namespace RenamerMP3Library
{
    public class ToTagRenamer : IRenamer
    {
        public bool Rename(IMP3File file)
        {
            var name = file.GetName();
            var indexOfDelimiter = name.IndexOf('-');

            if (indexOfDelimiter == -1)
            {
                return false;
            }

            var artist = name.Substring(0, indexOfDelimiter).TrimEnd(' ');
            var title = name.Substring(indexOfDelimiter + 1).TrimStart(' ');

            if (String.IsNullOrEmpty(artist) || String.IsNullOrEmpty(title))
            {
                return false;
            }

            file.ChangeTags(artist, title);

            return true;
        }
    }
}
