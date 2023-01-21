//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(StructLayout)]
    public record struct MemoryFileInfo
    {
        public const string TableId = "memoryfiles";

        [Render(16)]
        public MemoryAddress BaseAddress;

        [Render(12)]
        public ByteSize Size;

        [Render(16)]
        public MemoryAddress EndAddress;

        [Render(16)]
        public Timestamp CreateTS;

        [Render(16)]
        public Timestamp UpdateTS;

        [Render(24)]
        public FileAttributes Attributes;

        [Render(1)]
        public FilePath Path;
    }
}