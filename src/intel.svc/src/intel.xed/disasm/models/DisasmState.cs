//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDisasm
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct DisasmState
        {
            public Disp RELBRVal;

            public asci32 AGENVal;

            public asci32 MEM0Val;

            public asci32 MEM1Val;

            public OperandState RuleState;

            public static DisasmState Empty => default;
        }
    }
}