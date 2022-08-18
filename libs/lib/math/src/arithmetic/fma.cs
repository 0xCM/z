//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class math
    {
        [MethodImpl(Inline), Fma]
        public static sbyte fma(sbyte x, sbyte y, sbyte z)
            => (sbyte)(x*y + z);

        [MethodImpl(Inline), Fma]
        public static byte fma(byte x, byte y, byte z)
            => (byte)(x*y + z);

        [MethodImpl(Inline), Fma]
        public static short fma(short x, short y, short z)
            => (short)(x*y + z);

        [MethodImpl(Inline), Fma]
        public static ushort fma(ushort x, ushort y, ushort z)
            => (ushort)(x*y + z);

        [MethodImpl(Inline), Fma]
        public static int fma(int x, int y, int z)
            => x*y + z;

        [MethodImpl(Inline), Fma]
        public static uint fma(uint x, uint y, uint z)
            => x*y + z;

        [MethodImpl(Inline), Fma]
        public static long fma(long x, long y, long z)
            => x*y + z;

        [MethodImpl(Inline), Fma]
        public static ulong fma(ulong x, ulong y, ulong z)
            => x*y + z;

        [MethodImpl(Inline), Fma]
        public static float fma(float x, float y, float z)
            => MathF.FusedMultiplyAdd(x, y, z);

        [MethodImpl(Inline), Fma]
        public static double fma(double x, double y, double z)
            => Math.FusedMultiplyAdd(x, y, z);
    }
}