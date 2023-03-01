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

        BaseRelocationTable,

        ImportAddressTable,

        LoadConfigTable,

        DebugTable,

        MetadataTable,

        StrongNameSignature,

        CodeManagerTable,

        VtableFixups,

        ExportAddressTableJumps,

        ManagedNativeHeader

    }
}