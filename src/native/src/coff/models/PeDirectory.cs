//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public record struct PeDirectory
    {
        public const string TableId = "pe.dirinfo";

        public Address32 Rva;

        public uint Size;

        [MethodImpl(Inline)]
        public PeDirectory(DirectoryEntry src)
        {
            Rva = src.RelativeVirtualAddress;
            Size = (uint)src.Size;
        }

        public static implicit operator PeDirectory(DirectoryEntry src)
            => new PeDirectory(src);
    }
}