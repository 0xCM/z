//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    
    partial class EcmaReader
    {
        public ImportScope ReadImportScope(ImportScopeHandle handle)
            => MD.GetImportScope(handle);

        public IEnumerable<ImportScope> ReadImportScopes()
            => MD.ImportScopes.Select(ReadImportScope);
    }
}