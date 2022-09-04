//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct PeSectionHeader
    {
        const string TableId = "section.headers";

        [Render(64)]
        public FileName File;

        [Render(16)]
        public string SectionName;

        [Render(16)]
        public Address32 CodeBase;

        [Render(16)]
        public Address32 GptRva;

        [Render(16)]
        public ByteSize GptSize;

        [Render(16)]
        public Address32 RawDataAddress;

        [Render(16)]
        public ByteSize RawDataSize;

        [Render(16)]
        public Address32 EntryPoint;

        [Render(48)]
        public SectionCharacteristics SectionFlags;

        [Render(1)]
        public _FileUri FullPath;
    }
}