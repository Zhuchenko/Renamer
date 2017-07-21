using RenamerMP3Library.File;

namespace RenamerUnitTest
{
    public class MP3FileForTest : IMP3File
    {
        private string _name;
        private string _artist;
        private string _title;

        public MP3FileForTest(string name = "", string artist = "", string title = "")
        {
            _name = name;
            _artist = artist;
            _title = title;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetArtistTag()
        {
            return _artist;
        }

        public string GetTitleTag()
        {
            return _title;
        }

        public void ChangeName(string newName)
        {
            _name = newName;
        }

        public void ChangeTags(string artist, string title)
        {
            _artist = artist;
            _title = title;
        }
    }
}
