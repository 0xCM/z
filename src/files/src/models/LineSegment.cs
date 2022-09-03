//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a segment of a number-identified line
    /// </summary>
    [StructLayout(LayoutKind.Sequential), DataTypeAttributeD("line.segment")]
    public readonly struct LineSegment
    {
        const string RenderPattern = "{0}[{1},{2}]";

        public readonly LineNumber LineNumber;

        public readonly ushort MinCol;

        public readonly ushort MaxCol;

        [MethodImpl(Inline)]
        public LineSegment(uint line, ushort min, ushort max)
        {
            LineNumber = line;
            MinCol = min;
            MaxCol = max;
        }

        public string Format()
            => string.Format(RenderPattern, LineNumber, MinCol, MaxCol);

        public override string ToString()
            => Format();
    }
}