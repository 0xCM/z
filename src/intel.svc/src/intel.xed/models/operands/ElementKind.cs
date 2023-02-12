//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        /// <summary>
        ///  all-element-types.txt
        /// </summary>
        [SymSource(xed), DataWidth(num5.Width)]
        public enum ElementKind : byte
        {
            INVALID = 0,

            [Symbol("b80")]
            B80,

            [Symbol("bf16")]
            BF16,

            [Symbol("f16")]
            F16,

            [Symbol("f32")]
            F32,

            [Symbol("f64")]
            F64,

            [Symbol("f80")]
            F80,

            [Symbol("i1")]
            I1,

            [Symbol("i16")]
            I16,

            [Symbol("i32")]
            I32,

            [Symbol("i64")]
            I64,

            [Symbol("i8")]
            I8,

            [Symbol("int")]
            INT,

            [Symbol("struct")]
            STRUCT,

            [Symbol("u128")]
            U128,

            [Symbol("u16")]
            U16,

            [Symbol("u256")]
            U256,

            [Symbol("u32")]
            U32,

            [Symbol("u64")]
            U64,

            [Symbol("u8")]
            U8,

            [Symbol("uint")]
            UINT,

            [Symbol("var")]
            VAR,
       }
    }
}