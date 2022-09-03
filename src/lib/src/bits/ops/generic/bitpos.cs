//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class gbits
    {
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
				=> new BitPos<T>(linearize(width<T>(), index), bits.offmod(width<T>(), index));

        /// <summary>
        /// Defines a bit position, relative to a T-valued sequence, predicated on a linear index
        /// </summary>
		/// <param name="index">The linear index</param>
        /// <param name="cell">The cell index</param>
        /// <param name="offset">The cell-relative offset</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
		public static void bitpos<T>(uint index, out uint cell, out uint offset)
            where T : unmanaged
        {
            var w = (ushort)width<T>();
			cell = linearize(w, index);
            offset = bits.offmod(w, index);
        }

		/// <summary>
		/// Defines a bit position predicated on the width of a storage cell and the 0-based linear bit index
		/// </summary>
        /// <param name="w">The storage cell width</param>
		/// <param name="index">The linear bit index</param>
		[MethodImpl(Inline), Op]
		public static BitPos bitpos(uint w, uint index)
			=> new BitPos(w, gbits.linearize(w, index), bits.offmod(w, index));
    }
}