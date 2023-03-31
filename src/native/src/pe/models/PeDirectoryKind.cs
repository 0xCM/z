//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum PeDirectoryKind : byte
    {
        None,

        ExportTable,

        ImportTable,

        ResourceTable,

        ExceptionTable,

        CertificateTable,

        BaseRelocationTable,

        DebugTable,

        GlobalPointerTable,

        ThreadLocalStorageTable,

        LoadConfigTable,

        BoundImportTable,

        ImportAddressTable,

        DelayImportTable,

        CorHeaderTable,


        CodeManagerTable,

        ExportAddressTableJumps,

        ManagedNativeHeader,

        MetadataTable,

        StrongNameSignature,

        VtableFixups,
    }
}