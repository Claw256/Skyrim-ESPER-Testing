using System.Text;
using TestingESPER.balsa.shared;

namespace TestingESPER.balsa.stringtables;

public class StringFileSource : FileSource
{
    internal readonly StringFile stringFile;

    internal StringFileSource(string filePath, StringFile stringFile) :
        base(filePath)
    {
        this.stringFile = stringFile;
        stringFile.source = this;
    }

    internal override Encoding stringEncoding => stringFile.encoding;
}