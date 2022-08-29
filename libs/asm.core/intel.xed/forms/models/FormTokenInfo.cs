//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedForms;

    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
    public struct FormTokenInfo
    {
        const string TableId = "xed.forms.tokens";

        [Render(8)]
        public uint Seq;

        [Render(16)]
        public FormTokenKind TokenKind;

        [Render(18)]
        public FormToken TokenValue;        
    }    
}