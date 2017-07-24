using RenamerMP3Library.File;

namespace RenamerMP3Library
{
    public class MP3File: IMP3File
    {
        private string _fullPath;
        private TagLib.File _tagFile;

        private string _newPath;

        public MP3File(string path)
        {
            _fullPath = path;
            _tagFile = TagLib.File.Create(path);
            _newPath = null;
        }

        public string Name
        {
            get
            {
                var currentPath = (_newPath != null) ? _newPath : _fullPath;

                var startIndexOfName = currentPath.LastIndexOf("\\") + 1;
                var lengthOfName = currentPath.LastIndexOf('.') - startIndexOfName;

                return currentPath.Substring(startIndexOfName, lengthOfName);
            }

            set 
            {
                var currentPath = (_newPath != null) ? _newPath : _fullPath;

                var lengthOfPath = currentPath.LastIndexOf("\\") + 1;
                var pathWithoutName = currentPath.Substring(0, lengthOfPath);

                var startIndexOfExtension = currentPath.LastIndexOf('.');
                var extension = currentPath.Substring(startIndexOfExtension);

                _newPath = pathWithoutName + value + extension;
            }
        }
       
        public string Artist
        {
            get
            {
                return _tagFile.Tag.Performers[0];
            }

            set
            {
                _tagFile.Tag.Performers[0] = value;
            }
        }

        public string Title
        {
            get
            {
                return _tagFile.Tag.Title;
            }

            set
            {
                _tagFile.Tag.Title = value;
            }
        }

        public void SaveChanges()
        {
            _tagFile.Save();

            if (_newPath == null)
                return;

            System.IO.File.Move(_fullPath, _newPath);
            _newPath = null;
        }
    }
}
