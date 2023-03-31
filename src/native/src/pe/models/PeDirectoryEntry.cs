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

        public PeDirectoryEntry(Address32 rva, uint size)
        {
            Rva = rva;
            Size = size;
        }

        public string Format()
            => $"{Rva}:{Size}";

        public override string ToString()
            => Format();
            
        [MethodImpl(Inline)]
        public static implicit operator PeDirectoryEntry(DirectoryEntry src)
            => new PeDirectoryEntry(src.RelativeVirtualAddress, (uint)src.Size);            
    }
}