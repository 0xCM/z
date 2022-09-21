//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CellCalcs
    {
        /// <summary>
        /// Computes the number of bits covered by a rectangular region and predicated on natural dimensions
        /// </summary>
        /// <param name="rows">The grid row count</param>
        /// <param name="cols">The grid col count</param>
        [MethodImpl(Inline)]
        public static BitWidth gridwidth<M,N,T>(M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => NatCalc.mul(m,n);
                        
        [MethodImpl(Inline)]
        public static GridIndex index<M,N,T>(int row, int col, M m = default, N n = default, T t =default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var rowCellCount = ScalarCast.uint16(mincells<N,T>());
            var rowOffset = ScalarCast.uint32(rowCellCount*row);
            return index(
                CellIndex: ScalarCast.uint16(rowOffset + BitWidth.div<T>((ulong)col)),
                RowCellCount: rowCellCount,
                BitOffset: (byte)ScalarCast.uint8(BitWidth.mod<T>((ulong)col)),
                BitIndex: ScalarCast.uint32(rowOffset + col),
                RowIndex: row,
                ColIndex: col);
        }

        [MethodImpl(Inline), Op]
        public static GridIndex index(ushort CellIndex, ushort RowCellCount, byte BitOffset, uint BitIndex, int RowIndex, int ColIndex)
            => new GridIndex(CellIndex, RowCellCount, BitOffset, BitIndex, RowIndex, ColIndex);
    }
}