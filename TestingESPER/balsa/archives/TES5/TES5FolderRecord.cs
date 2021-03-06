namespace TestingESPER.balsa.archives.TES5;

public class TES5FolderRecord : FolderRecord
{
    public static TES5FolderRecord Read(ArchiveFile archive)
    {
        var source = archive.source;
        return new TES5FolderRecord
        {
            hash = source.reader.ReadBytes(8),
            fileCount = source.reader.ReadUInt32(),
            offset = source.reader.ReadUInt32(),
            archive = archive
        };
    }
}