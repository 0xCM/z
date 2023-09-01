//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Ecma;

    partial class EcmaReader
    {
        public IEnumerable<EcmaBlobInfo> ReadBlobRows()
        {
            var size = (uint)MD.GetHeapSize(SRM355.HeapIndex.Blob);
            var handle = MetadataTokens.BlobHandle(1);        
            var i=0;
            do
            {
                var row = new EcmaBlobInfo();
                row.HeapSize = size;
                row.Offset = (Address32)MD.GetHeapOffset(handle);
                row.Data = MD.GetBlobBytes(handle);
                row.DataSize = (uint)row.Data.Length;
                yield return row;
                handle = MD.GetNextHandle(handle);
            }
            while (!handle.IsNil);
        
        }
    }
}