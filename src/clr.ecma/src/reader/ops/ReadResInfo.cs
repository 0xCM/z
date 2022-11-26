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
        [Op]
        public ReadOnlySpan<ManifestResourceHandle> ResourceHandles()
            => MD.ManifestResources.ToReadOnlySpan();

        [MethodImpl(Inline), Op]
        public ReadOnlySeq<ManifestResourceInfo> ReadResInfo()
        {
            var handles = ResourceHandles();
            return ReadResInfo(handles, sys.alloc<ManifestResourceInfo>(handles.Length));
        }

        [MethodImpl(Inline), Op]
        public static ManifestResourceHandle ResourceHandle(uint row)
            => MetadataTokens.ManifestResourceHandle((int)row);

        [MethodImpl(Inline), Op]
        public ReadOnlySeq<ManifestResourceInfo> ReadResInfo(ReadOnlySpan<ManifestResourceHandle> src, Seq<ManifestResourceInfo> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                ReadResInfo(ReadResource(skip(src,i)), ref dst[i]);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public ref ManifestResourceInfo ReadResInfo(in ManifestResource src, ref ManifestResourceInfo dst)
        {
            dst.Name = String(src.Name);
            dst.Offset = (ulong)src.Offset;
            dst.Attributes = src.Attributes;
            return ref dst;
        }
    }
}