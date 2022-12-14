//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class RegionProcessor
    {
        List<Address16> Selectors;

        List<List<Paired<Address32,uint>>> Bases;

        Index<ProcessSegment> Segments;

        ProcAddresses Addresses;

        string HostProcessName;

        public RegionProcessor()
        {
            Selectors = new();
            Bases = new();
            Segments = new();
            HostProcessName = core.process().ProcessName;
        }

        public ref readonly ProcAddresses Complete()
        {
            Addresses = new (Segments, Selectors.ToArray(), Bases.ToArray());
            return ref Addresses;
        }

        public uint Include(ReadOnlySpan<ProcessMemoryRegion> src)
        {
            var count = (uint)src.Length;
            Segments = alloc<ProcessSegment>(count);
            for(var i=0u; i<count; i++)
                Include(i, skip(src,i));
            return count;
        }

        void Include(uint index, in ProcessMemoryRegion src)
        {
            var id = src.ImageName;

            if(text.empty(id))
                id = src.ImagePath.Format();

            if(id.StartsWith(HostProcessName))
                id = string.Format("host::{0}", id);

            if(src.Type != 0 && src.Protection != 0)
            {
                var sidx = (ushort)Index(src.BaseAddress.Quadrant(n2));
                Bases[sidx].Add(core.paired(src.BaseAddress.Lo(), (uint)src.Size));
                ImageMemory.segment(src, ref Segments[index]);
            }
        }

        ushort Index(Address16 selector)
        {
            var index = Selectors.IndexOf(selector);
            if(index == NotFound)
            {
                Selectors.Add(selector);
                index = Selectors.Count - 1;
                Bases.Add(list<Paired<Address32,uint>>());
            }
            return (ushort)index;
        }
    }
}