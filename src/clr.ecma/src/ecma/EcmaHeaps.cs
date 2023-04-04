//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using System.Linq;

    public class EcmaHeaps
    {
        [Op]
        public static ExecToken emit(IWfChannel channel, MemorySeg src, FilePath dst, byte bpl = HexCsvRow.BPL)
        {
            var reader = MemoryReader.create<byte>(src.Range);
            var flow = channel.EmittingTable<HexCsvRow>(dst);
            var @base = src.BaseAddress;
            var offset = MemoryAddress.Zero;
            using var writer = dst.Writer();
            var counter = 0u;
            var lines = 0u;
            while(reader.Next(out var b))
            {
                writer.Append(b.ToString("x2"));
                
                counter++;
                var newline = counter % bpl == 0;
                if(reader.HasNext && !newline)
                    writer.Append(" ");

                if(newline)
                {
                    writer.AppendLine();
                    lines++;
                }
            }
            return channel.EmittedTable(flow, lines);
        }

        public static void emit(IWfChannel channel, IDbArchive src, IDbArchive dst)
        {
            var buffer = bag<EcmaHeapInfo>();
            var db = dst.Nested("ecma.heaps", src.Root);
            var index = Ecma.index(channel, src.Root);
            iter(index.Distinct(), entry => {
                using var file = Ecma.file(entry.Path);
                var reader = Ecma.reader(file);
                var heap = EcmaHeaps.strings(reader.MetadataReader, EcmaStringKind.System, reader.BaseAddress);
                var info = new EcmaHeapInfo();
                info.HeapKind = EcmaHeapKind.SystemString;
                info.BaseAddress = heap.BaseAddress;
                info.Size = heap.Size;
                info.Source = entry.Path;
                buffer.Add(info);
                var seg = new MemorySeg(heap.BaseAddress, heap.Size);
                var path = db.Path(entry.Path.FileName.Format() + "SystemStrings", FileKind.Hex);
                emit(channel, seg, path);        
                
            });
            channel.TableEmit(buffer.Array(), db.Path("ecma.heaps", FileKind.Csv));
        }
        
        [Op]
        public static EcmaHeap blobs(MetadataReader reader, MemoryAddress @base)
        {
            var offset = EcmaHeaps.offset(reader, MetadataTokens.BlobHandle(0));
            return new EcmaHeap(EcmaHeapKind.Blob, @base + offset, EcmaHeaps.size(reader, HeapIndex.Blob));
        }

        [Op]
        public static EcmaStringHeap strings(MetadataReader reader, EcmaStringKind kind, MemoryAddress @base)
            => kind switch
            {
                EcmaStringKind.User => ReadUserStringHeap(reader, @base),
                EcmaStringKind.System => ReadSystemStringHeap(reader, @base),
                _ => EcmaStringHeap.Empty
            };

        [MethodImpl(Inline), Op]
        public static Address32 offset(MetadataReader reader, UserStringHandle handle)
            => (Address32)reader.GetHeapOffset(handle);

        [MethodImpl(Inline), Op]
        public static Address32 offset(MetadataReader reader, BlobHandle handle)
            => (Address32)reader.GetHeapOffset(handle);

        [MethodImpl(Inline), Op]
        public static Address32 offset(MetadataReader reader, StringHandle handle)
            => (Address32)reader.GetHeapOffset(handle);

        [MethodImpl(Inline), Op]
        public static Address32 offset(MetadataReader reader, GuidHandle handle)
            => (Address32)reader.GetHeapOffset(handle);

        [MethodImpl(Inline), Op]
        public static ByteSize size(MetadataReader reader, HeapIndex index)
            => reader.GetHeapSize(index);

        public static string heapinfo<T>(T src)
            where T : IEcmaHeap
                => string.Format("{0,-20} | {1} | {2}", src.HeapKind, src.BaseAddress, src.Size);

        public static Index<EcmaHeap> blobs(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<EcmaHeap>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = EcmaReader.create(component);
                seek(dst,i) = blobs(reader.MetadataReader, reader.BaseAddress);
            }
            return buffer;
        }

        public static Index<EcmaHeap> guids(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<EcmaHeap>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = EcmaReader.create(component);
                seek(dst,i) = reader.ReadGuidHeap();
            }
            return buffer;
        }

        [Op]
        static EcmaStringHeap ReadUserStringHeap(MetadataReader reader, MemoryAddress @base)
        {
            var offset = EcmaHeaps.offset(reader, MetadataTokens.UserStringHandle(0));
            return new EcmaStringHeap(EcmaHeapKind.UserString, @base + offset, EcmaHeaps.size(reader, HeapIndex.UserString));
        }

        [Op]
        static EcmaStringHeap ReadSystemStringHeap(MetadataReader reader, MemoryAddress @base)
        {
            var offset = EcmaHeaps.offset(reader, MetadataTokens.StringHandle(0));
            return new EcmaStringHeap(EcmaHeapKind.SystemString, @base + offset, EcmaHeaps.size(reader, HeapIndex.String));
        }

        public static IEnumerable<EcmaStringHeap> strings(IEnumerable<AssemblyFile> src)
        {
            foreach(var file in src.AsParallel())
            {
                using var ecma = Ecma.file(file.Path);
                var reader = ecma.EcmaReader();
                yield return strings(reader.MetadataReader, EcmaStringKind.System, reader.BaseAddress);
                yield return strings(reader.MetadataReader, EcmaStringKind.User, reader.BaseAddress);
            }
        }

        public static Index<EcmaStringHeap> strings(ReadOnlySpan<Assembly> src)
        {
            var count = src.Length;
            var buffer = alloc<EcmaStringHeap>(count*2);
            ref var dst = ref first(buffer);
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                var reader = EcmaReader.create(component);
                seek(dst,j++) = strings(reader.MetadataReader, EcmaStringKind.System, reader.BaseAddress);
                seek(dst,j++) = strings(reader.MetadataReader, EcmaStringKind.User, reader.BaseAddress);
            }
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static unsafe uint count(in EcmaStringHeap src)
        {
            var counter = 0u;
            var pCurrent = src.BaseAddress.Pointer<char>();
            var pLast = (src.BaseAddress + src.Size).Pointer<char>();
            while(pCurrent < pLast)
            {
                if(*pCurrent++ == Chars.Null)
                    counter++;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static unsafe uint terminators(in EcmaStringHeap src, Span<uint> dst)
        {
            var counter = 0u;
            var pCurrent = src.BaseAddress.Pointer<char>();
            var pLast = (src.BaseAddress + src.Size).Pointer<char>();
            var pos = 0u;
            while(pCurrent < pLast)
            {
                if(*pCurrent++ == Chars.Null)
                    seek(dst, counter++) = pos*2;
                pos++;
            }
            return counter;
        }

        public static Index<uint> terminators(in EcmaStringHeap src)
        {
            var dst = alloc<uint>(count(src));
            terminators(src,dst);
            return dst;
        }
    }
}