using RenamerMP3Library.File;
using System;

namespace RenamerUnitTest
{
    public static class FinderBuilder
    {
        public static IFileFinder BuildForToTag(int successful, int failed)
        {
            int numberOfFiles = successful + failed;
            IMP3File[] files = new IMP3File[numberOfFiles];

            for (int i = 0; i < successful; i++)
            {
                var name = String.Format("Artist{0} - Song{0}", i);
                files[i] = new MP3FileForTest(name: name);
            }

            for (int i = successful; i < numberOfFiles; i++)
            {
                files[i] = new MP3FileForTest(name: "IncorrectName");
            }

            return new FileFinderForTest(files);
        }

        public static IFileFinder BuildForToFileName(int successful, int failed)
        {
            int numberOfFiles = successful + failed;
            IMP3File[] files = new IMP3File[numberOfFiles];

            for (int i = 0; i < successful; i++)
            {
                var artist = "Artist" + i;
                var title = "Song" + i;
                files[i] = new MP3FileForTest(artist: artist, title: title);
            }

            for (int i = successful; i < numberOfFiles; i++)
            {
                var artist = "";
                var title = "";

                if (i % 2 == 0)
                    artist = "Artist" + i;
                else title = "Song" + i;

                files[i] = new MP3FileForTest(artist: artist, title: title);
            }

            return new FileFinderForTest(files);
        }
    }
}
