//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
	/// <summary>
	/// Represents a complex value with unsigned 16-bit integer components
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct ComplexU16 : IEquatable<ComplexU16>
	{
		/// <summary>
		/// Loads a span of span of complext values from a source span where adjacent
		/// entries (i,i+j) are interpreted respectively as real and imaginary components
		/// </summary>
		/// <param name="src">The source span, which must contain an even number of elements</param>
		[MethodImpl(Inline)]
		public static Span<ComplexU16> Load(Span<ushort> src)
		{
			if(src.Length % 2 != 0)
				throw new Exception("Missing component");
			return MemoryMarshal.Cast<ushort,ComplexU16>(src);
		}

        /// <summary>
        /// Tests the operands for equality
        /// </summary>
        /// <param name="lhs">The first operand</param>
        /// <param name="rhs">The second operand</param>
		[MethodImpl(Inline)]
        public static bool operator ==(in ComplexU16 lhs, in ComplexU16 rhs)
            => lhs.im == rhs.im && lhs.re == rhs.re;

        /// <summary>
        /// Tests the operands for inequality
        /// </summary>
        /// <param name="lhs">The first operand</param>
        /// <param name="rhs">The second operand</param>
		[MethodImpl(Inline)]
        public static bool operator !=(in ComplexU16 lhs, in ComplexU16 rhs)
            => (lhs.im != rhs.im) || (lhs.re != rhs.re);

		/// <summary>
		/// Implcitly converts a 2-tuple to a complex value
		/// </summary>
		/// <param name="x">The source value</param>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
		public static implicit operator ComplexU16(in (ushort re, ushort im) x)
			=> new ComplexU16(x);

		/// <summary>
		/// Implcitly converts a complex value to a 2-tuple
		/// </summary>
		/// <param name="x">The source value</param>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
		public static implicit operator (ushort re, ushort im)(in ComplexU16 x)
			=> (x.re, x.im);

		/// <summary>
		/// Specifies the real component
		/// </summary>
		public ushort re;

		/// <summary>
		/// Specifies the imaginary component
		/// </summary>
        public ushort im;

		/// <summary>
		/// Constructs the complex number from a tuple with real and imaginary parts
		/// </summary>
		/// <param name="re">The real component</param>
		/// <param name="im">The imaginary component</param>
		[MethodImpl(Inline)]
        public ComplexU16((ushort re, ushort im) x)
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
        public ComplexU16(ushort re, ushort im)
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
		public void Deconstruct(out ushort re, out ushort im)
		{
			re = this.re;
			im = this.im;
		}

        /// <summary>
        /// Renders the value as a string per supplied options
        /// </summary>
        /// <param name="tupelize">Whether the value should be represented as a tuple (re,im) or in canonical form re +imi</param>
		public string Format(bool tupleize = false)
			=> tupleize ? $"({re}, {im})" : $"{re} + {im}i";

		public override string ToString()
			=>  Format();

        public override int GetHashCode()
            => $"{re}{im}".GetHashCode();

        public override bool Equals(object src)
            => src is ComplexU16 c ? (c == this) : false;

        [MethodImpl(Inline)]
        public bool Equals(ComplexU16 src)
            => this == src;
	}
}