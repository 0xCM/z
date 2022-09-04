//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = AsmColWidths;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct CoffSymRecord : IComparable<CoffSymRecord>
    {
        const string TableId = "coff.symbols";

        public const byte FieldCount = 10;

        [Render(W.Seq)]
        public uint Seq;

        [Render(W.DocSeq)]
        public uint Section;

        [Render(W.OriginId)]
        public Hex32 OriginId;

        [Render(W.IP)]
        public Address32 Address;

        [Render(8)]
        public uint SymSize;

        [Render(10)]
        public Hex32 Value;

        [Render(16)]
        public SymStorageClass SymClass;

        [Render(8)]
        public ushort AuxCount;

        [Render(48)]
        public @string Name;

        [Render(1)]
        public _FileUri Source;

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq,Section,OriginId);
        }

        public int CompareTo(CoffSymRecord src)
        {
            var result = Source.Format().CompareTo(src.Source.Format());
            if(result  == 0)
            {
                if(result == 0)
                {
                    result = Section.CompareTo(src.Section);
                    if(result == 0)
                        result = Address.CompareTo(src.Address);
                }

            }
            return result;
        }
    }
}