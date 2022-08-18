//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// 4x256 / 2x512
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 128), Vector(NativeTypeWidth.W1024)]
    public readonly struct Vector1024<T>
        where T : unmanaged
    {
        /// <summary>
        /// The lo 256 bit segment
        /// </summary>
        public readonly Vector256<T> A;

        /// <summary>
        /// The second 256-bit segment
        /// </summary>
        public readonly Vector256<T> B;

        /// <summary>
        /// The third 256-bit segment
        /// </summary>
        public readonly Vector256<T> C;

        /// <summary>
        /// The hi 256-bit segment
        /// </summary>
        public readonly Vector256<T> D;

        /// <summary>
        /// The number of cells covered by the vector
        /// </summary>
        public static int Count => 2*Vector256<T>.Count;

        [MethodImpl(Inline)]
        public static implicit operator Vector1024<T>(in (Vector512<T> a, Vector512<T> b) src)
            => new Vector1024<T>(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator Vector1024<T>(in (Vector256<T> a, Vector256<T> b, Vector256<T> c, Vector256<T> d) src)
            => new Vector1024<T>(src.a, src.b, src.c, src.d);

        [MethodImpl(Inline)]
        public static bool operator ==(in Vector1024<T> a, in Vector1024<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(in Vector1024<T> a, in Vector1024<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public Vector1024(Vector256<T> a, Vector256<T> b, Vector256<T> c, Vector256<T> d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        [MethodImpl(Inline)]
        public Vector1024(Vector512<T> lo, Vector512<T> hi)
        {
            this.A = lo.Lo;
            this.B = lo.Hi;
            this.C = hi.Lo;
            this.D = hi.Hi;
        }

        public T this[int i]
        {
            [MethodImpl(Inline)]
            get => default;
        }

        public Vector512<T> Lo
        {
            [MethodImpl(Inline)]
            get => (A,B);
        }

        public Vector512<T> Hi
        {
            [MethodImpl(Inline)]
            get => (C,D);
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out Vector256<T> a, out Vector256<T> b, out Vector256<T> c, out Vector256<T> d)
        {
            a = this.A;
            b = this.B;
            c = this.C;
            d = this.D;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out Vector512<T> lo, out Vector512<T> hi)
        {
            lo = default;
            hi = default;
        }

        /// <summary>
        /// Interprets the pair over an alternate domain
        /// </summary>
        /// <typeparam name="U">The alternate type</typeparam>
        [MethodImpl(Inline)]
        public Vector1024<U> As<U>()
            where U : unmanaged
                => Unsafe.As<Vector1024<T>,Vector1024<U>>(ref Unsafe.AsRef(in this));

        [MethodImpl(Inline)]
        public bool Equals(in Vector1024<T> rhs)
            => A.Equals(rhs.A) && B.Equals(rhs.B);


        public override int GetHashCode()
            => HashCode.Combine(A,B);

        public override bool Equals(object obj)
            => obj is Vector1024<T> x && Equals(x);
    }
}