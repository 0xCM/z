//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public record struct PeSectionHeader
    {
        const string TableId = "section.headers";

        [Render(12)]
        public uint Seq;

        [Render(16)]
        public string SectionName;

        [Render(16)]
        public Address32 RawDataAddress;

        [Render(16)]
        public ByteSize RawDataSize;

        [Render(48)]
        public SectionCharacteristics SectionFlags;
    }
}