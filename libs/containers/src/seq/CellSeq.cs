//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public static class CellSeq
    {
        [MethodImpl(Inline)]
        public static T[] Select<S,T>(this S src, Func<S,T> f)
            where S : ICellSeq<S>
        {
            var count = (uint)src.Length;
            var dst = alloc<T>(count);
            ref readonly var current = ref src.First;
            ref var target = ref first(dst);
            for(var i= 0u; i<count; i++)
                seek(target,i) = f(skip(src,i));
            return dst;
        }
    }
}