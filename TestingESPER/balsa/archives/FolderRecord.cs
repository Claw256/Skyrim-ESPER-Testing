namespace TestingESPER.balsa.archives;

public class FolderRecord
{
    public byte[] hash { get; internal set; }
    public uint fileCount { get; internal set; }
    public uint offset { get; internal set; }
    public ArchiveFile archive { get; internal set; }
    public FileRecordBlock fileRecordBlock { get; internal set; }

    public string name => fileRecordBlock.name;
    internal ArchiveFileSource source => archive.source;
    internal int index => archive.GetFolderRecordIndex(this);

    public IEnumerable<string> filePaths
    {
        get { return fileRecordBlock.fileRecords.Select(fileRec => { return Path.Combine(name, fileRec.fileName); }); }
    }

    internal void ExtractTo(string outputPath)
    {
        Directory.CreateDirectory(outputPath);
        Array.ForEach(fileRecordBlock.fileRecords, fileRecord => { fileRecord.ExtractTo(outputPath); });
    }

    internal FileRecord GetFileRecord(string fileName)
    {
        var fileRceord = Array.Find(fileRecordBlock.fileRecords, f => { return f.fileName == fileName; });
        if (fileRceord == null)
            throw new Exception($"Could not find file record: {fileName}");
        return fileRceord;
    }
}