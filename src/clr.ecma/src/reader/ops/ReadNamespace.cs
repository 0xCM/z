//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public NamespaceDefinition ReadNamespaceDef(NamespaceDefinitionHandle src)
            => MD.GetNamespaceDefinition(src);

        [MethodImpl(Inline), Op]
        public NamespaceDefinition ReadNamespaceRoot()
            => MD.GetNamespaceDefinitionRoot();
    }
}