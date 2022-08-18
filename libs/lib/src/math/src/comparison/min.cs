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
        [MethodImpl(Inline), Min]
        public static sbyte min(sbyte a, sbyte b)
            => a < b ? a : b;

        [MethodImpl(Inline), Min]
        public static byte min(byte a, byte b)
            => a < b ? a : b;

        [MethodImpl(Inline), Min]
        public static short min(short a, short b)
            => a < b ? a : b;

        [MethodImpl(Inline), Min]
        public static ushort min(ushort a, ushort b)
            => a < b ? a : b;

        [MethodImpl(Inline), Min]
        public static int min(int a, int b)
            => a < b ? a : b;

        [MethodImpl(Inline), Min]
        public static int min(int a, int b, int c)
            => min(min(a,b),min(b,c));

        [MethodImpl(Inline), Min]
        public static uint min(uint a, uint b)
            => a < b ? a : b;

        [MethodImpl(Inline), Min]
        public static long min(long a, long b)
            => a < b ? a : b;

        [MethodImpl(Inline), Min]
        public static ulong min(ulong a, ulong b)
            => a < b ? a : b;
   }
}