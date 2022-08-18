//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline), Op]
        public static Hash32 hash(sbyte x)
            => HashCodes.hash(x);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(byte x)
            => HashCodes.hash(x);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(short x)
            => HashCodes.hash(x);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(ushort x)
            => HashCodes.hash(x);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(int x)
            => HashCodes.hash(x);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(uint x)
            => x;

        [MethodImpl(Inline), Op]
        public static Hash32 hash(long x)
            => HashCodes.hash(x);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(ulong x)
            => HashCodes.hash(x);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(char x)
            => HashCodes.hash(x);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(float x)
            => HashCodes.hash(x);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(double x)
            => HashCodes.hash(x);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(decimal x)
            => HashCodes.hash(x);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(bool x)
            => HashCodes.hash(x);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(ushort x, ushort y)
            => HashCodes.hash(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(char x, char y)
            => HashCodes.hash(x,y);

        [MethodImpl(Inline), Op]
        public static Hash32 hash(Type src)
            => HashCodes.hash(src);

        [MethodImpl(Inline)]
        public static Hash32 hash(uint x, uint y)
            => HashCodes.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash(sbyte x, sbyte y)
            => HashCodes.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash(byte x, byte y)
            => HashCodes.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash(short x, short y)
            => HashCodes.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash(int x, int y)
            => HashCodes.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash(ulong x, ulong y)
            => HashCodes.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash(long x, long y)
            => HashCodes.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash(float x, float y)
            => HashCodes.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash(double x, double y)
            => HashCodes.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash(decimal x, decimal y)
            => HashCodes.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash(sbyte x, sbyte y, sbyte z)
             => HashCodes.combine(x,y,z);

        [MethodImpl(Inline)]
        public static Hash32 hash(byte x, byte y, byte z)
             => HashCodes.combine(x,y,z);

        [MethodImpl(Inline)]
        public static Hash32 hash(ushort x, ushort y, ushort z)
             => HashCodes.combine(x,y,z);

        [MethodImpl(Inline)]
        public static Hash32 hash(short x, short y, short z)
             => HashCodes.combine(x,y,z);

        [MethodImpl(Inline)]
        public static Hash32 hash(uint x, uint y, uint z)
             => HashCodes.combine(x,y,z);

        [MethodImpl(Inline)]
        public static Hash32 hash(int x, int y, int z)
             => HashCodes.combine(x,y,z);

        [MethodImpl(Inline)]
        public static Hash32 hash(ulong x, ulong y, ulong z)
             => HashCodes.combine(x,y,z);

        [MethodImpl(Inline)]
        public static Hash32 hash(long x, long y, long z)
             => HashCodes.combine(x,y,z);

        [MethodImpl(Inline)]
        public static Hash32 hash(char x, char y, char z)
             => HashCodes.combine(x,y,z);

        [MethodImpl(Inline)]
        public static Hash32 hash(ReadOnlySpan<byte> src)
            => HashCodes.hash(src);

        [MethodImpl(Inline)]
        public static Hash32 hash(string src)
            => HashCodes.hash(src);

        [MethodImpl(Inline)]
        public static Hash32 hash(ReadOnlySpan<char> src)
            => HashCodes.hash(src);
    }
}