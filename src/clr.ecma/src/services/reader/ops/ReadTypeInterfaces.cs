//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public IEnumerable<TypeInterfaces> ReadTypeInterfaces()
        {
            foreach(var handle in MD.TypeDefinitions)
            {
                var type = MD.GetTypeDefinition(handle);
                var impls = ReadInterfaceImpl(type).Array();
                if(impls.Length != 0)
                    yield return new TypeInterfaces(type,impls);                
            }
        }
    }
}