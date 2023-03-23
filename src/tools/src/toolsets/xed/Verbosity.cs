//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedTool
    {
        [SymSource(group)]
        public enum Verbosity : byte
        {
            [Symbol("0", "Quiet")]
            Level0,

            [Symbol("1", "Errors")]
            Level1,

            [Symbol("2", "Info")]
            Level2,

            [Symbol("3", "Trace")]
            Level3,

            [Symbol("5", "Very verbose")]
            Level5,
        }
    }
}