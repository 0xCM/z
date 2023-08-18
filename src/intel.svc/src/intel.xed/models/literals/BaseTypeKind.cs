//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [SymSource(xed), DataWidth(num5.Width)]
    public enum BaseTypeKind : byte
    {
        INVALID,

        B80,

        BF16,

        F16,

        F32,

        F64,

        F80,

        I1,

        I16,

        I32,

        I64,

        I8,

        INT,

        STRUCT,

        U128,

        U16,

        U256,

        U32,

        U64,

        U8,

        UINT,

        VAR,
    }
}
