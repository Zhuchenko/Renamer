using RenamerMP3Library.File;

namespace RenamerMP3Library
{
    public class MP3File: IMP3File
    {
        private FilePath _path;
        private TagLib.File _tagFile;

        public MP3File(string path)
        {
            _path = new FilePath(path);
            _tagFile = TagLib.File.Create(path);
        }
       
        public void ChangeName(string newName)
        {
            var oldFullPath = _path.Full;
            _path.ChangeName(newName);

            var newFullPath = _path.Full;
            System.IO.File.Move(oldFullPath, newFullPath);
        }

        public void ChangeTags(string artist, string title)
        {
            _tagFile.Tag.Performers[0] = artist;
            _tagFile.Tag.Title = title;

            _tagFile.Save();
        }

        public string GetName()
        {
            return _path.Name;
        }

        public string GetArtistTag()
        {
            return _tagFile.Tag.Performers[0];
        }

        public string GetTitleTag()
        {
            return _tagFile.Tag.Title;
        }
    }
}
