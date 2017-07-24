using RenamerMP3Library.File;

namespace RenamerUnitTest
{
    public class MP3FileForTest : IMP3File
    {
        private string _name;
        private string _artist;
        private string _title;

        private string _newName;
        private string _newArtist;
        private string _newTitle;

        public MP3FileForTest(string name = "", string artist = "", string title = "")
        {
            _name = name;
            _artist = artist;
            _title = title;

            _newName = null;
            _newArtist = null;
            _newTitle = null;
        }

        public string Name
        {
            get
            {
                return (_newName != null) ? _newName : _name;
            }

            set
            {
                _newName = value;
            }
        }

        public string Artist
        {
            get
            {
                return (_newArtist != null) ? _newArtist : _artist;
            }

            set
            {
                _newArtist = value;
            }
        }

        public string Title
        {
            get
            {
                return (_newTitle != null) ? _newTitle : _title;
            }

            set
            {
                _newTitle = value;
            }
        }

        public void SaveChanges()
        {
            if (_newName != null)
            {
                _name = _newName;
                _newName = null;
            }

            if (_newArtist != null)
            {
                _artist = _newArtist;
                _newArtist = null;
            }

            if (_newTitle != null)
            {
                _title = _newTitle;
                _newTitle = null;
            }
        }
    }
}
