//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct LineBlocks
    {
        [MethodImpl(Inline), Op]
        public static LineBlocks create(TextArea[] areas, TextLine[] lines)
            => new LineBlocks(areas, lines);

        public readonly Index<TextArea> Areas;

        readonly Index<TextLine> _Lines;

        [MethodImpl(Inline)]
        public LineBlocks(TextArea[] areas, TextLine[] lines)
        {
            Areas = areas;
            _Lines = lines;
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<TextLine> Lines(uint index)
        {
            ref readonly var area = ref Areas[index];
            var i = area.MinLine - 1;
            var j = area.MaxLine - 1;
            return core.segment(_Lines.View, i, j);
        }
    }
}