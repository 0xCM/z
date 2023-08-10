//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        public ParallelQuery<EcmaPinvoke> ReadPinvokes()
        {
            var handles = MethodDefHandles();
            var key = AssemblyKey();
            return from handle in handles                    
                    let method = MD.GetMethodDefinition(handle)
                    where IsPinvoke(method)
                    select new EcmaPinvoke {
                        Token = EcmaTokens.token(handle),
                        Assembly = key,
                        MethodName = String(method.Name),
                        MethodImport = ReadMethodImport(method)                        
                    };
        }
    }
}