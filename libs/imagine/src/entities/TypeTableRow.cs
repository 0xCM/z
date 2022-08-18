//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableId)]
    public record struct TypeTableRow : IDbRow<TypeTableRow>, IComparable<TypeTableRow>
    {
        const string TableId = "typetables";

        [Render(8)]
        public uint Seq;

        [Render(32)]
        public Label TypeName;

        [Render(64)]
        public Label LiteralName;

        [Render(8)]
        public ushort Position;

        [Render(12)]
        public byte PackedWidth;

        [Render(12)]
        public uint NativeWidth;

        [Render(16)]
        public ulong LiteralValue;

        [Render(64)]
        public Label Symbol;

        [Render(64)]
        public StringRef Description;

        [MethodImpl(Inline)]
        public int CompareTo(TypeTableRow src)
        {
            var result = TypeName.CompareTo(src.TypeName);
            if(result == 0)
                result = Position.CompareTo(src.Position);
            return result;
        }

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }
    }
}