namespace TestingESPER.balsa.stringtables.TES5;

public class TES5DirectoryEntry
{
    internal uint id;
    internal uint offset;
    internal TES5StringFile stringFile;

    internal StringFileSource source => stringFile.source;

    public string data
    {
        get
        {
            source.stream.Position = stringFile.dataOffset + offset;
            return source.ReadString(stringFile.prefixLength);
        }
    }

    public static TES5DirectoryEntry Read(TES5StringFile file)
    {
        var source = file.source;
        return new TES5DirectoryEntry
        {
            stringFile = file,
            id = source.reader.ReadUInt32(),
            offset = source.reader.ReadUInt32()
        };
    }
}