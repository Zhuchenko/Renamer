using RenamerMP3Library.File;
using System;

namespace RenamerMP3Library
{
    public class ToFileNameRenamer : IRenamer
    {
        public bool Rename(IMP3File file)
        {
            var artist = file.Artist;
            var title = file.Title;

            if (String.IsNullOrEmpty(artist) || String.IsNullOrEmpty(title))
            {
                return false;
            }

            var newName = artist + " - " + title;

            file.Name = newName;

            file.SaveChanges();

            return true;
        }
    }
}
