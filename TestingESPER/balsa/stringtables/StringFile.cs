using System.Text;

namespace TestingESPER.balsa.stringtables;

public class StringFile
{
    private static readonly Encoding windows1252 = Encoding.GetEncoding(1252);

    private Dictionary<uint, string> _strings;

    internal string filename;
    internal int prefixLength;
    internal StringFileSource source;
    public StringFileType stringFileType;

    public StringFile(string filename)
    {
        this.filename = filename;
        var ext = Path.GetExtension(filename).ToLower();
        switch (ext)
        {
            case ".strings":
                stringFileType = StringFileType.STRINGS;
                prefixLength = 0;
                break;
            case ".ilstrings":
                stringFileType = StringFileType.ILSTRINGS;
                prefixLength = 4;
                break;
            case ".dlstrings":
                stringFileType = StringFileType.DLSTRINGS;
                prefixLength = 4;
                break;
            default:
                throw new Exception("Unknown string file extension");
        }
    }

    internal virtual Encoding encoding => windows1252;
    public string filePath => source?.filePath;

    public Dictionary<uint, string> strings
    {
        get
        {
            if (_strings == null)
                _strings = GetStrings();
            return _strings;
        }
    }

    internal virtual void ReadHeader()
    {
        throw new NotImplementedException();
    }

    internal virtual void ReadBody()
    {
        throw new NotImplementedException();
    }

    internal virtual Dictionary<uint, string> GetStrings()
    {
        throw new NotImplementedException();
    }
}