//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

partial class XedModels
{
    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct FieldImport : IComparable<FieldImport>
    {
        const string TableId = "xed.fields";

        [Render(32)]
        public asci32 Name;

        [Render(32)]
        public EnumFormat<XedFieldKind> FieldType;

        [Render(8)]
        public byte Width;

        [Render(1)]
        public VisibilityKind Visibility;

        public int CompareTo(FieldImport src)
            => Name.CompareTo(src.Name);

        public static FieldImport Empty => default;
    }
}
