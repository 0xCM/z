//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CalcHosts
    {
        [Closures(UInt16x32x64k)]
        public readonly struct ByteSwap<T> : IUnaryOp<T>
            where T : unmanaged
        {
            public static ByteSwap<T> Op => default;

            public const string Name = "byteswap";

            public OpIdentity Id
                => SFxIdentity.identity<T>(Name);

            [MethodImpl(Inline)]
            public T Invoke(T a)
                => gbits.byteswap(a);
        }
    }
}