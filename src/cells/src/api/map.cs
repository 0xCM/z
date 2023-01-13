//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Cells
    {
        [MethodImpl(Inline)]
        public static Cells<T> map<S,T>(S src, Func<S,T> f)
            where S : ICellSeq<S>
        {
            var count = (uint)src.Length;
            var dst = sys.alloc<T>(count);
            ref readonly var current = ref src.First;
            ref var target = ref sys.first(dst);
            for(var i= 0u; i<count; i++)
                sys.seek(target,i) = f(sys.skip(src,i));
            return dst;
        }
    }
}