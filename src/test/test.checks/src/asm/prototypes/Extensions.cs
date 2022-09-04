//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + extensions)]
        public readonly struct Extensions
        {
            public static _ApiHostUri Uri => typeof(Extensions).ApiHostUri();

            [MethodImpl(Inline), Op]
            public static ushort extend_u16(byte u8)
                => u8;

            [MethodImpl(Inline), Op]
            public static short extend_i16(byte u8)
                => u8;

            [MethodImpl(Inline), Op]
            public static uint extend_u32(byte u8)
                => u8;

            [MethodImpl(Inline), Op]
            public static int extend_i32(byte u8)
                => u8;

            [MethodImpl(Inline), Op]
            public static ulong extend_u64(byte u8)
                => u8;

            [MethodImpl(Inline), Op]
            public static long extend_i64(byte u8)
                => u8;

            [MethodImpl(Inline), Op]
            public static ushort extend_u16(sbyte i8)
                => (byte)i8;

            [MethodImpl(Inline), Op]
            public static short extend_i16(sbyte i8)
                => i8;

            [MethodImpl(Inline), Op]
            public static uint extend_u32(sbyte i8)
                => (byte)i8;

            [MethodImpl(Inline), Op]
            public static int extend_i32(sbyte i8)
                => i8;

            [MethodImpl(Inline), Op]
            public static ulong extend_u64(sbyte i8)
                => (byte)i8;

            [MethodImpl(Inline), Op]
            public static long extend_i64(sbyte i8)
                => (byte)i8;

            [MethodImpl(Inline), Op]
            public static uint extend_u32(ushort u16)
                => u16;

            [MethodImpl(Inline), Op]
            public static int extend_i32(ushort u16)
                => u16;

            [MethodImpl(Inline), Op]
            public static ulong extend_u64(ushort u16)
                => u16;

            [MethodImpl(Inline), Op]
            public static long extend_i64(ushort u16)
                => u16;

            [MethodImpl(Inline), Op]
            public static uint extend_u32(short i16)
                => (ushort)i16;

            [MethodImpl(Inline), Op]
            public static int extend_i32(short i16)
                => i16;

            [MethodImpl(Inline), Op]
            public static ulong extend_u64(short i16)
                => (ushort)i16;

            [MethodImpl(Inline), Op]
            public static long extend_i64(short i16)
                => i16;

            [MethodImpl(Inline), Op]
            public static ulong extend_u64(uint u32)
                => u32;

            [MethodImpl(Inline), Op]
            public static long extend_i64(uint u32)
                => u32;

            [MethodImpl(Inline), Op]
            public static ulong extend_u64(int i32)
                => (uint)i32;

            [MethodImpl(Inline), Op]
            public static long extend_i64(int i32)
                => i32;

           [MethodImpl(Inline), Op]
            public static void extend(byte u8, out ushort u16)
                => u16 = u8;

            [MethodImpl(Inline), Op]
            public static void extend(byte u8, out short i16)
                => i16 = u8;

            [MethodImpl(Inline), Op]
            public static void extend(byte u8, out uint u32)
                => u32 = u8;

            [MethodImpl(Inline), Op]
            public static void extend(byte u8, out int i32)
                => i32 = u8;

            [MethodImpl(Inline), Op]
            public static void extend(byte u8, out long i64)
                => i64 = u8;

            [MethodImpl(Inline), Op]
            public static void extend(byte u8, out ulong dst)
                => dst = u8;

            [MethodImpl(Inline), Op]
            public static void extend(sbyte i8, out ushort u16)
                => u16 = (byte)i8;

            [MethodImpl(Inline), Op]
            public static void extend(sbyte i8, out short i16)
                => i16 = i8;

            [MethodImpl(Inline), Op]
            public static void extend(sbyte i8, out uint u32)
                => u32 = (byte)i8;

            [MethodImpl(Inline), Op]
            public static void extend(sbyte i8, out int i32)
                => i32 = i8;

            [MethodImpl(Inline), Op]
            public static void extend(sbyte i8, out long i64)
                => i64 = i8;

            [MethodImpl(Inline), Op]
            public static void extend(sbyte i8, out ulong u64)
                => u64 = (byte)i8;

            [MethodImpl(Inline), Op]
            public static void extend(ushort u16, out uint u32)
                => u32 = u16;

            [MethodImpl(Inline), Op]
            public static void extend(ushort u16, out int i32)
                => i32 = u16;

            [MethodImpl(Inline), Op]
            public static void extend(ushort u16, out long i64)
                => i64 = u16;

            [MethodImpl(Inline), Op]
            public static void extend(ushort u16, out ulong u64)
                => u64 = u16;

            [MethodImpl(Inline), Op]
            public static void extend(short i16, out uint u32)
                => u32 = (ushort)i16;

            [MethodImpl(Inline), Op]
            public static void extend(short i16, out int i32)
                => i32 = i16;

            [MethodImpl(Inline), Op]
            public static void extend(short i16, out long i64)
                => i64 = i16;

            [MethodImpl(Inline), Op]
            public static void extend(short i16, out ulong u64)
                => u64 = (ushort)i16;

            [MethodImpl(Inline), Op]
            public static void extend(uint u32, out long i64)
                => i64 = u32;

            [MethodImpl(Inline), Op]
            public static void extend(uint u32, out ulong u64)
                => u64 = u32;

            [MethodImpl(Inline), Op]
            public static void extend(int i32, out long i64)
                => i64 = i32;

            [MethodImpl(Inline), Op]
            public static void extend(int i32, out ulong u64)
                => u64 = (uint)i32;

            [MethodImpl(Inline), Op]
            public static void extend(byte u8, out ushort u16, out short i16, out uint u32, out int i32, out ulong u64, out long i64)
            {
                extend(u8, out u16);
                extend(u8, out i16);
                extend(u8, out u32);
                extend(u8, out i32);
                extend(u8, out u64);
                extend(u8, out i64);
            }

            [MethodImpl(Inline), Op]
            public static void extend(sbyte i8, out ushort u16, out short i16, out uint u32, out int i32, out ulong u64, out long i64)
            {
                extend(i8, out u16);
                extend(i8, out i16);
                extend(i8, out u32);
                extend(i8, out i32);
                extend(i8, out u64);
                extend(i8, out i64);
            }

            [MethodImpl(Inline), Op]
            public static void extend(ushort u16, out uint u32, out int i32, out ulong u64, out long i64)
            {
                extend(u16, out u32);
                extend(u16, out i32);
                extend(u16, out u64);
                extend(u16, out i64);
            }

            [MethodImpl(Inline), Op]
            public static void extend(short i16, out uint u32, out int i32, out ulong u64, out long i64)
            {
                extend(i16, out u32);
                extend(i16, out i32);
                extend(i16, out u64);
                extend(i16, out i64);
            }

            [MethodImpl(Inline), Op]
            public static void extend(uint u32, out ulong u64, out long i64)
            {
                extend(u32, out u64);
                extend(u32, out i64);
            }

            [MethodImpl(Inline), Op]
            public static void extend(int i32, out ulong u64, out long i64)
            {
                extend(i32, out u64);
                extend(i32, out i64);
            }
        }
    }
}