//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = gbits;

    [StructLayout(LayoutKind.Sequential, Pack =1)]
    public struct BitPos
	{
        /// <summary>
		/// A container-relative 0-based cell offset
		/// </summary>
		public uint CellIndex;

		/// <summary>
		/// A cell-relative bit offset
		/// </summary>
		public uint BitOffset;

		/// <summary>
		/// The bit-width of a cell
		/// </summary>
		public uint CellWidth;

		[MethodImpl(Inline)]
		public BitPos(uint cellwidth, uint cellindex, uint bitoffset)
		{
			CellWidth = cellwidth;
			CellIndex = cellindex;
			BitOffset = bitoffset;
		}

		/// <summary>
		/// The linear/absolute bit index of the represented position
		/// </summary>
		public uint LinearIndex
		{
			[MethodImpl(Inline)]
			get => api.linearize(this);
		}

		[MethodImpl(Inline)]
        public void Add(uint bitindex)
            => api.add(ref this, bitindex);

		[MethodImpl(Inline)]
        public void Sub(uint bitindex)
            => api.sub(ref this, bitindex);

		[MethodImpl(Inline)]
        public void Dec()
            => api.dec(ref this);

		[MethodImpl(Inline), Op]
        public void Inc()
            => api.inc(ref this);

		[MethodImpl(Inline)]
		public bool Equals(BitPos src)
            => api.eq(this, src);

		public string Format()
			=> string.Format("({0},{1}/{2})", LinearIndex, CellIndex, BitOffset);

		public override string ToString()
			=> Format();

		public override int GetHashCode()
			=> HashCode.Combine(CellWidth, CellIndex, BitOffset);

		public override bool Equals(object rhs)
            => rhs is BitPos x && Equals(x);

		[MethodImpl(Inline)]
		public static BitPos operator +(BitPos pos, uint count)
		{
			pos.Add(count);
            return pos;
		}

		[MethodImpl(Inline)]
		public static BitPos operator -(BitPos pos, uint count)
		{
            pos.Sub(count);
            return pos;
		}

		[MethodImpl(Inline)]
		public static uint operator -(BitPos a, BitPos b)
			=> api.delta(a,b);

		[MethodImpl(Inline)]
		public static BitPos operator --(BitPos pos)
		{
            pos.Dec();
            return pos;
		}

		[MethodImpl(Inline)]
		public static BitPos operator ++(BitPos pos)
		{
			pos.Inc();
            return pos;
		}

		[MethodImpl(Inline)]
		public static bool operator <(BitPos a, BitPos b)
			=> a.LinearIndex < b.LinearIndex;

		[MethodImpl(Inline)]
		public static bool operator <=(BitPos a, BitPos b)
			=> a.LinearIndex <= b.LinearIndex;

		[MethodImpl(Inline)]
		public static bool operator >(BitPos a, BitPos b)
			=> a.LinearIndex > b.LinearIndex;

		[MethodImpl(Inline)]
		public static bool operator >=(BitPos a, BitPos b)
			=> a.LinearIndex >= b.LinearIndex;

		[MethodImpl(Inline)]
		public static bool operator ==(BitPos a, BitPos b)
			=> a.Equals(b);

		[MethodImpl(Inline)]
		public static bool operator !=(BitPos a, BitPos b)
			=> !a.Equals(b);
	}
}