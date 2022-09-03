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
        public ReadOnlySpan<TypeDefinition> ReadInterfaceImpl(TypeDefinition src)
        {
            var handles = src.GetInterfaceImplementations().ToSpan();
            var count = handles.Length;
            var dst = span<TypeDefinition>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var handle = ref skip(handles,i);
                var iface = (TypeDefinitionHandle)Read(handle).Interface;
                seek(dst,i) = Read(iface);

            }
            return dst;
        }
    }
}