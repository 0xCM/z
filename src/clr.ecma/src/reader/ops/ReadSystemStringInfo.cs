//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public ReadOnlySeq<EcmaStringDetail> ReadSystemStringDetail()
        {
            var reader = MD;
            int size = reader.GetHeapSize(HeapIndex.String);
            if (size == 0)
                return sys.array<EcmaStringDetail>();

            var values = sys.list<EcmaStringDetail>();
            var handle = MetadataTokens.StringHandle(0);
            var i=0;
            do
            {
                values.Add(new EcmaStringDetail(seq: i++, size, (Address32)reader.GetHeapOffset(handle), reader.GetString(handle)));
                handle = reader.GetNextHandle(handle);
            }
            while (!handle.IsNil);

            return values.ToArray();
        }
    }
}