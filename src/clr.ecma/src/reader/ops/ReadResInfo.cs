//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public ReadOnlySeq<ManifestResourceRow> ReadResInfo()
        {
            var handles = ResourceHandles();
            return ReadResInfo(handles, sys.alloc<ManifestResourceRow>(handles.Length));
        }

        [MethodImpl(Inline), Op]
        public static ManifestResourceHandle ResourceHandle(uint row)
            => MetadataTokens.ManifestResourceHandle((int)row);

        [MethodImpl(Inline), Op]
        public ReadOnlySeq<ManifestResourceRow> ReadResInfo(ReadOnlySpan<ManifestResourceHandle> src, Seq<ManifestResourceRow> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                ReadResInfo(ReadResource(skip(src,i)), ref dst[i]);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public ref ManifestResourceRow ReadResInfo(in ManifestResource src, ref ManifestResourceRow dst)
        {
            dst.Name = src.Name;
            dst.Offset = (ulong)src.Offset;
            dst.Attributes = src.Attributes;
            return ref dst;
        }
    }
}