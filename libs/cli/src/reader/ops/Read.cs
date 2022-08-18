//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    partial class CliReader
    {
        [MethodImpl(Inline), Op]
        public AssemblyFile Read(AssemblyFileHandle src)
            => MD.GetAssemblyFile(src);

        [MethodImpl(Inline), Op]
        public AssemblyReference Read(AssemblyReferenceHandle src)
            => MD.GetAssemblyReference(src);

        [MethodImpl(Inline), Op]
        public CustomAttribute Read(CustomAttributeHandle src)
            => MD.GetCustomAttribute(src);

        [MethodImpl(Inline), Op]
        public ExportedType Read(ExportedTypeHandle src)
            => MD.GetExportedType(src);

        [MethodImpl(Inline), Op]
        public FieldDefinition Read(FieldDefinitionHandle src)
            => MD.GetFieldDefinition(src);

        [MethodImpl(Inline), Op]
        public MethodDebugInformation Read(MethodDebugInformationHandle src)
            => MD.GetMethodDebugInformation(src);

        [MethodImpl(Inline), Op]
        public MethodImplementation Read(MethodImplementationHandle src)
            => MD.GetMethodImplementation(src);

        [MethodImpl(Inline), Op]
        public ManifestResource Read(ManifestResourceHandle src)
            => MD.GetManifestResource(src);

        [MethodImpl(Inline), Op]
        public MemberReference Read(MemberReferenceHandle src)
            => MD.GetMemberReference(src);

        [MethodImpl(Inline), Op]
        public NamespaceDefinition Read(NamespaceDefinitionHandle src)
            => MD.GetNamespaceDefinition(src);

        [MethodImpl(Inline), Op]
        public Parameter Read(ParameterHandle src)
            => MD.GetParameter(src);

        [MethodImpl(Inline), Op]
        public PropertyDefinition Read(PropertyDefinitionHandle src)
            => MD.GetPropertyDefinition(src);

        [MethodImpl(Inline), Op]
        public TypeReference Read(TypeReferenceHandle src)
            => MD.GetTypeReference(src);

        [MethodImpl(Inline), Op]
        public InterfaceImplementation Read(InterfaceImplementationHandle src)
            => MD.GetInterfaceImplementation(src);

        [MethodImpl(Inline), Op]
        public BinaryCode Read(BlobHandle src)
            => MD.GetBlobBytes(src);

        [MethodImpl(Inline), Op]
        public string Read(UserStringHandle handle)
            => MD.GetUserString(handle);

        [MethodImpl(Inline), Op]
        public string Read(StringHandle src)
            => MD.GetString(src);

        [MethodImpl(Inline), Op]
        public void Read(ReadOnlySpan<CustomAttributeHandle> src, Span<CustomAttribute> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = Read(skip(src,i));
        }

        [MethodImpl(Inline), Op]
        public void Read(ReadOnlySpan<FieldDefinitionHandle> src, Span<FieldDefinition> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = Read(skip(src,i));
        }

        [MethodImpl(Inline), Op]
        public void Read(ReadOnlySpan<MethodImplementationHandle> src, Span<MethodImplementation> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = Read(skip(src,i));
        }

        [MethodImpl(Inline), Op]
        public void Read(ReadOnlySpan<AssemblyFileHandle> src, Span<AssemblyFile> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = Read(skip(src,i));
        }
    }
}