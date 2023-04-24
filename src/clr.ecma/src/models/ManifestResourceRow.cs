//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {
        [EcmaRow(TableIndex.ManifestResource), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct ManifestResourceRow : IEcmaRow<ManifestResourceRow>
        {
            [Render(12)]
            public EcmaStringKey Name;

            [Render(12)]
            public MemoryAddress Offset;

            [Render(1)]
            public ManifestResourceAttributes Attributes;
        }
    }
}