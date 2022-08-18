//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Dynop
    {
        /// <summary>
        /// Loads executable code into a token-identified buffer and covers it with a parametric ternary operator
        /// </summary>
        /// <param name="dst">The buffer token</param>
        /// <param name="src">The code to load</param>
        /// <typeparam name="T">The operand type</typeparam>
        public static TernaryOp<T> EmitTernaryOp<T>(this BufferToken dst, ApiCodeBlock src)
            where T : unmanaged
                => dst.Load(src.Encoded).EmitTernaryCellOp<T>(src.Id);
    }
}