//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [Record(TableName), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct MacroDef
        {
            public const byte FieldCount = 8;

            public const string TableName = "xed.rules.macros";

            public uint Seq;

            public RuleMacroKind MacroName;

            public byte Fields;

            public MacroExpansion E0;

            public MacroExpansion E1;

            public MacroExpansion E2;

            public MacroExpansion E3;

            public MacroExpansion E4;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,8,26,26,26,26,26};

            public static MacroDef Empty => default;
        }
    }
}