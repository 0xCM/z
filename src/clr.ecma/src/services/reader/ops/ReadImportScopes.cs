//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    
    partial class EcmaReader
    {
        public ParallelQuery<ImportScope> ReadImportScopes()
            => from scope in MD.ImportScopes.AsParallel() 
                select MD.GetImportScope(scope);
    }
}