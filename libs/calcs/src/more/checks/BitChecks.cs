//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct BitChecks
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Closures(Closure)]
        public static ref ulong eq<T>(T x, T y, ref byte index, ref ulong dst)
            where T : unmanaged
        {
            dst = (ulong)@byte(gmath.eq(x,y)) << index++;
            return ref dst;
        }

        [MethodImpl(Inline), Closures(Closure)]
        public static bit eq<T>(T x, T y)
            where T : unmanaged
                => math.eq(bw64(x),bw64(y));

        [MethodImpl(Inline), Closures(Closure)]
        public static ulong biteq<T>(T x, T y, byte index)
            where T : unmanaged
                => (ulong)@byte(eq<T>(x,y)) << index;
    }
}
