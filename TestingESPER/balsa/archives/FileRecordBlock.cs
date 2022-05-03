namespace TestingESPER.balsa.archives;

public class FileRecordBlock
{
    internal FileRecord[] fileRecords;
    internal FolderRecord folderRecord;
    internal string name;

    internal ArchiveFile archive => folderRecord.archive;
    internal ArchiveFileSource source => folderRecord.source;

    public List<FileRecord> GetFileRecords()
    {
        return new List<FileRecord>(fileRecords);
    }
}