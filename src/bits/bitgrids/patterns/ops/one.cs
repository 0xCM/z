//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitGrid;

    partial class GridPatterns
    {
        [MethodImpl(Inline), One, Closures(UInt8x16k)]
        public static BitGrid16<N4,N4,T> one<T>(N16 w, N4 m, N4 n, T t = default)
            where T : unmanaged
        {
            const ushort pattern = 0b1000_0100_0010_0001;
            return init(w,m,n,pattern).As<T>();
        }

        [MethodImpl(Inline), One, Closures(UInt8x16x32k)]
        public static SubGrid32<N5,N5,T> one<T>(N32 w, N5 m, N5 n, T t = default)
            where T : unmanaged
        {
            const uint pattern = 0b10000_01000_00100_00010_00001;
            return subgrid(w,pattern,m,n).As<T>();
        }

        [MethodImpl(Inline), One, Closures(UnsignedInts)]
        public static SubGrid64<N6,N6,T> one<T>(N64 w, N6 m, N6 n, T t = default)
            where T : unmanaged
        {
            const ulong pattern = 0b100000_010000_001000_000100_000010_000001;
            return subgrid(w,pattern,m,n).As<T>();
        }

        [MethodImpl(Inline), One, Closures(UnsignedInts)]
        public static SubGrid64<N7,N7,T> one<T>(N64 w, N7 m, N7 n, T t = default)
            where T : unmanaged
        {
            const ulong pattern = 0b100000_010000_0010000_0001000_0000100_0000010_0000001;
            return subgrid(w,pattern,m,n).As<T>();
        }

        [MethodImpl(Inline), One, Closures(UnsignedInts)]
        public static BitGrid64<N8,N8,T> one<T>(N64 w, N8 m, N8 n, T t = default)
            where T : unmanaged
        {
            const ulong pattern = 0b10000000_01000000_00100000_00010000_00001000_00000100_00000010_00000001;
            return init(w,m,n,pattern).As<T>();
        }

        [MethodImpl(Inline), One, Closures(UnsignedInts)]
        public static BitGrid256<N16,N16,T> one<T>(N256 w, N16 m, N16 n, T t = default)
            where T : unmanaged
        {
            var x = gcpu.vmask256<T>(BitMasks.lsb(n2, n1, z32),0);
            var offsets = gcpu.vinc<T>(w);
            var pattern = gcpu.vsllv(x,offsets);
            return pattern;
        }
    }
}