//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = BitPos;

    [ApiHost, StructLayout(LayoutKind.Sequential, Pack =1)]
    public struct BitPos
	{
        const NumericKind Closure = UnsignedInts;

		/// <summary>
		/// Computes the order-invariant absolute distance between two positions
		/// </summary>
		/// <param name="a">The left position</param>
		/// <param name="b">The right position</param>
		[MethodImpl(Inline), Op]
		public static uint delta(BitPos a, BitPos b)
			=> (uint)(a.LinearIndex > b.LinearIndex ? a.LinearIndex - b.LinearIndex : b.LinearIndex - a.LinearIndex);

		[MethodImpl(Inline), Op]
        public static ref BitPos add(ref BitPos pos, uint offset)
        {
            var i = pos.LinearIndex + offset;
            pos.CellIndex = BitPos.linearize(pos.CellWidth,i);
            pos.BitOffset = bits.offmod(pos.CellWidth, i);
            return ref pos;
        }

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static ref BitPos<T> add<T>(ref BitPos<T> pos, uint offset)
            where T : unmanaged
        {
            var i = pos.LinearIndex + offset;
            pos.CellIndex = BitPos.linearize(pos.CellWidth, i);
            pos.BitOffset = bits.offmod(pos.CellWidth, i);
            return ref pos;
        }

		[MethodImpl(Inline), Op, Closures(Closure)]
		public static uint count<T>(in BitPos<T> i0, in BitPos<T> i1)
            where T : unmanaged
			    => (uint)math.abs((long)i0.LinearIndex - (long)i1.LinearIndex) + 1;

		[MethodImpl(Inline), Op]
        public static ref BitPos inc(ref BitPos pos)
        {
            if(pos.BitOffset < pos.CellWidth - 1)
                pos.BitOffset++;
            else
            {
                pos.CellIndex++;
                pos.BitOffset = 0;
            }

            return ref pos;
        }

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static ref BitPos<T> inc<T>(ref BitPos<T> pos)
            where T : unmanaged
        {
            if(pos.BitOffset < pos.CellWidth - 1)
                pos.BitOffset++;
            else
            {
                pos.CellIndex++;
                pos.BitOffset = 0;
            }

            return ref pos;
        }

		[MethodImpl(Inline), Op]
        public static ref BitPos dec(ref BitPos pos)
        {
            if(pos.BitOffset > 0)
                --pos.BitOffset;
            else
            {
                if(pos.CellIndex != 0)
                {
                    pos.BitOffset = pos.CellWidth - 1;
                    --pos.CellIndex;
                }
            }

            return ref pos;
        }

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static ref BitPos<T> dec<T>(ref BitPos<T> pos)
            where T : unmanaged
        {
            if(pos.BitOffset > 0)
                --pos.BitOffset;
            else
            {
                if(pos.CellIndex != 0)
                {
                    pos.BitOffset = pos.CellWidth - 1;
                    --pos.CellIndex;
                }
            }

            return ref pos;
        }

		[MethodImpl(Inline), Op]
        public static ref BitPos sub(ref BitPos pos, uint bitindex)
        {
            var newIndex = pos.LinearIndex - bitindex;
            if(newIndex > 0)
			{
				pos.CellIndex = linearize(pos.CellWidth, bitindex);
				pos.BitOffset = bits.offmod(pos.CellWidth, bitindex);
			}
            else
            {
				pos.CellIndex = 0;
				pos.BitOffset = 0;
			}

            return ref pos;
        }

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static ref BitPos<T> sub<T>(ref BitPos<T> pos, uint bitindex)
            where T : unmanaged
        {
            var newIndex = pos.LinearIndex - bitindex;
            if(newIndex > 0)
			{
				pos.CellIndex = linearize(pos.CellWidth, bitindex);
				pos.BitOffset = bits.offmod(pos.CellWidth, bitindex);
			}
            else
            {
				pos.CellIndex = 0;
				pos.BitOffset = 0;
			}

            return ref pos;
        }

		[MethodImpl(Inline), Op]
        public static bool eq(in BitPos a, in BitPos b)
			=> a.CellIndex == b.CellIndex
            && a.BitOffset == b.BitOffset
			&& a.CellWidth == b.CellWidth;

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static bool eq<T>(in BitPos<T> a, in BitPos<T> b)
            where T : unmanaged
                => a.CellIndex == b.CellIndex
                && a.BitOffset == b.BitOffset;

		/// <summary>
		/// Defines a bit position predicated on the width and container-relative index of a storage cell and a cell-relative bit offset
		/// </summary>
        /// <param name="w">The storage cell width</param>
		/// <param name="cellindex">The container-relative cell index</param>
		/// <param name="offset">The cell-relative bit offset</param>
		[MethodImpl(Inline), Op]
		public static BitPos bitpos(uint w, uint cellindex, uint offset)
			=> new BitPos(w, cellindex, offset);

		/// <summary>
		/// Defines a bit position predicated on a parametric cell type and a cell-relative bit offset
		/// </summary>
		/// <param name="cellindex">The container-relative cell index</param>
		/// <param name="offset">The cell-relative bit offset</param>
		[MethodImpl(Inline), Op, Closures(Closure)]
		public static BitPos<T> bitpos<T>(uint cellindex, uint offset)
			where T : unmanaged
				=> new BitPos<T>(cellindex, offset);

        /// <summary>
        /// Defines a bit position, relative to a T-valued sequence, predicated on a linear index
        /// </summary>
        /// <param name="index">The sequence-relative index of the target bit</param>
        /// <typeparam name="T">The sequence element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitPos<T> bitpos<T>(uint index)
            where T : unmanaged
				=> new BitPos<T>(linearize(sys.width<T>(), index), bits.offmod(sys.width<T>(), index));

		/// <summary>
		/// Computes a linear bit index from a cell index and cell-relative offset
		/// </summary>
		/// <param name="w">The cell width</param>
		/// <param name="cellindex">The cell index</param>
		/// <param name="offset">The cell-relative offset of the bit</param>
		[MethodImpl(Inline), Op]
		public static uint linearize(uint w, uint cellindex, uint offset)
			=> cellindex*w + offset;

		[MethodImpl(Inline), Op]
        public static uint linearize(in BitPos src)
            => linearize(src.CellWidth, src.CellIndex, src.BitOffset);

        /// <summary>
        /// Computes the cell index of a linear bit index
        /// </summary>
        /// <param name="w">The width of a storage cell</param>
        /// <param name="index">The linear bit index</param>
		[MethodImpl(Inline), Op]
        public static uint linearize(uint w, uint index)
			=> index/w;

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
			get => linearize(this);
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