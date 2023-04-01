//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public record struct PeSectionHeader : IComparable<PeSectionHeader>, ISequential<PeSectionHeader>
    {
        const string TableId = "section.headers";

        [Render(12)]
        public uint Seq;
        
        [Render(92)]
        public FileName File;

        [Render(16)]
        public string SectionName;

        [Render(16)]
        public Address32 SectionBase;

        [Render(16)]
        public ByteSize SectionSize;

        [Render(48)]
        public SectionCharacteristics SectionFlags;

        uint ISequential.Seq { get => Seq; set => Seq = value; }

        public PeSectionHeader WithFile(FileName src)
        {
            File = src;
            return this;
        }

        public int CompareTo(PeSectionHeader src)
        {
            var result = File.CompareTo(src.File);
            if(result == 0)
                result = SectionBase.CompareTo(src.SectionBase);
            return result;
        }        
    }
}