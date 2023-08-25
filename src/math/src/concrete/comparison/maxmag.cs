//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        [MethodImpl(Inline), Op]
        public static byte maxmag(byte a, byte b)
            => max(a,b);

        [MethodImpl(Inline), Op]
        public static sbyte maxmag(sbyte a, sbyte b)
            => (sbyte)int.MaxMagnitude(a,b);

        [MethodImpl(Inline), Op]
        public static short maxmag(short a, short b)
            => short.MaxMagnitude(a,b);

        [MethodImpl(Inline), Op]
        public static ushort maxmag(ushort a, ushort b)
            => max(a,b);

        [MethodImpl(Inline), Op]
        public static int maxmag(int a, int b)
            => int.MaxMagnitude(a,b);

        [MethodImpl(Inline), Op]
        public static uint maxmag(uint a, uint b)
            => max(a,b);

        [MethodImpl(Inline), Op]
        public static long maxmag(long a, long b)
            => long.MaxMagnitude(a,b);

        [MethodImpl(Inline), Op]
        public static ulong maxmag(ulong a, ulong b)
            => max(a,b);

        [MethodImpl(Inline), Op]
        public static float maxmag(float a, float b)
            => float.MaxMagnitude(a,b);

        [MethodImpl(Inline), Op]
        public static double maxmag(double a, double b)
            => double.MaxMagnitude(a,b);
    }
}