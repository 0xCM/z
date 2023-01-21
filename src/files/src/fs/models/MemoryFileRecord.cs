//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(StructLayout)]
    public record struct MemoryFileRecord
    {
        public const string TableId = "memoryfile";

        [Render(16)]
        public MemoryAddress BaseAddress;

        [Render(16)]
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