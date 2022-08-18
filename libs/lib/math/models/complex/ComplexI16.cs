//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
	/// <summary>
	/// Represents a complex value with signed 16-bit integer components
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct ComplexI16 : IEquatable<ComplexI16>
	{
		/// <summary>
		/// Loads a span of span of complext values from a source span where adjacent
		/// entries (i,i+j) are shorterpreted respectively as real and imaginary components
		/// </summary>
		/// <param name="src">The source span, which must contain an even number of elements</param>
		[MethodImpl(Inline)]
		public static Span<ComplexI16> Load(Span<short> src)
		{
			if(src.Length % 2 != 0)
				throw new Exception("Missing component");
			return MemoryMarshal.Cast<short,ComplexI16>(src);
		}

        /// <summary>
        /// Subtracts the second operand from the first
        /// </summary>
        /// <param name="lhs">The first operand</param>
        /// <param name="rhs">The second operand</param>
		[MethodImpl(Inline)]
        public static ComplexI16 operator -(in ComplexI16 lhs, in ComplexI16 rhs)
            => ((short)(lhs.re - rhs.re), (short)(lhs.im - rhs.im));

        /// <summary>
        /// Adds the second operand to the first
        /// </summary>
        /// <param name="lhs">The first operand</param>
        /// <param name="rhs">The second operand</param>
		[MethodImpl(Inline)]
        public static ComplexI16 operator +(in ComplexI16 lhs, in ComplexI16 rhs)
            => ((short)(lhs.re + rhs.re), (short)(lhs.im + rhs.im));

        /// <summary>
        /// Tests the operands for equality
        /// </summary>
        /// <param name="lhs">The first operand</param>
        /// <param name="rhs">The second operand</param>
		[MethodImpl(Inline)]
        public static bool operator ==(in ComplexI16 lhs, in ComplexI16 rhs)
            => lhs.im == rhs.im && lhs.re == rhs.re;

        /// <summary>
        /// Tests the operands for inequality
        /// </summary>
        /// <param name="lhs">The first operand</param>
        /// <param name="rhs">The second operand</param>
		[MethodImpl(Inline)]
        public static bool operator !=(in ComplexI16 lhs, in ComplexI16 rhs)
            => (lhs.im != rhs.im) || (lhs.re != rhs.re);

		/// <summary>
		/// Implcitly converts a 2-tuple to a complex value
		/// </summary>
		/// <param name="x">The source value</param>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
		public static implicit operator ComplexI16((short re, short im) x)
			=> new ComplexI16(x);

		/// <summary>
		/// Implcitly converts a complex value to a 2-tuple
		/// </summary>
		/// <param name="x">The source value</param>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
		public static implicit operator (short re, short im)(ComplexI16 x)
			=> (x.re, x.im);

		/// <summary>
		/// Specifies the real component
		/// </summary>
		public short re;

		/// <summary>
		/// Specifies the imaginary component
		/// </summary>
        public short im;

		/// <summary>
		/// Constructs the complex number from a tuple with real and imaginary parts
		/// </summary>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
        public ComplexI16((short re, short im) x)
		{
			this.re = x.re;
			this.im = x.im;
		}

		/// <summary>
		/// Constructs the complex number from real and imaginary components
		/// </summary>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
        public ComplexI16(short re, short im)
		{
			this.re = re;
			this.im = im;
		}

		/// <summary>
		/// Partitions the complex number shorto real and imanginary components
		/// </summary>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
		public void Deconstruct(out short re, out short im)
		{
			re = this.re;
			im = this.im;
		}

        /// <summary>
        /// Formats the real and imaginar parts of a complex number in one of two canonical forms
        /// </summary>
        /// <param name="tupelize">Whether the value should be represented as a tuple (re,im) or in canonical form re +imi</param>
		public string Format(bool tupelize = false)
			=> Complex<short>.Format(re,im,tupelize);

        public override int GetHashCode()
             => Complex<short>.Hash(re,im);

        [MethodImpl(Inline)]
        public bool Equals(ComplexI16 src)
            => this == src;

		public override string ToString()
			=>  Format();

        public override bool Equals(object src)
            => src is ComplexI16 c ? (c == this) : false;

	}
}