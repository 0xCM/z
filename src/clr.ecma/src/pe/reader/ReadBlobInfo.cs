//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PeReader
    {
        public ReadOnlySpan<CliBlob> ReadBlobs()
        {
            var size = (uint)MD.GetHeapSize(HeapIndex.Blob);
            if (size == 0)
                return Span<CliBlob>.Empty;

            var handle = MetadataTokens.BlobHandle(1);
            var i=0;
            var values = new List<CliBlob>();
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

            return values.ToArray();
        }
    }
}