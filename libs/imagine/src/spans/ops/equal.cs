//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Spans
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool equal<T>(ReadOnlySpan<T> src, ReadOnlySpan<T> dst)
            where T : IEquatable<T>
        {
            var count = src.Length;
            if(count != dst.Length)
                return false;

            if(count == 0)
                return true;

            ref readonly var a = ref Spans.first(src);
            ref readonly var b = ref Spans.first(dst);
            for(var i=0; i<count; i++)
                if(!sys.skip(a,i).Equals(sys.skip(b,i)))
                    return false;

            return true;
        }
    }
}