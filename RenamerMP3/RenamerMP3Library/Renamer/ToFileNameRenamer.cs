using RenamerMP3Library.File;
using System;

namespace RenamerMP3Library
{
    public class ToFileNameRenamer : IRenamer
    {
        public bool Rename(IMP3File file)
        {
            var artist = file.GetArtistTag();
            var title = file.GetTitleTag();

            if (String.IsNullOrEmpty(artist) || String.IsNullOrEmpty(title))
            {
                return false;
            }

            var newName = artist + " - " + title;
            file.ChangeName(newName);

            return true;
        }
    }
}
