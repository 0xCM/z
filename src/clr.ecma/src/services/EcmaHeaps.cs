//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

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
    }
}