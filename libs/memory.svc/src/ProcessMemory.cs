//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class ProcessMemory : WfSvc<ProcessMemory>
    {
        ImageRegions Regions => Wf.ImageRegions();

        [Op]
        public static ReadOnlySeq<ProcessPartition> partitions(ReadOnlySeq<ImageLocation> src)
        {
            var count = src.Count;
            var buffer = Seq.alloc<ProcessPartition>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var image = ref src[i];
                ref var dst = ref buffer[i];
                dst.MinAddress = image.BaseAddress;
                dst.MaxAddress = image.MaxAddress;
                dst.Size = image.Size;
                dst.ImageName = image.ImageName;
            }

            return buffer.Sort();
        }
        public ReadOnlySpan<AddressBankEntry> LoadContextAddresses(IApiPack src)
        {
            var worker = new RegionProcessor();
            worker.Include(Regions.LoadRegions(src));
            var product = worker.Complete();
            var count = product.SelectorCount;
            var dst = list<AddressBankEntry>();
            var total = 0ul;
            for(ushort i=0; i<count; i++)
            {
                var bases = product.Bases(i);
                var selector = product.Selector(i);
                for(ushort j=0; j<bases.Length; j++)
                {
                    (var @base, var size) = skip(bases, j);
                    total += size;

                    var record = new AddressBankEntry();
                    record.Index = (i,j);
                    record.Selector = selector;
                    record.Base = @base;
                    record.Size = size;
                    record.Target = ((ulong)@base | (ulong)selector << 32);
                    record.TotalSize = total;
                    dst.Add(record);
                }
            }
            return dst.ViewDeposited();
        }

        public void Emit(ReadOnlySpan<AddressBankEntry> src, FS.FilePath dst)
            => TableEmit(src,dst);

        public ReadOnlySeq<ProcessPartition> EmitPartitions(Process process, IApiPack dst)
        {
            var summaries = partitions(ImageMemory.locations(process));
            TableEmit(summaries, dst.PartitionPath());
            return summaries;
        }

        public void EmitHashes(Process process, ReadOnlySpan<ProcessPartition> src, IApiPack dst)
            => EmitHashes(MemoryStores.stores(src).Addresses, dst.PartitionHashPath());

        public void EmitHashes(Process process, ReadOnlySpan<ProcessMemoryRegion> src, IApiPack dst)
            => EmitHashes(MemoryStores.load(src).Addresses, dst.RegionHashPath());

        ReadOnlySeq<AddressHash> EmitHashes(ReadOnlySpan<MemoryAddress> addresses, FS.FilePath dst)
        {
            var count = (uint)addresses.Length;
            var buffer = alloc<AddressHash>(count);
            MemoryStores.hash(addresses, buffer);
            TableEmit(buffer, dst);
            return buffer;
        }
    }
}
