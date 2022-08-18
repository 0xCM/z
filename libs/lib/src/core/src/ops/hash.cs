// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline)]
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
        public static Hash32 hash(ushort x, ushort y)
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
        public static Hash32 hash<T>(T src)
            => HashCodes.Generic.hash(src);

        [MethodImpl(Inline)]
        public static Hash32 hash(ReadOnlySpan<byte> src)
            => HashCodes.hash(src);

        [MethodImpl(Inline)]
        public static Hash32 hash(string src)
            => HashCodes.hash(src);

        [MethodImpl(Inline)]
        public static Hash32 hash(ReadOnlySpan<char> src)
            => HashCodes.hash(src);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(ReadOnlySpan<T> src)
            => HashCodes.Generic.hash(src);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(T x, T y)
            => HashCodes.Generic.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(T x, T y, T z)
            => HashCodes.Generic.hash(x, y, z, z);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(T a, T b, T c, T d)
            => HashCodes.Generic.hash(a,b,c,d);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(Vector128<T> src)
            where T : unmanaged
            =>  alg.ghash.calc(src);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(Vector256<T> src)
            where T : unmanaged
                => alg.hash.calc(src);

        [MethodImpl(Inline)]
        public static Hash32 hash<T>(Vector512<T> src)
            where T : unmanaged
                => alg.hash.calc(src);


        [MethodImpl(Inline)]
        public static Hash64 hash64<X,Y>(X x, Y y)
            => alg.ghash.calc64(x,y);

        [MethodImpl(Inline)]
        public static Hash64 hash64(Type x, Type y)
            => alg.hash.combine(x,y);

        [MethodImpl(Inline)]
        public static Hash64 hash64(Type x, Type y, Type z)
             => alg.hash.combine(x,y,z);
    }
}