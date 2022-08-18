//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    ///
    /// </summary>
    public enum ApiCommentTarget : byte
    {
        None = 0,

        [Symbol("T")]
        Type,

        // member name="M:Z0.BitBlock`2.op_OnesComplement(Z0.BitBlock{`0,`1}@)">
        // member name="M:Z0.XTend.ToSpan``3(Z0.BitGrid32{``0,``1,``2})"
        [Symbol("M")]
        Method,

        // <member name="F:Z0.BitBlock`1.BitCount">
        [Symbol("F")]
        Field,

        // <member name="P:Z0.BitBlock`2.RequiredWidth">
        [Symbol("P")]
        Property,

        // <param name="m"></param>
        [Symbol("param")]
        Operand,

        // <typeparam name="N">The number of contained bits</typeparam>
        [Symbol("typeparam")]
        Param,
    }
}