//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class ProcessMemory : Channeled<ProcessMemory>
{
    static MsgPattern<Address16> SegSelectorNotFound => "Selector {0} not found";

    static MsgPattern<Count> LocatingSegments => "Locating segments for {0} methods";

    static MsgPattern<Count,Count> LocatedSegments => "Computed {0} segment entries for {0} methods";

    public static ProcAddresses addresses(ReadOnlySpan<ProcessMemoryRegion> src)
    {
        var processor = new RegionProcessor();
        processor.Include(src);
        return processor.Complete();
    }

    public ReadOnlySeq<ProcessMemoryRegion> EmitRegions(Process process, IApiPack dst)
    {
        var regions = ImageMemory.regions(process);
        EmitRegions(regions, dst.Scoped("context").Path("memory.regions", FileKind.Csv));
        return regions;
    }

    public Count EmitRegions(ReadOnlySeq<ProcessMemoryRegion> src, FilePath dst)
    {
        var flow = Channel.EmittingTable<ProcessMemoryRegion>(dst);
        var count = CsvTables.emit(src.View,dst);
        Channel.EmittedTable(flow,count);
        return count;
    }

    public static Outcome parse(string src, out ProcessMemoryRegion dst)
    {
        dst = default;
        if(text.empty(src))
            return false;

        var count = ProcessMemoryRegion.FieldCount;
        var parts = text.split(src,Chars.Pipe);
        if(parts.Length != ProcessMemoryRegion.FieldCount)
            return (false, Tables.FieldCountMismatch.Format(parts.Length, count));

        var buffer = sys.alloc<Outcome>(count);
        ref var outcomes = ref first(buffer);

        var i=0;
        var j=0;
        seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.Seq);
        seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.ImageName);
        seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.BaseAddress);
        seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.MaxAddress);
        seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.Size);
        seek(outcomes,i++) = DataParser.eparse(skip(parts,j++), out dst.Type);
        seek(outcomes,i++) = DataParser.eparse(skip(parts,j++), out dst.Protection);
        seek(outcomes,i++) = DataParser.eparse(skip(parts,j++), out dst.State);
        seek(outcomes,i++) = DataParser.parse(skip(parts,j++), out dst.ImagePath);
        return true;
    }

    public ReadOnlySpan<ProcessSegment> EmitMethodSegments(ProcAddresses src, ReadOnlySpan<ApiMemberInfo> methods, IDbArchive dst)
    {
        var count = methods.Length;
        var flow = Channel.Running(LocatingSegments.Format(count));
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
                Channel.Error(SegSelectorNotFound.Format(selector));
                break;
            }

            ref var entry = ref seek(buffer,i);
            entry.MethodIndex = i;
            entry.EntryPoint = address;
            entry.SegSelector = selector;
            entry.Uri = text.utf8(method.Uri.Format());
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
                Channel.Error(string.Format("Could not locate the segment containing the entry point {0} for {1}", method.EntryPoint, method.Uri));
                break;
            }
        }

        Channel.TableEmit(@readonly(buffer), dst.Scoped("context").Table<MethodSegment>());
        Channel.Ran(flow, LocatedSegments.Format(buffer.Length, count));
        return locations.Array().Sort();
    }


    public ReadOnlySpan<AddressBankEntry> LoadContextAddresses(IApiPack src)
    {
        var worker = new RegionProcessor();
        worker.Include(LoadRegions(src));
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

    public void Emit(ReadOnlySpan<AddressBankEntry> src, FilePath dst)
        => Channel.TableEmit(src,dst);

    public ReadOnlySeq<ProcessPartition> EmitPartitions(Process process, IApiPack dst)
    {
        var summaries = ImageMemory.partitions(ImageMemory.loaded(process));
        Channel.TableEmit(summaries, dst.PartitionPath());
        return summaries;
    }

    public void EmitHashes(Process process, ReadOnlySpan<ProcessPartition> src, IApiPack dst)
        => EmitHashes(MemoryStores.stores(src).Addresses, dst.PartitionHashPath());

    public void EmitHashes(Process process, ReadOnlySpan<ProcessMemoryRegion> src, IApiPack dst)
        => EmitHashes(MemoryStores.load(src).Addresses, dst.RegionHashPath());

    public void EmitSegments(IApiPack dst)
        => EmitSegments(ImageMemory.regions(), dst);

    public void EmitSegments(ReadOnlySeq<ProcessMemoryRegion> src, IDbArchive dst)
        => Channel.TableEmit(addresses(src).Segments, dst.Scoped("context").Table<ProcessSegment>());

    ReadOnlySeq<AddressHash> EmitHashes(ReadOnlySpan<MemoryAddress> addresses, FilePath dst)
    {
        var count = (uint)addresses.Length;
        var buffer = alloc<AddressHash>(count);
        MemoryStores.hash(addresses, buffer);
        Channel.TableEmit(buffer, dst);
        return buffer;
    }

    public Index<ProcessMemoryRegion> LoadRegions(IApiPack src)
    {
        var paths = src.RegionPath();
        return LoadRegions(src.RegionPath());
    }

    public Outcome<Index<ProcessMemoryRegion>> LoadRegions(FilePath src)
    {
        var tid = Tables.identify<ProcessMemoryRegion>();
        var flow = Channel.Running(string.Format("Reading {0} records from {1}", tid, src.ToUri()));
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

            var result = parse(line.Content, out seek(dst,i));
            if(!result)
                return result;

            counter++;
        }
        Channel.Ran(flow, string.Format("Read {0} {1} records from {2}", counter, tid, src.ToUri()));
        return (true,buffer);
    }
}
