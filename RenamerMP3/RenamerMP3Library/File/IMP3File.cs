namespace RenamerMP3Library.File
{
    public interface IMP3File
    {
        void ChangeName(string newName);
        void ChangeTags(string artist, string title);

        string GetName();
        string GetArtistTag();
        string GetTitleTag();
    }
}
