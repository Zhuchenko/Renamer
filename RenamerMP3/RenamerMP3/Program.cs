using RenamerMP3Library;
using RenamerMP3Library.Renamer;
using RenamerMP3Library.File;
using System;
using System.Linq;

namespace RenamerMP3
{
    class Program
    {
        static void Main(string[] args)
        {
            var finder = GetFileFinder(args);
            var renamer = GetRenamer(args.Last());

            if (finder == null || renamer == null)
            {
                Console.WriteLine("Incorrect format of input arguments");
                Console.ReadKey();
                return;
            }

            var mp3Renamer = new MP3FilesRenamingProcessor(finder, renamer);

            var output = mp3Renamer.Rename();

            Console.WriteLine("Successful: {0}\nFailed: {1}", output[0], output[1]);

            Console.ReadKey();
        }

        public static FileFinder GetFileFinder(string[] args)
        {
            var dir = args[0];
            var pattern = args[1];
            bool recursive = args[2].ToLower() == "-recursive";

            return new FileFinder(dir, recursive, pattern);
        }

        public static IRenamer GetRenamer(string arg)
        {
            var typeOfRenamer = arg.ToLower();

            if (typeOfRenamer == "-totag")
            {
                return new ToTagRenamer();
            }

            if (typeOfRenamer == "-tofilename")
            {
                return new ToFileNameRenamer();
            }

            return null;
        }
    }
}
