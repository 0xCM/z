//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CliTableSource<T>
        where T : struct
    {
        public readonly CliReader Reader;

        [MethodImpl(Inline)]
        internal CliTableSource(CliReader src)
        {
            Reader = src;
        }

        [MethodImpl(Inline)]
        internal CliTableSource(Assembly src)
        {
            Reader = CliReader.create(src);
        }

        [MethodImpl(Inline)]
        internal CliTableSource(MetadataReader src)
        {
            Reader = CliReader.create(src);
        }

        [MethodImpl(Inline)]
        internal CliTableSource(MemorySeg src)
        {
            Reader = CliReader.create(src);
        }

        [MethodImpl(Inline)]
        internal CliTableSource(PEMemoryBlock src)
        {
            Reader = CliReader.create(src);
        }
    }
}