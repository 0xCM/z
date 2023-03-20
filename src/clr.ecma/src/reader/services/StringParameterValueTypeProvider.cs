// Reference: https://gist.github.com/jbe2277/f91ef12df682f3bfb6293aabcb47be2a
namespace Z0;

partial class EcmaReader
{
    public sealed class StringParameterValueTypeProvider : ISignatureTypeProvider<string, object>
    {
        private readonly BlobReader valueReader;

        public StringParameterValueTypeProvider(MetadataReader reader, BlobHandle value)
        {
            Reader = reader;
            valueReader = reader.GetBlobReader(value);

            var prolog = valueReader.ReadUInt16();
            if (prolog != 1) throw new BadImageFormatException("Invalid custom attribute prolog.");
        }

        public MetadataReader Reader { get; }

        public string GetArrayType(string elementType, ArrayShape shape) => "";
        public string GetByReferenceType(string elementType) => "";
        public string GetFunctionPointerType(MethodSignature<string> signature) => "";
        public string GetGenericInstance(string genericType, ImmutableArray<string> typestrings) => "";
        public string GetGenericInstantiation(string genericType, ImmutableArray<string> typeArguments) { throw new NotImplementedException(); }
        public string GetGenericMethodParameter(int index) => "";
        public string GetGenericMethodParameter(object genericContext, int index) { throw new NotImplementedException(); }
        public string GetGenericTypeParameter(int index) => "";
        public string GetGenericTypeParameter(object genericContext, int index) { throw new NotImplementedException(); }
        public string GetModifiedType(string modifier, string unmodifiedType, bool isRequired) => "";
        public string GetPinnedType(string elementType) => "";
        public string GetPointerType(string elementType) => "";

        public string GetPrimitiveType(PrimitiveTypeCode typeCode)
        {
            if (typeCode == PrimitiveTypeCode.String) return valueReader.ReadSerializedString();
            return "";
        }
        public string GetSZArrayType(string elementType) => "";
        public string GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind) => "";
        public string GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind) => "";
        public string GetTypeFromSpecification(MetadataReader reader, object genericContext, TypeSpecificationHandle handle, byte rawTypeKind) => "";
    }
}