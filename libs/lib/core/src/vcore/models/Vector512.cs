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
}