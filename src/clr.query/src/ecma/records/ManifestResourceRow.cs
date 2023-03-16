//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Table(TableIndex.ManifestResource), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct ManifestResourceRow
        {
            [Render(32)]
            public string Name;

            [Render(12)]
            public MemoryAddress Offset;

            [Render(1)]
            public ManifestResourceAttributes Attributes;
        }
    }
}