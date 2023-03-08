//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public record struct PeDirectoryEntry
    {
        public const string TableId = "pe.directory.entry";

        public Address32 Rva;

        public uint Size;

        public PeDirectoryKind Kind;

        public PeDirectoryEntry(Address32 rva, uint size, PeDirectoryKind kind)
        {
            Rva = rva;
            Size = size;
            Kind = kind;
        }

        public string Format()
            => $"{Kind}:[{Rva}..{Rva + Size}] = {(ByteSize)Size}b";

        public override string ToString()
            => Format();
    }
}