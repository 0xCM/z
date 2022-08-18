//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CalcHosts;
    using static SFx;
    using static ApiClassKind;

    partial struct Calcs
    {
        [MethodImpl(Inline), Factory(Byteswap), Closures(UInt16x32x64k)]
        public static ByteSwap<T> byteswap<T>()
            where T : unmanaged
                => sfunc<ByteSwap<T>>();

        [MethodImpl(Inline), Factory(Byteswap), Closures(Closure)]
        public static VByteSwap128<T> vbyteswap<T>(W128 w)
            where T : unmanaged
                => default(VByteSwap128<T>);

        [MethodImpl(Inline), Factory(Byteswap), Closures(Closure)]
        public static VByteSwap256<T> vbyteswap<T>(W256 w)
            where T : unmanaged
                => default(VByteSwap256<T>);
    }
}