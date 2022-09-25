//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        [Op]
        public EcmaBlobRow ReadBlobInfo(BlobHandle handle, Count seq)
        {
            var offset = (Address32)MD.GetHeapOffset(handle);
            var value = MD.GetBlobBytes(handle) ?? core.array<byte>();
            var size = (uint)MD.GetHeapSize(HeapIndex.Blob);
            var row = new EcmaBlobRow();
            row.Seq = seq;
            row.HeapSize = (uint)MD.GetHeapSize(HeapIndex.Blob);
            row.Offset = (Address32)MD.GetHeapOffset(handle);
            row.Data = value;
            row.DataSize = (uint)row.Data.Length;
            return row;
        }
    }
}