//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static ushort join(byte a0, byte a1)
            => (ushort)((uint)a0 | ((uint)a1 << 8));

        [MethodImpl(Inline), Op]
        public static ushort join(byte a0, ushort a1)
            => (ushort)((uint)a0 | ((uint)a1 << 8));

        [MethodImpl(Inline), Op]
        public static uint join(byte a0, byte a1, ushort a2)
            => (uint)a0 | ((uint)a1 << 8) | ((uint)a2 << 16);

        [MethodImpl(Inline), Op]
        public static uint join(byte a0, byte a1, byte a2)
            => (uint)a0 | ((uint)a1 << 8) | (uint)a2 << 16;

        [MethodImpl(Inline), Op]
        public static uint join(byte a0, byte a1, byte a2, byte a3)
            => (uint)a0 | ((uint)a1 << 8) |((uint)a2 << 16) | ((uint)a3 << 24);

        [MethodImpl(Inline), Op]
        public static ulong join(byte a0, byte a1, byte a2, byte a3, byte a4)
            => (ulong)a0 | ((ulong)a1 << 8) |((ulong)a2 << 16) | ((ulong)a3 << 24) | ((ulong) a4) << 32;

        [MethodImpl(Inline), Op]
        public static uint join(ushort a0, byte a1)
            => (uint)a0 | ((uint)a1 << 16);

        [MethodImpl(Inline), Op]
        public static uint join(ushort a0, ushort a1)
            => (uint)a0 | ((uint)a1 << 16);

        [MethodImpl(Inline), Op]
        public static ulong join(ushort a0, ushort a1, ushort a2)
            => (ulong)a0 | ((ulong)a1 << 16) | ((ulong)a2 << 32);

        [MethodImpl(Inline), Op]
        public static ulong join(ushort a0, ushort a1, ushort a2, ushort a3)
            => (ulong)a0 | ((ulong)a1 << 16) | ((ulong)a2 << 32) | ((ulong)a3 << 48);

        [MethodImpl(Inline), Op]
        public static ulong join(uint a0, byte a1)
            => (ulong)a0 | ((ulong)a1 << 32);

        [MethodImpl(Inline), Op]
        public static ulong join(uint a0, byte a1, byte a3)
            => (ulong)a0 | ((ulong)a1 << 32) | ((ulong)a3 << 40);

        [MethodImpl(Inline), Op]
        public static ulong join(uint a0, ushort a1)
            => (ulong)a0 | ((ulong)a1 << 32);

        [MethodImpl(Inline), Op]
        public static ulong join(uint a0, ushort a1, ushort a2)
            => (ulong)a0 | ((ulong)a1 << 32) | ((ulong)a2 << 48);

        [MethodImpl(Inline), Op]
        public static ulong join(uint a0, uint a1)
            => (ulong)a0 | ((ulong)a1 << 32);

        [MethodImpl(Inline), Op]
        public static uint pack(ushort a0, byte a1, byte a2)
            => (uint)a0 | ((uint)a1 << 16) | ((uint)a2 << 24);
    }
}