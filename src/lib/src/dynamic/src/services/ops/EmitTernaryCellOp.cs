//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial class Dynop
    {
        [Op]
        internal static CellDelegate EmitTernaryCellOp(this IBufferToken dst, OpIdentity id, Type operatorType, Type operandType)
            => dst.Handle.EmitCellular(id, functype:operatorType, result:operandType, args: array(operandType, operandType, operandType));

        /// <summary>
        /// Loads executable source into an identified buffer and creates a fixed unary operator over the buffer
        /// </summary>
        /// <param name="dst">The target buffer</param>
        /// <param name="src">The executable source</param>
        /// <typeparam name="F">The fixed operand type</typeparam>
        public static TernaryOp<F> EmitTernaryCellOp<F>(this BufferToken dst, ApiCodeBlock src)
            => (TernaryOp<F>)dst.Handle.EmitCellular(src.Id, typeof(TernaryOp<F>), typeof(F), typeof(F), typeof(F), typeof(F));

        internal static TernaryOp<T> EmitTernaryCellOp<T>(this IBufferToken dst, OpIdentity id)
            where T : unmanaged
                => (TernaryOp<T>)dst.EmitTernaryCellOp(id,typeof(TernaryOp<T>), typeof(T));
    }
}