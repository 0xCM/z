//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Sized;

    using api = gbits;

	/// <summary>
	/// Identifies a bit position within a contiguous sequence of T-element values together with their cell index/bit offsets
	/// </summary>
	[StructLayout(LayoutKind.Sequential,Size = 32)]
	public struct BitPos<T>
        where T : unmanaged
	{
		/// <summary>
		/// The container-relative 0-based offset of the segment
		/// </summary>
		public uint CellIndex;

		/// <summary>
		/// The segment-relative offset of the bit
		/// </summary>
		public uint BitOffset;

		[MethodImpl(Inline)]
		public BitPos(uint cellindex, uint bitoffset)
		{
			CellIndex = cellindex;
			BitOffset = bitoffset;
		}

		/// <summary>
		/// Specifies the number of bits that can be placed in one segment
		/// </summary>
		public uint CellWidth
        {
			[MethodImpl(Inline)]
			get => width<T>();
        }

		public uint LinearIndex
		{
			[MethodImpl(Inline)]
			get => api.linearize(this);
		}

		[MethodImpl(Inline)]
        public uint Width(BitPos<T> i1)
            => api.count(this, i1);

		[MethodImpl(Inline)]
		public uint CountTo(in BitPos<T> dst)
			=> api.count(this, dst);

		[MethodImpl(Inline)]
        public void Add(uint src)
            => api.add(ref this, src);

		[MethodImpl(Inline)]
        public void Sub(uint src)
            => api.sub(ref this, src);

		[MethodImpl(Inline)]
        public void Dec()
            => api.dec(ref this);

		[MethodImpl(Inline)]
        public void Inc()
            => api.inc(ref this);

		[MethodImpl(Inline)]
		public bool Equals(BitPos<T> src)
            => api.eq(this, src);

		public string Format()
			=> string.Format("({0},{1}/{2})", LinearIndex, CellIndex, BitOffset);

		public override string ToString()
			=> Format();

		public override int GetHashCode()
			=> LinearIndex.GetHashCode();

		public override bool Equals(object rhs)
            => rhs is BitPos<T> x && Equals(x);

		[MethodImpl(Inline)]
		public static BitPos<T>operator +(BitPos<T> a, uint count)
		{
			a.Add(count);
            return a;
		}

		[MethodImpl(Inline)]
		public static BitPos<T> operator -(BitPos<T> a, uint count)
		{
            a.Sub(count);
            return a;
		}

		[MethodImpl(Inline)]
		public static uint operator -(BitPos<T> i0, BitPos<T> i1)
            => i0.Width(i1);

		[MethodImpl(Inline)]
		public static BitPos<T> operator --(BitPos<T> src)
		{
            src.Dec();
            return src;
		}

		[MethodImpl(Inline)]
		public static BitPos<T> operator ++(BitPos<T> src)
		{
			src.Inc();
            return src;
		}

		[MethodImpl(Inline)]
		public static bool operator ==(BitPos<T> a, BitPos<T> b)
			=> a.Equals(b);

		[MethodImpl(Inline)]
		public static bool operator !=(BitPos<T> a, BitPos<T> b)
			=> !a.Equals(b);

		[MethodImpl(Inline)]
		public static bool operator <(BitPos<T> a, BitPos<T> b)
			=> a.LinearIndex < b.LinearIndex;

		[MethodImpl(Inline)]
		public static bool operator <=(BitPos<T> a, BitPos<T> b)
			=> a.LinearIndex <= b.LinearIndex;

		[MethodImpl(Inline)]
		public static bool operator >(BitPos<T> lhs, BitPos<T> rhs)
			=> lhs.LinearIndex > rhs.LinearIndex;

		[MethodImpl(Inline)]
		public static bool operator >=(BitPos<T> lhs, BitPos<T> rhs)
			=> lhs.LinearIndex >= rhs.LinearIndex;

		[MethodImpl(Inline)]
        public static implicit operator BitPos(BitPos<T> src)
            => new BitPos(src.CellWidth, src.CellIndex, src.BitOffset);

		[MethodImpl(Inline)]
        public static implicit operator BitPos<T>((uint cellindex, uint bitoffset) x)
            => new BitPos<T>(x.cellindex, x.bitoffset);

        /// <summary>
        /// The zero position
        /// </summary>
		public static BitPos<T> Zero
			=> default(BitPos<T>);
	}
}