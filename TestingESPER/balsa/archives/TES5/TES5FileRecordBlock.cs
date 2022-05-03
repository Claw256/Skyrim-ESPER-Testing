namespace TestingESPER.balsa.archives.TES5;

public class TES5FileRecordBlock : FileRecordBlock
{
    internal static TES5FileRecordBlock Read(FolderRecord folderRecord)
    {
        var block = new TES5FileRecordBlock {folderRecord = folderRecord};
        if (block.archive.hasDirectoryNames)
            block.name = block.source.ReadString(1);
        block.fileRecords = new FileRecord[folderRecord.fileCount];
        for (var i = 0; i < folderRecord.fileCount; i++)
            block.fileRecords[i] = TES5FileRecord.Read(block);
        return block;
    }
}