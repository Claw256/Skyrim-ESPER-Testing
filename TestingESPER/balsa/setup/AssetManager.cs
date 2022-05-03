using System.Text;
using TestingESPER.balsa.archives;
using TestingESPER.balsa.shared;
using TestingESPER.balsa.stringtables;

namespace TestingESPER.balsa.setup;

public class AssetManager
{
    private static readonly string[] stringTableExtensions =
    {
        ".strings", ".ilstrings", ".dlstrings"
    };

    public readonly Game game;
    internal Type archiveFileType;
    public List<FileContainer> containers;
    internal Type stringFileType;

    public AssetManager(Game game)
    {
        this.game = game;
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var prefix = $"balsa.archives.{game.abbreviation}";
        archiveFileType = Type.GetType($"{prefix}ArchiveFile");
        prefix = $"balsa.stringtables.{game.abbreviation}";
        stringFileType = Type.GetType($"{prefix}StringFile");
        containers = new List<FileContainer>();
    }

    public ArchiveFile LoadArchive(string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        var archive = (ArchiveFile) Activator.CreateInstance(
            archiveFileType, fileName);
        new ArchiveFileSource(filePath, archive);
        archive.ReadHeader();
        archive.ReadBody();
        containers.Add(archive);
        return archive;
    }

    public StringFile LoadStrings(string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        var stringFile = (StringFile) Activator.CreateInstance(
            stringFileType, fileName);
        new StringFileSource(filePath, stringFile);
        stringFile.ReadHeader();
        stringFile.ReadBody();
        return stringFile;
    }

    public List<string> GetLoadedContainers()
    {
        return containers.Select(fc => fc.path).ToList();
    }

    public FolderContainer LoadFolder(string path)
    {
        var folder = new FolderContainer(path);
        containers.Add(folder);
        return folder;
    }

    public List<string> EnumerateEntries(string folderPath)
    {
        return containers.SelectMany(container => { return container.EnumerateEntries(folderPath); }).ToList();
    }

    public Dictionary<string, List<string>> GetStringTables()
    {
        var m = new Dictionary<string, List<string>>();
        EnumerateEntries(@"strings\").ForEach(filePath =>
        {
            var ext = Path.GetExtension(filePath);
            if (!stringTableExtensions.Contains(ext)) return;
            var key = Path.GetFileNameWithoutExtension(filePath);
            if (!m.ContainsKey(key)) m.Add(key, new List<string>());
            m[key].Add(filePath);
        });
        return m;
    }

    public void BuildArchive(string outputPath, List<string> filePaths)
    {
        // ?
    }

    public byte[] GetTextureData(string filePath)
    {
        // ?
        return null;
    }
}