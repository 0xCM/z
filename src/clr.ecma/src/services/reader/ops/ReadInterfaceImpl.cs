//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public InterfaceImplementation ReadInterfaceImpl(InterfaceImplementationHandle src)
            => MD.GetInterfaceImplementation(src);

        [Op]
        public IEnumerable<TypeDefinition> ReadInterfaceImpl(TypeDefinition src)
        {
            foreach(var handle in src.GetInterfaceImplementations())
            {
                var iface = (TypeDefinitionHandle)ReadInterfaceImpl(handle).Interface;
                yield return MD.GetTypeDefinition(iface);
            }
        }
    }
}