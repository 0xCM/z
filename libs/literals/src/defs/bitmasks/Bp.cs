//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct BitMaskLiterals
    {
        [BitMask("00000001")]
        public const byte b00000001x8 = 0b00000001;

        [BitMask("00000010")]
        public const byte b00000010x8 = 0b00000010;

        [BitMask("00000100")]
        public const byte b00000100x8 = 0b00000100;

        [BitMask("00001000")]
        public const byte b00001000x8 = 0b00001000;

        [BitMask("00010000")]
        public const byte b00010000x8 = 0b00010000;

        [BitMask("00100000")]
        public const byte b00100000x8 = 0b00100000;

        [BitMask("01000000")]
        public const byte b01000000x8 = 0b01000000;

        [BitMask("10000000")]
        public const byte b10000000x8 = 0b10000000;

        [BitMask("00001111")]
        public const byte b00001111x8 = 0b00001111;

        [BitMask("11110000")]
        public const byte b11110000x8 = 0b11110000;

        [BitMask("01010101")]
        public const byte b01010101x8 = 0x55;

        [BitMask("00110011")]
        public const byte b00110011x8 = 0x33;

        [BitMask("00000001 00000001")]
        public const ushort b00000001x16 = (ushort)b00000001x8 << 8 | (ushort)b00000001x8;

        [BitMask("00000010 00000010")]
        public const ushort b00000010x16 = (ushort)b00000010x8 << 8 | (ushort)b00000010x8;

        [BitMask("00000100 00000100")]
        public const ushort b00000100x16 = (ushort)b00000100x8 << 8 | (ushort)b00000100x8;

        [BitMask("00001000 00001000")]
        public const ushort b00001000x16 = (ushort)b00001000x8 << 8 | (ushort)b00001000x8;

        [BitMask("00010000 00010000")]
        public const ushort b00010000x16 = (ushort)b00010000x8 << 8 | (ushort)b00010000x8;

        [BitMask("00100000 00100000")]
        public const ushort b00100000x16 = (ushort)b00100000x8 << 8 | (ushort)b00100000x8;

        [BitMask("01000000 01000000")]
        public const ushort b01000000x16 = (ushort)b01000000x8 << 8 | (ushort)b01000000x8;

        [BitMask("10000000 10000000")]
        public const ushort b10000000x16 = (ushort)b10000000x8 << 8 | (ushort)b10000000x8;

        [BitMask("01010101 01010101")]
        public const ushort b01010101x16 = 0x5555;

        [BitMask("00110011 00110011")]
        public const ushort b00110011x16 = 0x3333;

        [BitMask("00001111 00001111")]
        public const ushort b00001111x16 = 0x0f0f;

        [BitMask("00000001 00000001 00000001 00000001")]
        public const uint b00000001x32 = (uint)b00000001x16 << 16 | (uint)b00000001x16;

        [BitMask("00000010 00000010 00000010 00000010")]
        public const uint b00000010x32 = (uint)b00000010x16 << 16 | (uint)b00000010x16;

        [BitMask("00000100 00000100 00000100 00000100")]
        public const uint b00000100x32 = (uint)b00000100x16 << 16 | (uint)b00000100x16;

        [BitMask("00001000 00001000 00001000 00001000")]
        public const uint b00001000x32 = (uint)b00001000x16 << 16 | (uint)b00001000x16;

        [BitMask("00010000 00010000 00010000 00010000")]
        public const uint b00010000x32 = (uint)b00010000x16 << 16 | (uint)b00010000x16;

        [BitMask("00100000 00100000 00100000 00100000")]
        public const uint b00100000x32 = (uint)b00100000x16 << 16 | (uint)b00100000x16;

        [BitMask("01000000 01000000 01000000 01000000")]
        public const uint b01000000x32 = (uint)b01000000x16 << 16 | (uint)b01000000x16;

        [BitMask("10000000 10000000 10000000 10000000")]
        public const uint b10000000x32 = (uint)b10000000x16 << 16 | (uint)b10000000x16;

        [BitMask("01010101 01010101 01010101 01010101")]
        public const uint b01010101x32 = 0x55555555;

        [BitMask("00110011 00110011 00110011 00110011")]
        public const uint b00110011x32 = 0x33333333;

        [BitMask("00001111 00001111 00001111 00001111")]
        public const uint b00001111x32 = 0x0f0f0f0f;

        [BitMask("00000001 00000001 00000001 00000001 00000001 00000001 00000001 00000001")]
        public const ulong b00000001x64 = (ulong)b00000001x32 << 32 | (ulong)b00000001x32;

        [BitMask("00000010 00000010 00000010 00000010 00000010 00000010 00000010 00000010")]
        public const ulong b00000010x64 = (ulong)b00000010x32 << 32 | (ulong)b00000010x32;

        public const ulong b00000100x64 = (ulong)b00000100x32 << 32 | (ulong)b00000100x32;

        public const ulong b00001000x64 = (ulong)b00001000x32 << 32 | (ulong)b00001000x32;

        public const ulong b00010000x64 = (ulong)b00010000x32 << 32 | (ulong)b00010000x32;

        public const ulong b00100000x64 = (ulong)b00100000x32 << 32 | (ulong)b00100000x32;

        public const ulong b01000000x64 = (ulong)b01000000x32 << 32 | (ulong)b01000000x32;

        public const ulong b10000000x64 = (ulong)b10000000x32 << 32 | (ulong)b10000000x32;

        public const ulong b01010101x64 = 0x5555555555555555;

        public const ulong b00110011x64 = 0x3333333333333333;

        public const ulong b00001111x64 = 0x0f0f0f0f0f0f0f0f;
    }
}