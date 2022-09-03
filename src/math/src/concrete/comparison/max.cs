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
        [MethodImpl(Inline), Max]
        public static sbyte max(sbyte a, sbyte b)
            => a > b ? a : b;

        [MethodImpl(Inline), Max]
        public static byte max(byte a, byte b)
            => a > b ? a : b;

        [MethodImpl(Inline), Max]
        public static short max(short a, short b)
            => a > b ? a : b;

        [MethodImpl(Inline), Max]
        public static ushort max(ushort a, ushort b)
            => a > b ? a : b;

        [MethodImpl(Inline), Max]
        public static int max(int a, int b)
            => a > b ? a : b;

        [MethodImpl(Inline), Max]
        public static uint max(uint a, uint b)
            => a > b ? a : b;

        [MethodImpl(Inline), Max]
        public static long max(long a, long b)
            => a > b ? a : b;

        [MethodImpl(Inline), Max]
        public static ulong max(ulong a, ulong b)
            => a > b ? a : b;
    }
}