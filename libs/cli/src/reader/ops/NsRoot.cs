//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CliReader
    {
        [MethodImpl(Inline), Op]
        public NamespaceDefinition NsRoot()
            => MD.GetNamespaceDefinitionRoot();
    }
}
