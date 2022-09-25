//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        public ReadOnlySpan<EcmaStringDetail> ReadUserStringInfo()
        {
            var reader = MD;
            int size = MD.GetHeapSize(HeapIndex.UserString);
            if (size == 0)
                return default;

            var handle = MetadataTokens.UserStringHandle(0);
            var counter=0u;
            var dst = list<EcmaStringDetail>();

            do
            {
                dst.Add(new EcmaStringDetail(seq: counter++, size, HeapOffset(handle), Read(handle)));
                handle = MD.GetNextHandle(handle);
            }
            while (!handle.IsNil);

            return dst.ViewDeposited();
        }

    }
}