//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CliDataSource
    {
        public CliReader Reader {get;}

        internal CliDataSource(Assembly src)
        {
            Reader = CliReader.create(src);
        }

        internal CliDataSource(MetadataReader src)
        {
            Reader = CliReader.create(src);
        }

        internal CliDataSource(MemorySeg src)
        {
            Reader = CliReader.create(src);
        }

        internal CliDataSource(PEMemoryBlock src)
        {
            Reader = CliReader.create(src);
        }

        public CliTableSource<T> TableSouce<T>()
            where T : struct, IRecord<T>
                => new CliTableSource<T>(Reader);
    }
}