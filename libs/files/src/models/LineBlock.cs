//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LineBlock
    {
        [MethodImpl(Inline), Op]
        public static LineBlock create(in TextArea area, TextLine[] lines)
            => new LineBlock(area,lines);

        public readonly TextArea Area;

        public readonly Index<TextLine> Lines;

        [MethodImpl(Inline)]
        public LineBlock(TextArea area, TextLine[] lines)
        {
            Area = area;
            Lines = lines;
        }
    }
}