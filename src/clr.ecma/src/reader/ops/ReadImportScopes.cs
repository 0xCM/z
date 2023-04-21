//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    partial class EcmaReader
    {
        public ImportScope ReadImportScope(ImportScopeHandle handle)
            => MD.GetImportScope(handle);

        public ReadOnlySeq<ImportScope> ReadImportScopes()
        {
            var handles = ImportScopeHandles();
            var dst = alloc<ImportScope>(handles.Length);
            for(var i=0; i<handles.Length; i++)
                seek(dst,i) = ReadImportScope(skip(handles,i));
            return dst;
        }
    }
}