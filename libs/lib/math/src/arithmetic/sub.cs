//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        [MethodImpl(Inline), Sub]
        public static sbyte sub(sbyte a, sbyte b)
            => (sbyte)(a - b);

        [MethodImpl(Inline), Sub]
        public static byte sub(byte a, byte b)
            => (byte)(a - b);

        [MethodImpl(Inline), Sub]
        public static short sub(short a, short b)
            => (short)(a - b);

        [MethodImpl(Inline), Sub]
        public static ushort sub(ushort a, ushort b)
            => (ushort)(a - b);

        [MethodImpl(Inline), Sub]
        public static int sub(int a, int b)
            => a - b;

        [MethodImpl(Inline), Sub]
        public static uint sub(uint a, uint b)
            => a - b;

        [MethodImpl(Inline), Sub]
        public static long sub(long a, long b)
            => a - b;

        [MethodImpl(Inline), Sub]
        public static ulong sub(ulong a, ulong b)
            => a - b;
    }
}