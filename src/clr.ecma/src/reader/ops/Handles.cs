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

        [Op]
        public ReadOnlySpan<TypeReferenceHandle> TypeRefHandles()
            => MD.TypeReferences.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<CustomAttributeHandle> CustomAttribHandles()
            => MD.CustomAttributes.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<DeclarativeSecurityAttributeHandle> DeclSecurityHandles()
            => MD.DeclarativeSecurityAttributes.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<MemberReferenceHandle> MemberRefHandles()
            => MD.MemberReferences.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<AssemblyReferenceHandle> AssemblyRefHandles()
            => MD.AssemblyReferences.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<AssemblyFileHandle> AssemblyFileHandles()
            => MD.AssemblyFiles.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<ExportedTypeHandle> ExportedTypeHandles()
             => MD.ExportedTypes.ToReadOnlySpan();

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
        public ReadOnlySpan<PropertyDefinitionHandle> PropDefHandles()
            => MD.PropertyDefinitions.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<DocumentHandle> DocHandles()
            => MD.Documents.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<MethodDebugInformationHandle> MethodDebugInfoHandles()
            => MD.MethodDebugInformation.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<LocalScopeHandle> LocalScopeHandles()
            => MD.LocalScopes.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<LocalVariableHandle> LocalVarHandles()
            => MD.LocalVariables.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<LocalConstantHandle> LocalConstantHandles()
            => MD.LocalConstants.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<ImportScopeHandle> ImportScopeHandles()
            => MD.ImportScopes.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<CustomDebugInformationHandle> CustomDebugInfoHandles()
            => MD.CustomDebugInformation.ToReadOnlySpan();

        [Op]
        public ReadOnlySpan<ModuleReferenceHandle> ModuleRefHandles()
        {
            var count = MD.GetTableRowCount(TableIndex.ModuleRef);
            var dst = alloc<ModuleReferenceHandle>(count);
            for(var i=1; i<=count; i++)
                seek(dst,i-1) = MetadataTokens.ModuleReferenceHandle(i);
            return dst;
        }
    }
}
