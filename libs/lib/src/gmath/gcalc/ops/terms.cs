//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct gcalc
    {
        [Op, Closures(Closure)]
        public static Index<SeqTerm<T>> terms<T>(ReadOnlySpan<T> src)
        {
            var count = src.Length;
            var buffer = alloc<SeqTerm<T>>(count);
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
                seek(dst,i) = new SeqTerm<T>(i,skip(src,i));
            return buffer;
        }
    }
}