//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


[StructLayout(LayoutKind.Sequential)]
public readonly record struct SourceLine : IComparable<SourceLine>
{
    public readonly LineNumber LineNumber;

    public readonly SourceText Source;

    public SourceLine(LineNumber line, SourceText src)
    {
        LineNumber = line;
        Source = src;
    }

    public string Format()
        => $"{LineNumber}:{sys.@string(Source.Cells)}";

    public override string ToString()
        => Format();

    public int CompareTo(SourceLine src)
        => LineNumber.CompareTo(src.LineNumber);


    public static SourceLine Empty => new (default,SourceText.Empty);
}
