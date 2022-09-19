//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedGrids
    {
        [Flags]
        public enum ValueKind : byte
        {
            None = 0,

            Bit = 1,

            Bits = 2,

            Byte = 4,

            Word = 8,

            Operator = 16,

            Indicator = 32,

            Refinement = 64,
        }
    }
}