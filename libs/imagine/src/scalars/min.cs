//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Scalars
    {
        [MethodImpl(Inline), Op]
        public static sbyte min(sbyte a, sbyte b)
            => a < b ? a : b;

        [MethodImpl(Inline), Op]
        public static byte min(byte a, byte b)
            => a < b ? a : b;

        [MethodImpl(Inline), Op]
        public static short min(short a, short b)
            => a < b ? a : b;

        [MethodImpl(Inline), Op]
        public static ushort min(ushort a, ushort b)
            => a < b ? a : b;

        [MethodImpl(Inline), Op]
        public static int min(int a, int b)
            => a < b ? a : b;

        [MethodImpl(Inline), Op]
        public static uint min(uint a, uint b)
            => a < b ? a : b;

        [MethodImpl(Inline), Op]
        public static long min(long a, long b)
            => a < b ? a : b;

        [MethodImpl(Inline), Op]
        public static ulong min(ulong a, ulong b)
            => a < b ? a : b;

        [MethodImpl(Inline), Op]
        public static float min(float a, float b)
            => a < b ? a : b;

        [MethodImpl(Inline), Op]
        public static double min(double a, double b)
            => a < b ? a : b;
    }
}