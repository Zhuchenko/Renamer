namespace RenamerMP3Library.File
{
    public interface IMP3File
    {
        string Name { get; set; }
        string Artist { get; set; }
        string Title { get; set; }

        void SaveChanges();
    }
}
