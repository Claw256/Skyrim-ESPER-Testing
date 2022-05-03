using System.IO.MemoryMappedFiles;
using System.Text;

namespace TestingESPER.balsa.shared;

public class FileSource
{
    private readonly MemoryMappedFile file;
    private readonly FileInfo fileInfo;
    internal readonly string filePath;
    internal readonly BinaryReader reader;
    internal readonly MemoryMappedViewStream stream;

    internal FileSource(string filePath)
    {
        this.filePath = filePath;
        fileInfo = new FileInfo(filePath);
        var baseStream = new FileStream(
            filePath, FileMode.Open,
            FileAccess.Read, FileShare.ReadWrite
        );
        file = MemoryMappedFile.CreateFromFile(
            baseStream, null, 0, MemoryMappedFileAccess.Read,
            HandleInheritability.None, false
        );
        stream = file.CreateViewStream(
            0, 0, MemoryMappedFileAccess.Read
        );
        reader = new BinaryReader(stream);
    }

    internal long fileSize => fileInfo.Length;
    internal virtual Encoding stringEncoding => throw new NotImplementedException();

    internal int ReadPrefix(int prefixLength)
    {
        switch (prefixLength)
        {
            case 1: return reader.ReadByte();
            case 2: return reader.ReadUInt16();
            case 4: return (int) reader.ReadUInt32();
        }

        throw new Exception($"Unknown prefix length {prefixLength}");
    }

    internal string ReadZString(byte terminator = 0)
    {
        var bytes = new byte[32];
        var i = 0;
        do
        {
            var b = reader.ReadByte();
            if (b == 0) break;
            if (i >= bytes.Length)
            {
                var newBytes = new byte[bytes.Length * 2];
                bytes.CopyTo(newBytes, 0);
                bytes = newBytes;
            }

            bytes[i++] = b;
        } while (true);

        if (i == 0) return string.Empty;
        return stringEncoding.GetString(bytes, 0, i);
    }

    internal string ReadBString(int len, bool nullTerminated)
    {
        var bytes = reader.ReadBytes(len);
        if (nullTerminated) len--;
        return stringEncoding.GetString(bytes, 0, len);
    }

    internal string ReadString(int prefixLength = 0, bool nullTerminated = true)
    {
        if (prefixLength > 0)
        {
            var len = ReadPrefix(prefixLength);
            return ReadBString(len, nullTerminated);
        }

        if (!nullTerminated)
            throw new Exception("Cannot read unterminated string of unknown length.");
        return ReadZString();
    }
}