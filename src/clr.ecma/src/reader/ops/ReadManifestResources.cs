//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;
    
    partial class EcmaReader    
    {
        [MethodImpl(Inline), Op]
        public ManifestResource ReadResource(ManifestResourceHandle src)
            => MD.GetManifestResource(src);

        [Op]
        public ReadOnlySeq<ManifestResource> ManifestResources()
            => MD.ManifestResources.ToReadOnlySpan().Select(x => ReadResource(x));
    }
}