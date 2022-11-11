//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct Asci
    {
        [MethodImpl(Inline)]
        public static T load<T>(ReadOnlySpan<C> src, out T target)
            where T : unmanaged, IAsciBlock<T>
        {
            target = default(T);
            var count = min(src.Length,target.ByteCount);
            ref var dst = ref @as<C>(target.First);
            for(var i=0; i<count; i++)
                sys.seek(dst, i) = skip(src, i);
            return target;
        }

        [MethodImpl(Inline)]
        public static T load<T>(ReadOnlySpan<S> src, out T target)
            where T : unmanaged, IAsciBlock<T>
        {
            target = default(T);
            var count = min(src.Length,target.ByteCount);
            ref var dst = ref @as<S>(target.First);
            for(var i=0; i<count; i++)
                sys.seek(dst, i) = skip(src, i);
            return target;
        }

        public static AsciBlock<N> load<N>(S[] src, N n = default)
            where N : unmanaged, ITypeNat
        {
            Require.equal<N>(src.Length);
            return new AsciBlock<N>(src);
        }

    }
}
