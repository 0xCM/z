//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public ParallelQuery<TypeDefinitionHandle> TypeDefHandles()
            => MD.TypeDefinitions.AsParallel();

        [Op]
        public ParallelQuery<TypeReferenceHandle> TypeRefHandles()
            => MD.TypeReferences.AsParallel();

        [Op]
        public ParallelQuery<AssemblyReferenceHandle> AssemblyRefHandles()
            => MD.AssemblyReferences.AsParallel();

        [Op]
        public ParallelQuery<MethodDefinitionHandle> MethodDefHandles()
            => MD.MethodDefinitions.AsParallel();

        [Op]
        public ParallelQuery<PropertyDefinitionHandle> PropertyDefHandles()
            => MD.PropertyDefinitions.AsParallel();

        [Op]
        public ParallelQuery<MethodDebugInformationHandle> MethodDebugInfoHandles()
            => MD.MethodDebugInformation.AsParallel();
    }
}
