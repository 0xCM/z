//-----------------------------------------------------------------------------
// Copyright   :  Microsoft
// License     :  Apache 2.0
// Origin      : https://github.com/dotnet/symreader-converter/src/Microsoft.DiaSymReader.Converter/Utilities/SymMetadataProvider.cs
//-----------------------------------------------------------------------------
namespace Z0
{
    public unsafe sealed class SymbolMetadata : ISymMetadataProvider
    {
        readonly PEReader PeReader;

        readonly MetadataReader MdReader;

        public SymbolMetadata(PdbSymbolSource source)
        {
            if(!source.Streams)
                PeReader = new PEReader(source.PeSrc.Pointer(), source.PeSrc.Size, source.RuntimeLoaded);
            else
                PeReader = new PEReader(source.PeStream);
            MdReader = PeReader.GetMetadataReader();
        }

        public void Dispose()
        {
            PeReader.Dispose();
        }

        public unsafe bool TryGetStandaloneSignature(int standaloneSignatureToken, out byte* signature, out int length)
        {
            var sigHandle = (StandaloneSignatureHandle)MetadataTokens.Handle(standaloneSignatureToken);
            if (sigHandle.IsNil)
            {
                signature = null;
                length = 0;
                return false;
            }

            var sig = MdReader.GetStandaloneSignature(sigHandle);
            var blobReader = MdReader.GetBlobReader(sig.Signature);

            signature = blobReader.StartPointer;
            length = blobReader.Length;
            return true;
        }

        public bool TryGetTypeDefinitionInfo(int typeDefinitionToken, out string namespaceName, out string typeName, out TypeAttributes attributes)
        {
            var handle = (TypeDefinitionHandle)MetadataTokens.Handle(typeDefinitionToken);
            if (handle.IsNil)
            {
                namespaceName = null;
                typeName = null;
                attributes = 0;
                return false;
            }

            var typeDefinition = MdReader.GetTypeDefinition(handle);
            namespaceName = MdReader.GetString(typeDefinition.Namespace);
            typeName = MdReader.GetString(typeDefinition.Name);
            attributes = typeDefinition.Attributes;
            return true;
        }

        public bool TryGetTypeReferenceInfo(int typeReferenceToken, out string namespaceName, out string typeName)
        {
            var handle = (TypeReferenceHandle)MetadataTokens.Handle(typeReferenceToken);
            if (handle.IsNil)
            {
                namespaceName = null;
                typeName = null;
                return false;
            }

            var typeReference = MdReader.GetTypeReference(handle);
            namespaceName = MdReader.GetString(typeReference.Namespace);
            typeName = MdReader.GetString(typeReference.Name);
            return true;
        }

        public unsafe int GetSigFromToken(int tkSignature, out byte* ppvSig, out int pcbSig)
        {
            var signatureHandle = (StandaloneSignatureHandle)MetadataTokens.Handle(tkSignature);
            var bytes = MdReader.GetBlobBytes(MdReader.GetStandaloneSignature(signatureHandle).Signature);
            var pinned = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            ppvSig = (byte*)pinned.AddrOfPinnedObject();
            pcbSig = bytes.Length;
            return 0;
        }

        public bool TryGetEnclosingType(int nestedTypeToken, out int enclosingTypeToken)
        {
            var nestedTypeDef = MdReader.GetTypeDefinition(MetadataTokens.TypeDefinitionHandle(nestedTypeToken));
            var declaringTypeHandle = nestedTypeDef.GetDeclaringType();

            if (declaringTypeHandle.IsNil)
            {
                enclosingTypeToken = 0;
                return false;
            }
            else
            {
                enclosingTypeToken = MetadataTokens.GetToken(declaringTypeHandle);
                return true;
            }
        }

        public bool TryGetMethodInfo(int methodDefinitionToken, out string? methodName, out int declaringTypeToken)
        {
            var handle = (MethodDefinitionHandle)MetadataTokens.Handle(methodDefinitionToken);
            if (handle.IsNil)
            {
                methodName = null;
                declaringTypeToken = 0;
                return false;
            }

            var methodDefinition = MdReader.GetMethodDefinition(handle);
            methodName = MdReader.GetString(methodDefinition.Name);
            declaringTypeToken = MetadataTokens.GetToken(methodDefinition.GetDeclaringType());
            return true;
        }
    }
}