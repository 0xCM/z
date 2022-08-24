//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Size = 64), Vector(NativeTypeWidth.W512)]
    public readonly struct Vector512<T>
        where T : unmanaged
    {
        [MethodImpl(Inline)]
        public static Vector512<T> from(Vector256<T> src)
            => new Vector512<T>(src, default);

        [MethodImpl(Inline)]
        public static Vector512<T> from(Vector256<T> a, Vector256<T> b)
            => new Vector512<T>(a, b);

        [MethodImpl(Inline)]
        public static Vector512<T> from(Vector128<T> src)
            => new Vector512<T>(src, default, default, default);

        [MethodImpl(Inline)]
        public static Vector512<T> from(Vector128<T> a, Vector128<T> b)
            => new Vector512<T>(a, b, default, default);

        [MethodImpl(Inline)]
        public static Vector512<T> from(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            => new Vector512<T>(a, b, c, default);

        [MethodImpl(Inline)]
        public static Vector512<T> from(Vector128<T> a, Vector128<T> b, Vector128<T> c, Vector128<T> d)
            => new Vector512<T>(a, b, c, d);

        /// <summary>
        /// The lo 256 bits
        /// </summary>
        public readonly Vector256<T> Lo;

        /// <summary>
        /// The hi 256 bits
        /// </summary>
        public readonly Vector256<T> Hi;

        [MethodImpl(Inline)]
        public Vector512(Vector256<T> a, Vector256<T> b)
        {
            Lo = a;
            Hi = b;
        }

        [MethodImpl(Inline)]
        public Vector512(Vector128<T> a, Vector128<T> b, Vector128<T> c, Vector128<T> d)
        {
            Lo = Vector256.WithUpper(Vector256.WithLower(default, a), b);
            Hi = Vector256.WithUpper(Vector256.WithLower(default, c), d);
        }

        public Vector128<T> this[N0 n]
        {
            [MethodImpl(Inline)]
            get => Vector256.GetLower(Lo);
        }

        public Vector128<T> this[N1 n]
        {
            [MethodImpl(Inline)]
            get => Vector256.GetUpper(Lo);
        }

        public Vector128<T> this[N2 n]
        {
            [MethodImpl(Inline)]
            get => Vector256.GetLower(Hi);
        }

        public Vector128<T> this[N3 n]
        {
            [MethodImpl(Inline)]
            get => Vector256.GetUpper(Hi);
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out Vector256<T> a, out Vector256<T> b)
        {
            a = Lo;
            b = Hi;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out Vector128<T> a, out Vector128<T> b, out Vector128<T> c, out Vector128<T> d)
        {
            a = this[n0];
            b = this[n1];
            c = this[n2];
            d = this[n3];
        }

        /// <summary>
        /// Interprets the pair over an alternate domain
        /// </summary>
        /// <typeparam name="U">The alternate type</typeparam>
        [MethodImpl(Inline)]
        public Vector512<U> As<U>()
            where U : unmanaged
                => Unsafe.As<Vector512<T>,Vector512<U>>(ref Unsafe.AsRef(in this));

        [MethodImpl(Inline)]
        public bool Equals(in Vector512<T> rhs)
            => Lo.Equals(rhs.Lo) && Hi.Equals(rhs.Hi);


        public override int GetHashCode()
            => HashCode.Combine(Lo,Hi);

        public override bool Equals(object obj)
            => obj is Vector512<T> x && Equals(x);

        public override string ToString()
            => string.Join(" ", Lo.ToString(), Hi.ToString());

        public static Vector512<T> Zero
            => default;

        public const int Size = 64;

        /// <summary>
        /// The number of cells covered by the vector
        /// </summary>
        public static int Count
            => 2*Vector256<T>.Count;

        [MethodImpl(Inline)]
        public static implicit operator Vector512<T>((Vector256<T> a, Vector256<T> b) src)
            => new Vector512<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator Vector512<T>((Vector128<T> a, Vector128<T> b, Vector128<T> c, Vector128<T> d) src)
            => new Vector512<T>(src.a, src.b,src.c, src.d);

        [MethodImpl(Inline)]
        public static implicit operator (Vector256<T> lo, Vector256<T> hi)(Vector512<T> src)
            => (src.Lo, src.Hi);

        [MethodImpl(Inline)]
        public static bool operator ==(in Vector512<T> a, in Vector512<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(in Vector512<T> a, in Vector512<T> b)
            => a.Equals(b);
    }

    [ApiHost(ApiNames.Vex512, true)]
    public static class Vector512
    {
        [MethodImpl(Inline),Op]
        public static Vector512<T> create<T>(Vector256<T> lo, Vector256<T> hi)
            where T : unmanaged
                => new Vector512<T>(lo,hi);

        [MethodImpl(Inline),Op]
        public static Vector512<short> create(
            short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7,
            short x8, short x9, short x10, short x11, short x12, short x13, short x14, short x15,
            short x16, short x17, short x18, short x19, short x20, short x21, short x22, short x23,
            short x24, short x25, short x26, short x27, short x28, short x29, short x30, short x31)
                => (Vector256.Create(x0,x1, x2, x3,x4,x5,x6,x7,x8,x9,x10,x11,x12,x13,x14,x15),
                    Vector256.Create(x16,x17,x18,x19,x20,x21,x22,x23,x24,x25,x26,x27,x28,x29,x30,x31));

        [MethodImpl(Inline),Op]
        public static Vector512<ushort> create(
            ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7,
            ushort x8, ushort x9, ushort x10, ushort x11, ushort x12, ushort x13, ushort x14, ushort x15,
            ushort x16, ushort x17, ushort x18, ushort x19, ushort x20, ushort x21, ushort x22, ushort x23,
            ushort x24, ushort x25, ushort x26, ushort x27, ushort x28, ushort x29, ushort x30, ushort x31)
                => (Vector256.Create(x0,x1, x2, x3,x4,x5,x6,x7,x8,x9,x10,x11,x12,x13,x14,x15),
                    Vector256.Create(x16,x17,x18,x19,x20,x21,x22,x23,x24,x25,x26,x27,x28,x29,x30,x31));

        [MethodImpl(Inline),Op]
        public static Vector512<int> Create(int x0, int x1, int x2, int x3, int x4, int x5, int x6, int x7,
            int x8, int x9, int x10, int x11, int x12, int x13, int x14, int x15)
                => (Vector256.Create(x0,x1, x2, x3,x4,x5,x6,x7), Vector256.Create(x8,x9,x10,x11,x12,x13,x14,x15));

        [MethodImpl(Inline),Op]
        public static Vector512<uint> Create(uint x0, uint x1, uint x2, uint x3, uint x4, uint x5, uint x6, uint x7,
            uint x8, uint x9, uint x10, uint x11, uint x12, uint x13, uint x14, uint x15)
                => (Vector256.Create(x0,x1, x2, x3,x4,x5,x6,x7), Vector256.Create(x8,x9,x10,x11,x12,x13,x14,x15));

        [MethodImpl(Inline),Op]
        public static Vector512<long> Create(long x0, long  x1, long  x2, long  x3, long x4, long  x5, long  x6, long  x7)
            => (Vector256.Create(x0,x1, x2, x3), Vector256.Create(x4, x5, x6, x7));

        [MethodImpl(Inline),Op]
        public static Vector512<ulong> Create(ulong x0, ulong  x1, ulong  x2, ulong  x3, ulong x4, ulong  x5, ulong  x6, ulong  x7)
            => (Vector256.Create(x0,x1, x2, x3), Vector256.Create(x4, x5, x6, x7));

        [MethodImpl(Inline),Op]
        public static Vector512<float> Create(float x0, float x1, float x2, float x3, float x4, float x5, float x6, float x7,
            float x8, float x9, float x10, float x11, float x12, float x13, float x14, float x15)
                => (Vector256.Create(x0,x1, x2, x3,x4,x5,x6,x7), Vector256.Create(x8,x9,x10,x11,x12,x13,x14,x15));

        [MethodImpl(Inline),Op]
        public static Vector512<double> create(double x0, double  x1, double  x2, double  x3, double x4, double  x5, double  x6, double  x7)
            => (Vector256.Create(x0,x1, x2, x3), Vector256.Create(x4, x5, x6, x7));
    }
}