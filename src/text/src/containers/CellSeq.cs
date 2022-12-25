//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

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