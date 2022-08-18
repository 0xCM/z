//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct PeDirInfo
    {
        public const string TableId = "pe.dirinfo";

        public Address32 Rva;

        public uint Size;

        [MethodImpl(Inline)]
        internal PeDirInfo(DirectoryEntry src)
        {
            Rva = src.RelativeVirtualAddress;
            Size = (uint)src.Size;
        }

        public static implicit operator PeDirInfo(DirectoryEntry src)
            => new PeDirInfo(src);
    }
}