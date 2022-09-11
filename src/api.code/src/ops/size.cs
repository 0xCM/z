//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCode
    {
        [MethodImpl(Inline), Op]
        public static ByteSize size(ReadOnlySpan<HexDataRow> src)
        {
            var dst = 0ul;
            for(var i=0; i<src.Length; i++)
                dst += skip(src,i).Data.Count;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteSize size(ReadOnlySpan<BinaryCode> src)
        {
            var dst = 0ul;
            for(var i=0; i<src.Length; i++)
                dst += skip(src,i).Count;
            return dst;
        }
    }
}