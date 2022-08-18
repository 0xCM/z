//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Clr
    {
        public static ReadOnlySpan<CliSig> sigs(MethodInfo[] src)
        {
            var count = src.Length;
            if(count==0)
                return default;

            var dst = alloc<CliSig>(count);
            sigs(src, dst);
            return dst;
        }

        [Op]
        public static void sigs(MethodInfo[] src, Span<CliSig> dst)
        {
            var k = min(count(src), count(dst));
            if(k != 0)
            {
                ref readonly var input = ref first(src);
                ref var output = ref first(dst);
                for(var i=0; i<k; i++)
                    seek(output,i) = sig(skip(input,i));
            }
        }
    }
}