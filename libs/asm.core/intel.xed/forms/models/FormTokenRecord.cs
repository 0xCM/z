//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedForms
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
        public struct FormTokenRecord
        {
            public const string TableId = "xed.forms.tokens";

            public uint Seq;

            public FormTokenKind TokenKind;

            public FormToken TokenValue;

            public static ReadOnlySpan<byte> RenderWidths => new byte[3]{8,16,18};
        }
    }
}