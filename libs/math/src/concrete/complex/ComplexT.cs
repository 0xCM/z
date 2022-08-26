//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a complex number parameterized over the primal types
    /// </summary>
	[StructLayout(LayoutKind.Sequential)]
    public readonly struct Complex<T> : IEquatable<Complex<T>>
        where T : unmanaged
    {
        public readonly T re;

        public readonly T im;

        /// <summary>
        /// Formats the real and imaginary parts of a complex number in one of two canonical forms
        /// </summary>
        /// <param name="re">The real part</param>
        /// <param name="im">The imaginary part</param>
        /// <param name="tupelize">Whether the value should be represented as a tuple (re,im) or in canonical form re +imi</param>
        [MethodImpl(Inline)]
		public static string Format(T re, T im, bool tupelize = false)
			=> tupelize ? $"({re}, {im})" : $"{re} + {im}i";

        /// <summary>
        /// Creates a combined hash code for the real and imaginary parts of a complex number
        /// </summary>
        /// <param name="re">The real part</param>
        /// <param name="im">The imaginary part</param>
        [MethodImpl(Inline)]
        public static int Hash(T re, T im)
            => HashCode.Combine(re,im);

        /// <summary>
        /// Implicitly constructs a generic complex value from an ordered pair
        /// interpreted as the real/imaginary parts, respectively, of a
        /// complex number
        /// </summary>
        /// <param name="re">The real part</param>
        /// <param name="im">The imaginary part</param>
        /// <typeparam name="T">The underlying primal type</typeparam>
		[MethodImpl(Inline)]
        public static implicit operator Complex<T>((T re, T im) x)
            => new Complex<T>(x.re, x.im);

		/// <summary>
        ///  Creates an ordred pair from the source
		/// </summary>
        /// <param name="re">The real part</param>
        /// <param name="im">The imaginary part</param>
        [MethodImpl(Inline)]
        public static implicit operator (T re, T im)(Complex<T> x)
            => (x.re, x.im);

        /// <summary>
        /// Tests the operands for exact equality
        /// </summary>
        /// <param name="lhs">The first operand</param>
        /// <param name="rhs">The second operand</param>
		[MethodImpl(Inline)]
        public static bool operator ==(in Complex<T> lhs, in Complex<T> rhs)
            => lhs.Equals(rhs);

        /// <summary>
        /// Tests the operands for inequality
        /// </summary>
        /// <param name="lhs">The first operand</param>
        /// <param name="rhs">The second operand</param>
		[MethodImpl(Inline)]
        public static bool operator !=(in Complex<T> lhs, in Complex<T> rhs)
            => !lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public Complex(T re, T im = default)
        {
            this.re = re;
            this.im = im;
        }

		/// <summary>
		/// Partitions the complex number into real and imaginary components
		/// </summary>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
		public void Deconstruct(out T re, out T im)
		{
			re = this.re;
			im = this.im;
		}

        [MethodImpl(Inline)]
        public bool Equals(Complex<T> src)
            => src.re.Equals(re) && src.im.Equals(src.im);

		public override string ToString()
			=>  Format(re,im);

        public override int GetHashCode()
            => Hash(re,im);

        public override bool Equals(object src)
            => src is Complex<T> c ? Equals(c) : false;
    }
}