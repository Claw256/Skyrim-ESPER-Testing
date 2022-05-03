namespace TestingESPER.balsa.archives.TES5;

public class TES5ArchiveHeader
{
    public byte[] fileId { get; internal set; }
    public uint version { get; internal set; }
    public uint folderOffset { get; internal set; }
    public TES5ArchiveFlags archiveFlags { get; internal set; }
    public uint folderCount { get; internal set; }
    public uint fileCount { get; internal set; }
    public uint totalFolderNameLength { get; internal set; }
    public uint totalFileNameLength { get; internal set; }
    public TES5FileFlags fileFlags { get; internal set; }

    public static TES5ArchiveHeader Read(ArchiveFileSource source)
    {
        return new TES5ArchiveHeader
        {
            fileId = source.reader.ReadBytes(4),
            version = source.reader.ReadUInt32(),
            folderOffset = source.reader.ReadUInt32(),
            archiveFlags = TES5ArchiveFlags.Read(source),
            folderCount = source.reader.ReadUInt32(),
            fileCount = source.reader.ReadUInt32(),
            totalFolderNameLength = source.reader.ReadUInt32(),
            totalFileNameLength = source.reader.ReadUInt32(),
            fileFlags = TES5FileFlags.Read(source)
        };
    }
}