//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {       
        public ParallelQuery<TypeDefinition> GetTypeDefs()
            => from h in MD.TypeDefinitions.AsParallel() select MD.GetTypeDefinition(h);       
    }
}