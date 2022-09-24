//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public ReadOnlySpan<CliBlob> ReadBlobs()
        {
            var size = (uint)MD.GetHeapSize(HeapIndex.Blob);
            if (size == 0)
                return Span<CliBlob>.Empty;

            var handle = MetadataTokens.BlobHandle(1);
            var i=0;
            var values = core.list<CliBlob>();
            do
            {
                var value = MD.GetBlobBytes(handle);
                var row = new CliBlob();
                row.Seq = i++;
                row.HeapSize = size;
                row.Offset = (Address32)MD.GetHeapOffset(handle);
                row.Data = MD.GetBlobBytes(handle);
                row.DataSize = (uint)row.Data.Length;
                values.Add(row);
                handle = MD.GetNextHandle(handle);
            }
            while (!handle.IsNil);

            return values.ViewDeposited();
        }

        [Op]
        public CliBlob ReadBlobInfo(BlobHandle handle, Count seq)
        {
            var offset = (Address32)MD.GetHeapOffset(handle);
            var value = MD.GetBlobBytes(handle) ?? core.array<byte>();
            var size = (uint)MD.GetHeapSize(HeapIndex.Blob);
            var row = new CliBlob();
            row.Seq = seq;
            row.HeapSize = (uint)MD.GetHeapSize(HeapIndex.Blob);
            row.Offset = (Address32)MD.GetHeapOffset(handle);
            row.Data = value;
            row.DataSize = (uint)row.Data.Length;
            return row;
        }
    }
}