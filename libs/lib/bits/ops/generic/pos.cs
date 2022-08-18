//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class gbits
    {
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
            pos.CellIndex = linearize(pos.CellWidth,i);
            pos.BitOffset = bits.offmod(pos.CellWidth, i);
            return ref pos;
        }

		[MethodImpl(Inline), Op, Closures(Closure)]
        public static ref BitPos<T> add<T>(ref BitPos<T> pos, uint offset)
            where T : unmanaged
        {
            var i = pos.LinearIndex + offset;
            pos.CellIndex = linearize(pos.CellWidth, i);
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
        /// Computes the cell index of a linear bit index
        /// </summary>
        /// <param name="w">The width of a storage cell</param>
        /// <param name="index">The linear bit index</param>
		[MethodImpl(Inline), Op]
        public static uint linearize(uint w, uint index)
			=> index/w;

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
    }
}