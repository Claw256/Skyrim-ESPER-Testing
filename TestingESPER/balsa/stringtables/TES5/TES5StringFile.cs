namespace TestingESPER.balsa.stringtables.TES5;

public class TES5StringFile : StringFile
{
    internal uint count;
    internal long dataOffset;
    internal uint dataSize;
    internal TES5DirectoryEntry[] directoryEntries;

    public TES5StringFile(string filename) : base(filename)
    {
    }

    internal override void ReadHeader()
    {
        count = source.reader.ReadUInt32();
        dataSize = source.reader.ReadUInt32();
    }

    internal override void ReadBody()
    {
        directoryEntries = new TES5DirectoryEntry[count];
        for (var i = 0; i < count; i++)
            directoryEntries[i] = TES5DirectoryEntry.Read(this);
        dataOffset = source.stream.Position;
    }

    internal override Dictionary<uint, string> GetStrings()
    {
        var strings = new Dictionary<uint, string>();
        for (var i = 0; i < count; i++)
        {
            var entry = directoryEntries[i];
            strings.Add(entry.id, entry.data);
        }

        return strings;
    }
}