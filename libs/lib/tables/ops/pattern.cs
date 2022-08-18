//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Tables
    {
        public static string KvpPattern(in RowFormatSpec spec)
        {
            var slot0 = RpOps.slot(0, math.negate((short)spec.MaxCellWidth));
            var slot1 = RpOps.slot(1);
            return slot0 + Chars.Space + spec.Delimiter + Chars.Space + slot1;
        }

        [Op]
        static string slot(byte index, RenderWidth width, string delimiter = DefaultDelimiter)
            => delimiter + RpOps.slot(index, (short)(-(short)width));

        [Op]
        public static string pattern(Index<CellFormatSpec> cells, string delimiter = DefaultDelimiter)
        {
            var count = cells.Count;
            var view = cells.View;
            var parts = alloc<string>(count);
            for(var i=0u; i<count; i++)
            {
                var cell = skip(view,i);
                seek(parts,i) = slot((byte)i, cell.Width, i!=0 ? delimiter : EmptyString);
            }
            return string.Concat(parts);
        }
    }
}