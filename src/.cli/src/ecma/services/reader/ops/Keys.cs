//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        [Op]
        public CliRowKeys Keys(ParameterHandleCollection src)
        {
            var count = src.Count;
            var buffer = core.alloc<CliRowKey>(count);
            var i=0;
            ref var dst = ref first(buffer);
            foreach(var handle in src)
                seek(dst,i++) = Ecma.key(handle);
            return buffer;
        }

        [Op]
        public ReadOnlySpan<CliRowKey> IntefaceImplKeys(TypeDefinition src)
            => src.GetInterfaceImplementations().Map(x => Ecma.key(MD.GetInterfaceImplementation(x).Interface)).ToReadOnlySpan();
    }
}