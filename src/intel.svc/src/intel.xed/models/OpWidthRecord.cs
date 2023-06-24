//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [Record(TableId)]
        public struct OpWidthRecord : IComparable<OpWidthRecord>
        {
            public const string TableId = "xed.widths";

            [Render(12)]
            public WidthCode Code;

            [Render(12)]
            public asci16 Name;

            [Render(12)]
            public ElementType ElementType;

            [Render(12)]
            public ushort ElementWidth;

            [Render(12)]
            public BitSegType SegType;

            [Render(12)]
            public ushort Width64;

            [Render(12)]
            public ushort Width32;

            [Render(12)]
            public ushort Width16;

            public byte ElementCount
            {
                [MethodImpl(Inline)]
                get => SegType.CellCount;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Code == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Code != 0;
            }

            public string Format()
                => string.Format("{0}:{1}w", XedRender.format(Code), Width64);

            public override string ToString()
                => Format();

            public int CompareTo(OpWidthRecord src)
                => Name.CompareTo(src.Name);

            public static OpWidthRecord Empty => default;
        }
    }
}