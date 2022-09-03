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
        [MethodImpl(Inline), Not]
        public static sbyte not(sbyte src)
            => (sbyte)(~ src);

        [MethodImpl(Inline), Not]
        public static byte not(byte src)
            => (byte)(~ src);

        [MethodImpl(Inline), Not]
        public static short not(short src)
            => (short)(~ src);

        [MethodImpl(Inline), Not]
        public static ushort not(ushort src)
            => (ushort)(~ src);

        [MethodImpl(Inline), Not]
        public static int not(int src)
            => ~ src;

        [MethodImpl(Inline), Not]
        public static uint not(uint src)
            => ~ src;

        [MethodImpl(Inline), Not]
        public static long not(long src)
            => ~ src;

        [MethodImpl(Inline), Not]
        public static ulong not(ulong src)
            => ~ src;
    }
}