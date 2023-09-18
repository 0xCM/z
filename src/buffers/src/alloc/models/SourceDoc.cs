//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class SourceDoc : Seq<SourceDoc, LineText>, IComparable<SourceDoc>
{
    FilePath _Path;

    public static SourceDoc create(FilePath src, LineText[] lines)
    {
        var dst = create(lines);
        dst._Path = src;
        return dst;
    }

    public int CompareTo(SourceDoc src)
        => Path.CompareTo(src.Path);

    public ref readonly FilePath Path => ref _Path;
}
