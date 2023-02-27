//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public record class CorHeaderInfo
    {
        const string TableName = "corheader";

        public ushort MajorRuntimeVersion;

        public ushort MinorRuntimeVersion;

        public PeDirectoryEntry MetadataDirectory;

        public CorFlags Flags;

        public Address32 EntryPointTokenOrRelativeVirtualAddress;

        public PeDirectoryEntry ResourcesDirectory;

        public PeDirectoryEntry StrongNameSignatureDirectory;

        public PeDirectoryEntry CodeManagerTableDirectory;

        public PeDirectoryEntry VtableFixupsDirectory;

        public PeDirectoryEntry ExportAddressTableJumpsDirectory;

        public PeDirectoryEntry ManagedNativeHeaderDirectory;
    }
}