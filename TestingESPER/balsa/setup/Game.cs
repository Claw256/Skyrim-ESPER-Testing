namespace TestingESPER.balsa.setup;

public class Game
{
    public string abbreviation;
    public string archiveExtension = ".bsa";
    public string baseName;
    public string fullName;
    public string name;
    public int xeditId;

    public Game InitDefaults()
    {
        if (baseName == null) baseName = name.Replace(" ", string.Empty);
        if (fullName == null) fullName = name;
        return this;
    }
}