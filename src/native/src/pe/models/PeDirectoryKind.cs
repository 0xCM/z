//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum PeDirectoryKind : byte
    {
        None,

        BaseRelocationTable,

        BoundImportTable,

        CertificateTable,

        CodeManagerTable,

        CorHeaderTable,

        DebugTable,

        DelayImportTable,

        ExceptionTable,

        ExportTable,

        ExportAddressTableJumps,

        GlobalPointerTable,

        ImportAddressTable,

        ImportTable,

        LoadConfigTable,

        ManagedNativeHeader,

        MetadataTable,

        StrongNameSignature,

        ResourceTable,

        ThreadLocalStorageTable,

        VtableFixups,
    }
}