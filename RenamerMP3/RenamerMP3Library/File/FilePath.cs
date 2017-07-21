namespace RenamerMP3Library
{
    public class FilePath
    {
        public FilePath(string fullPath)
        {
            var lengthOfPath = fullPath.LastIndexOf("\\") + 1;
            Path = fullPath.Substring(0, lengthOfPath);

            var lengthOfName = fullPath.Length - lengthOfPath - 4;
            Name = fullPath.Substring(lengthOfPath, lengthOfName);

            var startIndexOfExtension = lengthOfPath + lengthOfName + 1;
            Extension = fullPath.Substring(startIndexOfExtension);
        }

        public string Path { get; }
        public string Name { get; private set; }
        public string Extension { get; }

        public string Full => Path + Name + '.' + Extension;

        public void ChangeName(string newName)
        {
            Name = newName;
        }
    }
}
