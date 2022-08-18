//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliReader
    {
        [Op]
        public CliRowKeys Keys(ParameterHandleCollection src)
        {
            var count = src.Count;
            var buffer = core.alloc<CliRowKey>(count);
            var i=0;
            ref var dst = ref first(buffer);
            foreach(var handle in src)
                seek(dst,i++) = Cli.key(handle);
            return buffer;
        }

        [Op]
        public ReadOnlySpan<CliRowKey> IntefaceImplKeys(TypeDefinition src)
            => src.GetInterfaceImplementations().Map(x => Cli.key(MD.GetInterfaceImplementation(x).Interface)).ToReadOnlySpan();
    }
}