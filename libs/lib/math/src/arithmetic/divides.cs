//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        [MethodImpl(Inline), Divides]
        public static bit divides(sbyte a, sbyte b)
            => b % a == 0;

        [MethodImpl(Inline), Divides]
        public static bit divides(byte a, byte b)
            => b % a == 0;

        [MethodImpl(Inline), Divides]
        public static bit divides(short a, short b)
            => b % a == 0;

        [MethodImpl(Inline), Divides]
        public static bit divides(ushort a, ushort b)
            => b % a == 0;

        [MethodImpl(Inline), Divides]
        public static bit divides(int a, int b)
            => b % a == 0;

        [MethodImpl(Inline), Divides]
        public static bit divides(uint a, uint b)
            => b % a == 0;

        [MethodImpl(Inline), Divides]
        public static bit divides(long a, long b)
            => b % a == 0;

        [MethodImpl(Inline), Divides]
        public static bit divides(ulong a, ulong b)
            => b % a == 0;
    }
}