//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedRules
{
    [Record(TableName), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct FieldDef : IComparable<FieldDef>
    {
        public const string TableName = "xed.fields.reflected";

        [Render(8)]
        public byte Pos;

        [Render(8)]
        public byte Index;

        [Render(24)]
        public FieldKind Field;

        [Render(16)]
        public asci16 DataType;

        [Render(16)]
        public asci16 NativeType;

        [Render(16)]
        public uint PackedWidth;

        [Render(16)]
        public uint AlignedWidth;

        [Render(16)]
        public uint PackedOffset;

        [Render(16)]
        public uint AlignedOffset;

        [Render(1)]
        public TextBlock Description;

        public DataSize Size
        {
            [MethodImpl(Inline)]
            get => new (PackedWidth, AlignedWidth);
        }

        [MethodImpl(Inline)]
        public int CompareTo(FieldDef src)
            => Index.CompareTo(src.Index);

        public static FieldDef Empty => default;
    }
}
