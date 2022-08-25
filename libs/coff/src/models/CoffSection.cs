//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using W = AsmColWidths;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CoffSection : IComparable<CoffSection>
    {
        public const string TableId = "coff.sections";

        public const byte FieldCount = 11;

        [Render(W.Seq)]
        public uint Seq;

        [Render(W.OriginId)]
        public Hex32 OriginId;

        [Render(16)]
        public ushort SectionNumber;

        [Render(16)]
        public @string SectionName;

        [Render(16)]
        public CoffSectionKind SectionKind;

        [Render(16)]
        public ByteSize RawDataSize;

        [Render(16)]
        public Address32 RawDataAddress;

        [Render(16)]
        public uint RelocCount;

        [Render(16)]
        public Address32 RelocAddress;

        [Render(78)]
        public ImageSectionFlags Flags;

        [Render(1)]
        public FileUri Source;

        public int CompareTo(CoffSection src)
        {
            var result = Source.Format().CompareTo(src.Source.Format());
            if(result  == 0)
            {
                result = SectionNumber.CompareTo(src.SectionNumber);
                if(result == 0)
                    result = RawDataAddress.CompareTo(src.RawDataAddress);
            }
            return result;
        }
    }
}