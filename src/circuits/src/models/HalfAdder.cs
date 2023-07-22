//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Gated;

    public readonly struct HalfAdder<T> : IHalfAdder<HalfAdder<T>,T>
        where T : unmanaged
    {
        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public ConstPair<T> Invoke(T a, T b)
            => (xor<T>().Invoke(a,b), and<T>().Invoke(a,b));

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public ConstPair<Vector128<T>> Invoke(Vector128<T> a, Vector128<T> b)
            => (xor<T>().Invoke(a,b), and<T>().Invoke(a,b));

        [MethodImpl(Inline), Op, Closures(UnsignedInts)]
        public ConstPair<Vector256<T>> Invoke(Vector256<T> a, Vector256<T> b)
            => (xor<T>().Invoke(a,b), and<T>().Invoke(a,b));
    }
}