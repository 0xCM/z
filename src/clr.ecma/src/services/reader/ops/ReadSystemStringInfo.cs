//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public IEnumerable<EcmaStringDetail> ReadSystemStringDetail()
        {
            var reader = MD;
            var size = reader.GetHeapSize(HeapIndex.String);
            var handle = MetadataTokens.StringHandle(0);
            var i=0;
            do{
                yield return new EcmaStringDetail(seq: i++, size, (Address32)reader.GetHeapOffset(handle), reader.GetString(handle));
                handle = reader.GetNextHandle(handle);
            }
            while(!handle.IsNil);

        }
    }
}