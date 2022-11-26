//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static EcmaTables;

    partial class EcmaReader
    {
        [Op]
        public EcmaRowKeys ReadParameterRowKeys(ParameterHandleCollection src)
        {
            var count = src.Count;
            var buffer = alloc<EcmaRowKey>(count);
            var i=0;
            ref var dst = ref first(buffer);
            foreach(var handle in src)
                seek(dst,i++) = EcmaHandles.key(handle);
            return buffer;
        }
    }
}