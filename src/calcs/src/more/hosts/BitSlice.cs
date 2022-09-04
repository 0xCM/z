//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(Integers)]
        public readonly struct BitSlice<T> : IUnaryImm8x2Op<T>
            where T : unmanaged
        {
            public static BitSlice<T> Op => default;

            public const string Name = "bitslice";

            public _OpIdentity Id
                => SFxIdentity.identity<T>(Name);

            public T Invoke(T a, byte k1, byte k2)
                => gbits.slice(a,k1,k2);
        }
    }
}