//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class MemDb
    {
        [MethodImpl(Inline), Op]
        public static DbCol col(ushort pos, Name name, ReadOnlySpan<byte> widths)
            => new DbCol(pos, name, skip(widths, pos));

        [MethodImpl(Inline), Op]
        public static Index<DbCol> cols(params DbCol[] cols)
            => cols;
    }
}