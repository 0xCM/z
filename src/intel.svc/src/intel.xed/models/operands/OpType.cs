//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [SymSource(xed)]
        public enum OpType : byte
        {
            [Symbol("")]
            INVALID,

            [Symbol("ERROR")]
            ERROR,

            [Symbol("IMM")]
            IMM,

            [Symbol("IMM_CONST")]
            IMM_CONST,

            [Symbol("NT_LOOKUP_FN")]
            NT_LOOKUP_FN,

            [Symbol("NT_LOOKUP_FN2")]
            NT_LOOKUP_FN2,

            [Symbol("NT_LOOKUP_FN4")]
            NT_LOOKUP_FN4,

            [Symbol("REG")]
            REG,
        }
    }
}