//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;

    partial struct AsciSymbols
    {
        [MethodImpl(Inline), Op]
        public static uint pack(C c0, C c1, C c2, out uint dst)
        {
            dst = (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static uint pack(C c0, C c1, C c2, C c3, out uint dst)
        {
            dst = (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16 | (uint)c3 << 24;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ushort pack(char c0, char c1)
            => (ushort)((uint)c0 | ((uint)c1 << 8));

        [MethodImpl(Inline), Op]
        public static uint pack(char c0, char c1, char c2)
            => (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16;

        [MethodImpl(Inline), Op]
        public static uint pack(char c0, char c1, char c2, char c3)
            => (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16 | (uint)c3 << 24;

        [MethodImpl(Inline), Op]
        public static ulong pack(char c0, char c1, char c2, char c3, char c4)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
             | (ulong)c4 << 32;

        [MethodImpl(Inline), Op]
        public static ulong pack(char c0, char c1, char c2, char c3, char c4, char c5)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
            | (ulong)c4 << 32 | (ulong)c5 << 40;

        [MethodImpl(Inline), Op]
        public static ulong pack(char c0, char c1, char c2, char c3, char c4, char c5, char c6)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
             | (ulong)c4 << 32 | (ulong)c5 << 40| (ulong)c6 << 48;

        [MethodImpl(Inline), Op]
        public static ulong pack(char c0, char c1, char c2, char c3, char c4, char c5, char c6, char c7)
            =>  (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
              | (ulong)c4 << 32 | (ulong)c5 << 40 | (ulong)c6 << 48  | (ulong)c7 << 56;

        [MethodImpl(Inline), Op]
        public static ushort pack(C c0, C c1)
            => (ushort)((uint)c0 | ((uint)c1 << 8));

        [MethodImpl(Inline), Op]
        public static uint pack(C c0, C c1, C c2)
            => (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16;

        [MethodImpl(Inline), Op]
        public static uint pack(C c0, C c1, C c2, C c3)
            => (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16 | (uint)c3 << 24;

        [MethodImpl(Inline), Op]
        public static ulong pack(C c0, C c1, C c2, C c3, C c4)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
             | (ulong)c4 << 32;

        [MethodImpl(Inline), Op]
        public static ulong pack(C c0, C c1, C c2, C c3, C c4, C c5)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
            | (ulong)c4 << 32 | (ulong)c5 << 40;

        [MethodImpl(Inline), Op]
        public static ulong pack(C c0, C c1, C c2, C c3, C c4, C c5, C c6)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
             | (ulong)c4 << 32 | (ulong)c5 << 40| (ulong)c6 << 48;

        [MethodImpl(Inline), Op]
        public static ulong pack(C c0, C c1, C c2, C c3, C c4, C c5, C c6, C c7)
            =>  (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
              | (ulong)c4 << 32 | (ulong)c5 << 40 | (ulong)c6 << 48  | (ulong)c7 << 56;

        [MethodImpl(Inline), Op]
        public static ushort pack(byte c0, byte c1)
            => (ushort)((uint)c0 | ((uint)c1 << 8));

        [MethodImpl(Inline), Op]
        public static uint pack(byte c0, byte c1, byte c2)
            => (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16;

        [MethodImpl(Inline), Op]
        public static uint pack(byte c0, byte c1, byte c2, byte c3)
            => (uint)c0 | ((uint)c1 << 8) | (uint)c2 << 16 | (uint)c3 << 24;

        [MethodImpl(Inline), Op]
        public static ulong pack(byte c0, byte c1, byte c2, byte c3, byte c4)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
             | (ulong)c4 << 32;

        [MethodImpl(Inline), Op]
        public static ulong pack(byte c0, byte c1, byte c2, byte c3, byte c4, byte c5)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
            | (ulong)c4 << 32 | (ulong)c5 << 40;

        [MethodImpl(Inline), Op]
        public static ulong pack(byte c0, byte c1, byte c2, byte c3, byte c4, byte c5, byte c6)
            => (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
             | (ulong)c4 << 32 | (ulong)c5 << 40| (ulong)c6 << 48;

        [MethodImpl(Inline), Op]
        public static ulong pack(byte c0, byte c1, byte c2, byte c3, byte c4, byte c5, byte c6, byte c7)
            =>  (ulong)c0 | ((ulong)c1 << 8) | (ulong)c2 << 16 | (ulong)c3 << 24
              | (ulong)c4 << 32 | (ulong)c5 << 40 | (ulong)c6 << 48  | (ulong)c7 << 56;        
    }
}