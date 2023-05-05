//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        [Op]
        public ReadOnlySpan<ManifestResourceHandle> ResourceHandles()
            => MD.ManifestResources.ToReadOnlySpan();
        
        [MethodImpl(Inline), Op]
        public static Handle handle(EcmaHandleData src)
            => @as<EcmaHandleData,Handle>(src);

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<TypeDefinitionHandle> TypeDefHandles()
            => MD.TypeDefinitions.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<TypeReferenceHandle> TypeRefHandles()
            => MD.TypeReferences.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<AssemblyReferenceHandle> AssemblyRefHandles()
            => MD.AssemblyReferences.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<MethodDefinitionHandle> MethodDefHandles()
            => MD.MethodDefinitions.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<FieldDefinitionHandle> FieldDefHandles()
            => MD.FieldDefinitions.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<EventDefinitionHandle> EventDefHandles()
            => MD.EventDefinitions.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<PropertyDefinitionHandle> PropertyDefHandles()
            => MD.PropertyDefinitions.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<MethodDebugInformationHandle> MethodDebugInfoHandles()
            => MD.MethodDebugInformation.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<CustomDebugInformationHandle> CustomDebugInfoHandles()
            => MD.CustomDebugInformation.ToReadOnlySpan();
    }
}
