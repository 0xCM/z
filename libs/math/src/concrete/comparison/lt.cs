//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        [MethodImpl(Inline), Lt]
        public static bit lt(sbyte a, sbyte b)
            => a < b;

        [MethodImpl(Inline), Lt]
        public static bit lt(byte a, byte b)
            => a < b;

        [MethodImpl(Inline), Lt]
        public static bit lt(short a, short b)
            => a < b;

        [MethodImpl(Inline), Lt]
        public static bit lt(ushort a, ushort b)
            => a < b;

        [MethodImpl(Inline), Lt]
        public static bit lt(int a, int b)
            => a < b;

        [MethodImpl(Inline), Lt]
        public static bit lt(uint a, uint b)
            => a < b;

        [MethodImpl(Inline), Lt]
        public static bit lt(long a, long b)
            => a < b;

        [MethodImpl(Inline), Lt]
        public static bit lt(ulong a, ulong b)
            => a < b;
    }
}