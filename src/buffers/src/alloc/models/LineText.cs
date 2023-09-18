//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct LineText : IComparable<LineText>
{
    public readonly LineNumber LineNumber;

    public readonly SourceText Content;

    public LineText(LineNumber line, SourceText src)
    {
        LineNumber = line;
        Content = src;
    }

    public string Format()
        => $"{LineNumber}:{sys.@string(Content.Cells)}";

    public override string ToString()
        => Format();

    public int CompareTo(LineText src)
        => LineNumber.CompareTo(src.LineNumber);


    public static LineText Empty => new (default,SourceText.Empty);
}
