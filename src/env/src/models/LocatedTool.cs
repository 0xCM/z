//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public sealed record class LocatedTool : IDataType<LocatedTool>
{    
    public readonly uint Seq;

    public readonly FilePath Path;

    public LocatedTool(uint seq, FilePath path)
    {
        Seq = seq;
        Path = path;
    }
    
    public string Name
    {
        [MethodImpl(Inline)]
        get => Path.FileName.WithoutExtension.Format();
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => (Hash32)Seq | Path.Hash;
    }

    public override int GetHashCode()
        => Hash;

    public string Format()
        => Path.Format();

    public override string ToString()
        => Format();
    public int CompareTo(LocatedTool src)
    {
        var result = Path.CompareTo(src.Path);

        if(result == 0)
            result = Seq.CompareTo(src.Seq);
        return result;
    }
    
    public bool Equals(LocatedTool src)
        => Seq == src.Seq && Path == src.Path;

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => Path.IsEmpty;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => Path.IsNonEmpty;
    }

    public static LocatedTool Empty => new (0u,FilePath.Empty);
}
