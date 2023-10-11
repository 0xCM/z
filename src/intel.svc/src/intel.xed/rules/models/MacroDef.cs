//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [Record(TableName), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct MacroDef
    {
        const string TableName = "xed.rules.macros";

        [Render(8)]
        public uint Seq;

        [Render(24)]
        public RuleMacroKind MacroName;

        [Render(8)]
        public byte Fields;

        [Render(26)]
        public MacroExpansion E0;

        [Render(26)]
        public MacroExpansion E1;

        [Render(26)]
        public MacroExpansion E2;

        [Render(26)]
        public MacroExpansion E3;

        [Render(26)]
        public MacroExpansion E4;

        public static MacroDef Empty => default;
    }
}
