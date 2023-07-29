//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Ecma;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public ParallelQuery<ManifestResourceRow> ReadResInfo()
            => from handle in ResourceHandles()
                let res = ReadResource(handle)
                select new ManifestResourceRow {
                    Attributes = res.Attributes,
                    Name = res.Name,
                    Offset = (MemoryAddress)res.Offset
                };


        [MethodImpl(Inline), Op]
        public static ManifestResourceHandle ResourceHandle(uint row)
            => MetadataTokens.ManifestResourceHandle((int)row);
    }
}