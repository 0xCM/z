
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
        public ReadOnlySeq<ModuleRef> ReadModuleRefs()
        {
            var handles = ModuleRefHandles();
            var count = handles.Length;
            var dst = alloc<ModuleRef>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var handle = ref skip(handles,i);
                seek(dst,i) = new ModuleRef(handle, String(MD.GetModuleReference(handle).Name));

            }
            return dst;
        }
    }
}