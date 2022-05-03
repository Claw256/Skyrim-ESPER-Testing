using System.Text;
using TestingESPER.balsa.shared;
using TestingESPER.Ionic.Zlib;

namespace TestingESPER.balsa.archives;

public class ArchiveFileSource : FileSource
{
    internal readonly ArchiveFile archive;

    internal ArchiveFileSource(string filePath, ArchiveFile archive) :
        base(filePath)
    {
        this.archive = archive;
        archive.source = this;
    }

    internal override Encoding stringEncoding => archive.encoding;

    internal byte[] Decompress(int dataSize)
    {
        var decompressedDataSize = reader.ReadUInt32();
        var zstream = new ZlibStream(stream, CompressionMode.Decompress);
        var zreader = new BinaryReader(zstream);
        return zreader.ReadBytes((int) decompressedDataSize);
    }
}