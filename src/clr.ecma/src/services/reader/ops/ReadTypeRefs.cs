//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Ecma;

    partial class EcmaReader
    {            
        public ParallelQuery<TypeRefRow> ReadTypeRefs()
            => from handle in TypeRefHandles()
                let typeref = MD.GetTypeReference(handle)
                select new TypeRefRow {
                     Index = handle,
                     ResolutionScope = typeref.ResolutionScope,
                     TypeName = typeref.Name,
                     TypeNamespace = typeref.Namespace
                };

    }
}