//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class EcmaTableSource<T>
        where T : struct
    {
        public readonly EcmaReader Reader;

        [MethodImpl(Inline)]
        internal EcmaTableSource(EcmaReader src)
        {
            Reader = src;
        }

        [MethodImpl(Inline)]
        internal EcmaTableSource(Assembly src)
        {
            Reader = EcmaReader.create(src);
        }

        [MethodImpl(Inline)]
        internal EcmaTableSource(MetadataReader src)
        {
            Reader = EcmaReader.create(src);
        }

        [MethodImpl(Inline)]
        internal EcmaTableSource(MemorySeg src)
        {
            Reader = EcmaReader.create(src);
        }

        [MethodImpl(Inline)]
        internal EcmaTableSource(PEMemoryBlock src)
        {
            Reader = EcmaReader.create(src);
        }
    }
}