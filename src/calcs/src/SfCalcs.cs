//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiClassKind;

    [ApiHost]
    public class SfCalcs
    {
        [MethodImpl(Inline), Factory(BitClear), Closures(Integers)]
        public static VBitClear128<T> vbitclear<T>(N128 w)
            where T : unmanaged
                => default(VBitClear128<T>);

        [MethodImpl(Inline), Factory(BitClear), Closures(Integers)]
        public static VBitClear256<T> vbitclear<T>(N256 w)
            where T : unmanaged
                => default(VBitClear256<T>);

        [Closures(Integers)]
        public readonly struct VBitClear128<T> : IUnaryImm8x2Op128D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector128<T> Invoke(Vector128<T> x, byte offset, byte count)
                => vmask.vdisable(x,offset,count);

            [MethodImpl(Inline)]
            public T Invoke(T a, byte b, byte c)
                => gbits.trim(a, b, c);
        }

        [Closures(Integers)]
        public readonly struct VBitClear256<T> : IUnaryImm8x2Op256D<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public Vector256<T> Invoke(Vector256<T> x, byte offset, byte count)
                => vmask.vdisable(x,offset,count);

            [MethodImpl(Inline)]
            public T Invoke(T a, byte b, byte c)
                => gbits.trim(a, b, c);
        }

    }
}
