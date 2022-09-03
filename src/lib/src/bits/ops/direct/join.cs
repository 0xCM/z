//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class bits
    {
        [MethodImpl(Inline), Op]
        public static ushort join(byte a, byte b)
            => (ushort)((ushort)a << 0 * 8 | (ushort)b << 1 * 8);

        [MethodImpl(Inline), Op]
        public static uint join(byte a, byte b, byte c)
            => (uint)a << 0 * 8 | (uint)b << 1 * 8 | (uint)c << 2 * 8;

        [MethodImpl(Inline), Op]
        public static uint join(byte a, byte b, byte c, byte d)
            => (uint)a << 0 * 8 | (uint)b << 1 * 8 | (uint)c << 2 * 8 | (uint)d << 3 * 8;

        [MethodImpl(Inline), Op]
        public static ulong join(byte a, byte b, byte c, byte d, byte e, byte f, byte g, byte h)
            => (ulong)a << 0 * 8 | (ulong)b << 1 * 8 | (ulong)c << 2 * 8 | (ulong)d << 3 * 8
             | (ulong)e << 4 * 8 | (ulong)f << 5 * 8 | (ulong)g << 6 * 8 | (ulong)h << 7 * 8;

        [MethodImpl(Inline), Op]
        public static uint join(ushort a, ushort b)
            => (uint)a << 0 * 16 | (uint)b << 1 * 16;

        [MethodImpl(Inline), Op]
        public static ulong join(ushort a, ushort b, ushort c)
            => (ulong)a << 0 * 16 | (ulong)b << 1 * 16 | (ulong)c << 2*16;

        [MethodImpl(Inline), Op]
        public static ulong join(ushort a, ushort b, ushort c, ushort d)
            => (uint)a << 0 * 16 | (uint)b << 1 * 16 | (uint)c << 2 * 16 | (uint)d << 3 * 16;

        [MethodImpl(Inline), Op]
        public static ulong join(in uint a, in uint b)
              => (ulong)a | (ulong)b << 32;
    }
}