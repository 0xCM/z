//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiCatalogEntry
    {
        const string TableId = "api.catalog";

        public const byte FieldCount = 8;

        public uint Sequence;

        public MemoryAddress ProcessBase;

        public MemoryAddress MemberBase;

        public Disp32 MemberOffset;

        public Address32 MemberRebase;

        public string PartName;

        public string HostName;

        public _OpUri OpUri;
    }
}