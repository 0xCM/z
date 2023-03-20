
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
        public ReadOnlySeq<ModuleRefRow> ReadModuleRefs()
        {
            var handles = ModuleRefHandles();
            var count = handles.Length;
            var dst = alloc<ModuleRefRow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var handle = ref skip(handles,i);
                seek(dst,i) = new ModuleRefRow(handle, MD.GetModuleReference(handle).Name);

            }
            return dst;
        }
    }
}