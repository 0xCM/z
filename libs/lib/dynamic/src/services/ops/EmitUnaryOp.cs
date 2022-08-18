//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Dynop
    {
        /// <summary>
        /// Loads executable code into a token-identified buffer and covers it with a parametric unary operator
        /// </summary>
        /// <param name="buffer">The buffer token</param>
        /// <param name="src">The code to load</param>
        /// <typeparam name="T">The operand type</typeparam>
        public static UnaryOp<T> EmitUnaryOp<T>(this BufferToken buffer, ApiCodeBlock src)
            where T : unmanaged
                => buffer.Load(src.Encoded).EmitUnaryCellOp<T>(src.Id);
    }
}