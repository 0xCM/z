//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Gated;

    [ApiHost]
    public readonly struct HalfAdder : IHalfAdder
    {
        [MethodImpl(Inline), Op]
        public ConstPair<bit> Invoke(bit a, bit b)
            => (xor().Invoke(a, b), and().Invoke(a, b));

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public ConstPair<T> Invoke<T>(T a, T b)
            where T : unmanaged
                => half<T>().Invoke(a,b);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public ConstPair<Vector128<T>> Invoke<T>(Vector128<T> a, Vector128<T> b)
            where T : unmanaged
                => half<T>().Invoke(a,b);

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public ConstPair<Vector256<T>> Invoke<T>(Vector256<T> a, Vector256<T> b)
            where T : unmanaged
                => half<T>().Invoke(a,b);
    }
}