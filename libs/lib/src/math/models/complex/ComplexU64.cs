//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
	/// <summary>
	/// Represents a complex value with unsigned 64-bit integer components
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct ComplexU64 : IEquatable<ComplexU64>
	{
		/// <summary>
		/// Loads a span of span of complext values from a source span where adjacent
		/// entries (i,i+j) are interpreted respectively as real and imaginary components
		/// </summary>
		/// <param name="src">The source span, which must contain an even number of elements</param>
		[MethodImpl(Inline)]
		public static Span<ComplexU64> Load(Span<ulong> src)
		{
			if(src.Length % 2 != 0)
				throw new Exception("Missing component");
			return MemoryMarshal.Cast<ulong,ComplexU64>(src);
		}

		/// <summary>
		/// Implicitly constructs a <see cref='Complex<float>'/> value from its equivalent non-generic representation
		/// </summary>
		/// <param name="src">The source value</param>
		[MethodImpl(Inline)]
		public static implicit operator Complex<ulong>(ComplexU64 src)
			=> (src.re, src.im);

		/// <summary>
		/// Implicitly constructs a <see cref='ComplexF32'/> value from its equivalent generic representation
		/// </summary>
		/// <param name="src">The source value</param>
		[MethodImpl(Inline)]
		public static implicit operator ComplexU64(Complex<ulong> src)
			=> (src.re, src.im);

        /// <summary>
        /// Tests the operands for equality
        /// </summary>
        /// <param name="lhs">The first operand</param>
        /// <param name="rhs">The second operand</param>
		[MethodImpl(Inline)]
        public static bool operator ==(in ComplexU64 lhs, in ComplexU64 rhs)
            => lhs.im == rhs.im && lhs.re == rhs.re;

        /// <summary>
        /// Tests the operands for inequality
        /// </summary>
        /// <param name="lhs">The first operand</param>
        /// <param name="rhs">The second operand</param>
		[MethodImpl(Inline)]
        public static bool operator !=(in ComplexU64 lhs, in ComplexU64 rhs)
            => (lhs.im != rhs.im) || (lhs.re != rhs.re);

		/// <summary>
		/// Implcitly converts a 2-tuple to a complex value
		/// </summary>
		/// <param name="x">The source value</param>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
		public static implicit operator ComplexU64(in (ulong re, ulong im) x)
			=> new ComplexU64(x);

		/// <summary>
		/// Implcitly converts a complex value to a 2-tuple
		/// </summary>
		/// <param name="x">The source value</param>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
		public static implicit operator (ulong re, ulong im)(in ComplexU64 x)
			=> (x.re, x.im);

		/// <summary>
		/// Specifies the real component
		/// </summary>
		public ulong re;

		/// <summary>
		/// Specifies the imaginary component
		/// </summary>
        public ulong im;

		/// <summary>
		/// Constructs the complex number from a tuple with real and imaginary parts
		/// </summary>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
        public ComplexU64((ulong re, ulong im) x)
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
        public ComplexU64(ulong re, ulong im)
		{
			this.re = re;
			this.im = im;
		}

		/// <summary>
		/// Partitions the complex number into real and imanginary components
		/// </summary>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
		public void Deconstruct(out ulong re, out ulong im)
		{
			re = this.re;
			im = this.im;
		}

        /// <summary>
        /// Formats the real and imaginar parts of a complex number in one of two canonical forms
        /// </summary>
        /// <param name="tupelize">Whether the value should be represented as a tuple (re,im) or in canonical form re +imi</param>
		public string Format(bool tupelize = false)
			=> Complex<ulong>.Format(re,im,tupelize);

        public override int GetHashCode()
             => Complex<ulong>.Hash(re,im);

		public override string ToString()
			=>  Format();

        public override bool Equals(object src)
            => src is ComplexU64 c ? (c == this) : false;

        [MethodImpl(Inline)]
        public bool Equals(ComplexU64 src)
            => this == src;
	}
}