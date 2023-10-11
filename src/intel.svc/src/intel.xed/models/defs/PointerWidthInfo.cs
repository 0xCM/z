//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct PointerWidthInfo
    {
        public const string TableId = "xed.widths.pointers";

        public const byte FieldCount = 4;

        [Render(12)]
        public asci16 Name;

        [Render(6)]
        public char Symbol;

        [Render(1)]
        public NativeSize Size;
    }
}
