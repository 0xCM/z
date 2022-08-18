//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    
    using V = HexDigitValue;

    partial struct Digital
    {
        [MethodImpl(Inline), Op]
        public static byte pack(V d0, V d1)
            => (byte)((uint)d0 | ((uint)d1) << 4);

        [MethodImpl(Inline), Op]
        public static uint pack(ReadOnlySpan<V> src, Span<byte> dst)
        {
            var count = src.Length;
            var j=0u;
            if(dst.Length >= count/2 && count % 2 == 0)
            {
                for(var i=0; i<count; i+=2)
                    seek(dst,j++) = pack(skip(src,i+1), skip(src,i));
            }
            return j;
        }
    }
}