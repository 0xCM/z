//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        public ref EcmaAssemblyRef Row(AssemblyReferenceHandle handle, ref EcmaAssemblyRef dst)
        {
            var src = MD.GetAssemblyReference(handle);
            dst.Culture = src.Culture;
            dst.Flags = src.Flags;
            dst.Hash = src.HashValue;
            dst.Token = src.PublicKeyOrToken;
            dst.Version = src.Version;
            dst.Name = src.Name;
            return ref dst;
        }

        public ref EcmaTypeDef Row(TypeDefinitionHandle handle, ref EcmaTypeDef dst)
        {
            var src = MD.GetTypeDefinition(handle);
            dst.Name = src.Name;
            dst.Namespace = src.Namespace;
            dst.Attributes = src.Attributes;
            dst.Layout = src.GetLayout();
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public ref EcmaAttribute Row(CustomAttribute src, ref EcmaAttribute dst)
        {
            dst.Parent = src.Parent;
            dst.Constructor = src.Constructor;
            dst.Value = src.Value;
            dst.ValueOffset = HeapOffset(src.Value);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public ref EcmaFieldDef Row(FieldDefinitionHandle handle, ref EcmaFieldDef dst)
        {
            var src = MD.GetFieldDefinition(handle);
            dst.Attributes = src.Attributes;
            dst.Name = src.Name;
            dst.Sig = src.Signature;
            dst.Offset = (uint)src.GetOffset();
            dst.Marshal = src.GetMarshallingDescriptor();
            return ref dst;
        }
    }
}