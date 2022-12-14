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

        public PeDirectory MetadataDirectory;

        public CorFlags Flags;

        public Address32 EntryPointTokenOrRelativeVirtualAddress;

        public PeDirectory ResourcesDirectory;

        public PeDirectory StrongNameSignatureDirectory;

        public PeDirectory CodeManagerTableDirectory;

        public PeDirectory VtableFixupsDirectory;

        public PeDirectory ExportAddressTableJumpsDirectory;

        public PeDirectory ManagedNativeHeaderDirectory;
    }
}