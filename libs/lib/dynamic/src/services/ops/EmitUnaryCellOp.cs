//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Dynop
    {
        /// <summary>
        /// Loads executable source into an identified buffer and creates a fixed unary operator over the buffer
        /// </summary>
        /// <param name="buffer">The target buffer</param>
        /// <param name="src">The executable source</param>
        /// <typeparam name="F">The fixed operand type</typeparam>
        public static UnaryOp<F> EmitUnaryCellOp<F>(this BufferToken dst, ApiCodeBlock src)
            => (UnaryOp<F>)dst.Handle.EmitCellular(src.Id,  typeof(UnaryOp<F>), typeof(F), typeof(F));

        internal static UnaryOp<T> EmitUnaryCellOp<T>(this IBufferToken dst, OpIdentity id)
            where T : unmanaged
                => (UnaryOp<T>)dst.EmitUnaryCellOp(id,typeof(UnaryOp<T>), typeof(T));

        [Op]
        internal static CellDelegate EmitUnaryCellOp(this IBufferToken dst, OpIdentity id, Type operatorType, Type operandType)
            => dst.Handle.EmitCellular(id, functype: operatorType, result: operandType, args: operandType);
    }
}