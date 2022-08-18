//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ImageMemory
    {
        public static ProcessImageMap map()
            => map(Process.GetCurrentProcess());

        public static ProcessImageMap map(Process process)
        {
            var src = locations(process);
            var count = src.Count;
            var addresses = alloc<MemoryAddress>(count);
            for(var i=0u; i<count; i++)
                seek(addresses, i) = src[i].BaseAddress;
            var state = new ProcessMemoryState();
            fill(process, ref state);
            return new ProcessImageMap(state, src, addresses.Sort(), modules(process));
        }
    }
}