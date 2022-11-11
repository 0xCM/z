//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class gbits
    {
        [MethodImpl(Inline), Parse, Closures(Closure)]
        public static T parse<T>(ReadOnlySpan<char> src, byte offset, out T dst)
            where T : unmanaged
        {
            var last = math.min(width<T>(), src.Length) - 1;
            ref readonly var input = ref first(src);
            dst = default;
            for(byte i=offset, pos = 0; i<= last; i++, pos++)
                if(skip(input,i) == bit.One)
                    dst = gbits.enable(dst, pos);
            return dst;
        }
    }
}