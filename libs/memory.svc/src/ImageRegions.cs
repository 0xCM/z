//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static sys;

    [Free]
    public class ImageRegions : WfSvc<ImageRegions>
    {
        public Index<ProcessMemoryRegion> LoadRegions(IApiPack src)
        {
            var paths = src.RegionPath();
            return LoadRegions(src.RegionPath());
        }

        public Outcome<Index<ProcessMemoryRegion>> LoadRegions(FS.FilePath src)
        {
            var tid = Tables.identify<ProcessMemoryRegion>();
            var flow = Running(string.Format("Reading {0} records from {1}", tid, src.ToUri()));
            if(!src.Exists)
                return (false, FS.Msg.DoesNotExist.Format(src));
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            if(count == 0)
            {
                return (false,"No data");
            }

            ref readonly var header = ref lines.First;
            var cells = header.Split(Chars.Pipe);
            if(cells.Length != ProcessMemoryRegion.FieldCount)
                return (false, Tables.FieldCountMismatch.Format(cells.Length, ProcessMemoryRegion.FieldCount));

            var data = slice(lines.View,1);
            var buffer = alloc<ProcessMemoryRegion>(data.Length);
            ref var dst = ref first(buffer);
            var counter = 0;
            for(var i=0; i<data.Length; i++)
            {
                ref readonly var line = ref skip(data,i);
                if(line.IsEmpty)
                    continue;

                var result = RegionProcessor.parse(line.Content, out seek(dst,i));
                if(!result)
                    return result;

                counter++;
            }
            Ran(flow, string.Format("Read {0} {1} records from {2}", counter, tid, src.ToUri()));
            return (true,buffer);
        }

        public ReadOnlySeq<ProcessMemoryRegion> EmitRegions(Process process, IApiPack dst)
        {
            var regions = RegionProcessor.regions(process);
            EmitRegions(regions, dst.RegionPath());
            return regions;
        }

        public Count EmitRegions(ReadOnlySeq<ProcessMemoryRegion> src, FS.FilePath dst)
        {
            var flow = EmittingTable<ProcessMemoryRegion>(dst);
            var count = Tables.emit(src.View,dst);
            EmittedTable(flow,count);
            return count;
        }

        public static ProcAddresses addresses(ReadOnlySpan<ProcessMemoryRegion> src)
        {
            var processor = new RegionProcessor();
            processor.Include(src);
            return processor.Complete();
        }

        [Op, MethodImpl(Inline)]
        public static Traverser traverser(ReadOnlySpan<ProcessMemoryRegion> src, bool live)
            => new Traverser(src, live);

        [Op, MethodImpl(Inline)]
        public static unsafe ByteSize run(Traverser traverser, delegate* unmanaged<in ProcessMemoryRegion,void> dst)
            => traverser.Traverse(dst);

        [Op]
        public static unsafe Index<ProcessMemoryRegion> filter(ReadOnlySpan<ProcessMemoryRegion> src, PageProtection protect)
        {
            var dst  = alloc<ProcessMemoryRegion>((uint)src.Length);
            var filter = new MemoryRegionFilter(dst, protect);
            var size = traverser(src,false).Traverse(filter);
            return filter.Emit();
        }

        public readonly ref struct Traverser
        {
            readonly ReadOnlySpan<ProcessMemoryRegion> Regions;

            readonly bool IsLive;

            [MethodImpl(Inline)]
            public Traverser(ReadOnlySpan<ProcessMemoryRegion> src, bool live)
            {
                Regions = src;
                IsLive = live;
            }

            [MethodImpl(Inline), Op]
            public ByteSize Traverse(IReceiver<ProcessMemoryRegion> dst)
            {
                var size = ByteSize.Zero;
                var src = Regions;
                var count = src.Length;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var region = ref skip(src,i);
                    dst.Deposit(region);
                    size += region.Size;
                }
                return size;
            }

            [MethodImpl(Inline), Op]
            public unsafe ByteSize Traverse(delegate* unmanaged<in ProcessMemoryRegion,void> dst)
            {
                var size = ByteSize.Zero;
                var src = Regions;
                var count = src.Length;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var region = ref skip(src,i);
                    dst(region);
                    size += region.Size;
                }
                return size;
            }
        }

        unsafe struct MemoryRegionFilter : IReceiver<ProcessMemoryRegion>
        {
            readonly Index<ProcessMemoryRegion> Accepted;

            readonly PageProtection Protection;

            uint Position;

            [MethodImpl(Inline)]
            public MemoryRegionFilter(Index<ProcessMemoryRegion> dst, PageProtection protection)
            {
                Accepted = dst;
                Protection = protection;
                Position = 0;
            }

            [MethodImpl(Inline)]
            public void Deposit(in ProcessMemoryRegion src)
            {
                if((src.Protection & Protection) != 0)
                {
                    Accepted[Position++] = src;
                }
            }

            public Index<ProcessMemoryRegion> Emit()
                => Accepted;
        }
    }
}