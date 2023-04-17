//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct SourceLine : ISourceLine, IComparable<SourceLine>
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

        LineNumber ISourceLine.LineNumber 
            => LineNumber;

        SourceText ISourceLine.Source 
            => Source;

        public static SourceLine Empty => new SourceLine(default,SourceText.Empty);
    }
}