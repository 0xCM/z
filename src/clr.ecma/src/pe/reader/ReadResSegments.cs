//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    partial class PeReader
    {
        public ReadOnlySeq<EcmaString> ReadSystemStringDetail()
        {
            var reader = MD;
            int size = reader.GetHeapSize(HeapIndex.String);
            if (size == 0)
                return array<EcmaString>();

            var values = list<EcmaString>();
            var handle = MetadataTokens.StringHandle(0);
            var i=0;
            do
            {
                values.Add(new EcmaString(seq: i++, size, (Address32)reader.GetHeapOffset(handle), reader.GetString(handle)));
                handle = reader.GetNextHandle(handle);
            }
            while (!handle.IsNil);

            return values.ToArray();
        }

        [Op]
        public unsafe ReadOnlySeq<ResourceSeg> ReadResSegments()
        {
            var resources = CliReader().ReadResInfo();
            var count = resources.Length;
            var dst = sys.alloc<ResourceSeg>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var res = ref resources[i];
                var resdir = ReadSectionData(ResourcesDirectory);
                var blobReader = resdir.GetReader((int)res.Offset, resdir.Length - (int)res.Offset);
                var length = blobReader.ReadUInt32();
                MemoryAddress address = blobReader.CurrentPointer;
                seek(dst,i) = new ResourceSeg(res.Name, new MemorySeg(address,length));
            }
            return dst;
        }
    }
}