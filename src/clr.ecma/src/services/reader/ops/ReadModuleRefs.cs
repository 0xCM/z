
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        [Op]
        public ReadOnlySpan<ModuleReferenceHandle> ModuleRefHandles()
        {
            var count = MD.GetTableRowCount(TableIndex.ModuleRef);
            var dst = alloc<ModuleReferenceHandle>(count);
            for(var i=1; i<=count; i++)
                seek(dst,i-1) = MetadataTokens.ModuleReferenceHandle(i);
            return dst;
        }
    }
}