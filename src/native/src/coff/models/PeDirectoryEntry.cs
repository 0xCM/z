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

        [MethodImpl(Inline)]
        public PeDirectoryEntry(DirectoryEntry src)
        {
            Rva = src.RelativeVirtualAddress;
            Size = (uint)src.Size;
        }

        public static implicit operator PeDirectoryEntry(DirectoryEntry src)
            => new PeDirectoryEntry(src);
    }
}