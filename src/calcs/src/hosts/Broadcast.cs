//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Numeric;

    partial struct CalcHosts
    {
        [Closures(Closure)]
        public readonly struct VBroadcast128<T> : IFactory128<T,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(T a)
                => gcpu.vbroadcast(n128, a);
        }

        [Closures(Closure)]
        public readonly struct VBroadcast128<S,T> : IFactory128<S,T>
            where T : unmanaged
            where S : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(S a)
                => gcpu.vbroadcast(n128, force<S,T>(a));
        }

        [Closures(Closure)]
        public readonly struct VBroadcast256<T> : IFactory256<T,T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(T a)
                => gcpu.vbroadcast(n256, a);
        }

        [Closures(Closure)]
        public readonly struct VBroadcast256<S,T> : IFactory256<S,T>
            where T : unmanaged
            where S : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(S a)
                => gcpu.vbroadcast(n256, force<S,T>(a));
        }
    }
}