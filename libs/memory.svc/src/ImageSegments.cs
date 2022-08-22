//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ImageSegments : WfSvc<ImageSegments>
    {
        static MsgPattern<Address16> SegSelectorNotFound => "Selector {0} not found";

        static MsgPattern<Count> LocatingSegments => "Locating segments for {0} methods";

        static MsgPattern<Count,Count> LocatedSegments => "Computed {0} segment entries for {0} methods";

        public void EmitSegments(IApiPack dst)
            => EmitSegments(dst, RegionProcessor.regions());

        public void EmitSegments(IApiPack dst, ReadOnlySeq<ProcessMemoryRegion> src)
            => TableEmit(ImageRegions.addresses(src).Segments, dst.Context().Table<ProcessSegment>());

        public ReadOnlySpan<ProcessSegment> EmitMethodSegments(ProcAddresses src, ReadOnlySpan<ApiMemberInfo> methods, IApiPack dst)
        {
            var count = methods.Length;
            var flow = Running(LocatingSegments.Format(count));
            var buffer = alloc<MethodSegment>(count);
            var locations = hashset<ProcessSegment>();
            var segments  = src.Segments;
            for(var i=0u; i<count; i++)
            {
                ref readonly var method = ref skip(methods,i);
                ref readonly var address = ref method.EntryPoint;
                var selector = address.Quadrant(n2);
                var index = src.SelectorIndex(selector);
                if(index == NotFound)
                {
                    Error(SegSelectorNotFound.Format(selector));
                    break;
                }

                ref var entry = ref seek(buffer,i);
                entry.MethodIndex = i;
                entry.EntryPoint = address;
                entry.SegSelector = selector;
                entry.Uri = method.Uri;
                var bases = src.Bases((ushort)index);
                var match = address.Lo();
                var matched = false;
                for(var j=0u; j<bases.Length; j++)
                {
                    ref readonly var @base = ref skip(bases,j);
                    var min = @base.Left;
                    var max = min + @base.Right;
                    if(match.Between(@base.Left, @base.Left + @base.Right))
                    {
                        ref readonly var found = ref skip(segments,j);
                        entry.SegIndex = j;
                        entry.SegStart =  ((ulong)selector << 32) | (MemoryAddress)found.Base;
                        entry.SegSize = found.Size;
                        entry.SegEnd = ((ulong)selector << 32) | ((MemoryAddress)found.Base + found.Size);
                        locations.Add(found);
                        matched = true;
                        break;
                    }
                }
                if(!matched)
                {
                    Error(string.Format("Could not locate the segment containing the entry point {0} for {1}", method.EntryPoint, method.Uri));
                    break;
                }
            }

            TableEmit(@readonly(buffer), dst.Context().Table<MethodSegment>());
            Ran(flow, LocatedSegments.Format(buffer.Length, count));
            return locations.Array().Sort();
        }
    }
}