//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(num3.Width)]
        public enum RegRole : byte
        {
            INVALID,

            [Symbol("NORMAL", "Register is a normal register")]
            NORMAL,

            [Symbol("SEGREG0", "The segment register associated with the first memop")]
            SEGREG0,

            [Symbol("SEGREG1", "The segment register associated with the second memop")]
            SEGREG1,

            [Symbol("BASE0", "The base register associated with the first memop")]
            BASE0,

            [Symbol("BASE1", "The base register associated with the second memop")]
            BASE1,

            [Symbol("INDEX", "The index register associated with the first memop")]
            INDEX,
        }
    }
}