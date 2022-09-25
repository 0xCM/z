//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class EcmaDataSource
    {
        public EcmaReader Reader {get;}

        internal EcmaDataSource(Assembly src)
        {
            Reader = EcmaReader.create(src);
        }

        internal EcmaDataSource(MetadataReader src)
        {
            Reader = EcmaReader.create(src);
        }

        internal EcmaDataSource(MemorySeg src)
        {
            Reader = EcmaReader.create(src);
        }

        internal EcmaDataSource(PEMemoryBlock src)
        {
            Reader = EcmaReader.create(src);
        }

        public EcmaTableSource<T> TableSouce<T>()
            where T : struct, IRecord<T>
                => new EcmaTableSource<T>(Reader);
    }
}