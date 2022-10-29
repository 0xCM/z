//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public CustomAttribute Read(CustomAttributeHandle src)
            => MD.GetCustomAttribute(src);

        [MethodImpl(Inline), Op]
        public ExportedType Read(ExportedTypeHandle src)
            => MD.GetExportedType(src);

        [MethodImpl(Inline), Op]
        public MethodImplementation Read(MethodImplementationHandle src)
            => MD.GetMethodImplementation(src);

        [MethodImpl(Inline), Op]
        public MemberReference ReadMemberRef(MemberReferenceHandle src)
            => MD.GetMemberReference(src);

        [MethodImpl(Inline), Op]
        public NamespaceDefinition Read(NamespaceDefinitionHandle src)
            => MD.GetNamespaceDefinition(src);

        [MethodImpl(Inline), Op]
        public Parameter ReadParameter(ParameterHandle src)
            => MD.GetParameter(src);

        [MethodImpl(Inline), Op]
        public PropertyDefinition ReadPropDef(PropertyDefinitionHandle src)
            => MD.GetPropertyDefinition(src);

        [MethodImpl(Inline), Op]
        public TypeReference ReadTypeRef(TypeReferenceHandle src)
            => MD.GetTypeReference(src);

        [MethodImpl(Inline), Op]
        public InterfaceImplementation Read(InterfaceImplementationHandle src)
            => MD.GetInterfaceImplementation(src);

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
                seek(dst,i) = ReadFieldDef(skip(src,i));
        }

        [MethodImpl(Inline), Op]
        public void Read(ReadOnlySpan<MethodImplementationHandle> src, Span<MethodImplementation> dst)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = Read(skip(src,i));
        }
    }
}