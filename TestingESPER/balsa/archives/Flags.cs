namespace TestingESPER.balsa.archives;

public class Flags
{
    internal uint data;
    public virtual List<string> flags => throw new NotImplementedException();

    public int GetFlagIndex(string flag)
    {
        var index = flags.IndexOf(flag);
        if (index == -1) throw new Exception($"Unknown flag: {flag}");
        return index;
    }

    public bool HasFlag(string flag)
    {
        var index = GetFlagIndex(flag);
        return (data & (1 << index)) != 0;
    }

    public void SetFlag(string flag)
    {
        var index = GetFlagIndex(flag);
        data |= (uint) (1 << index);
    }
}