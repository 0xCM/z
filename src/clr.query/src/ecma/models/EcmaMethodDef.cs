//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
    public record class EcmaMethodDef : IComparable<EcmaMethodDef>
    {
        const string TableName = "ecma.methods";

        public AssemblyKey Assembly;
        
        public EcmaToken Token;

        public @string Namespace;

        public @string DeclaringType;

        public @string MethodName;

        public Address32 Rva;
        
        public BinaryCode SigData;

        public MethodAttributes Attributes;

        public MethodImplAttributes ImplAttributes;

        public EcmaMember Member()
            => new EcmaMember{
                Token = Token,
                Kind = EcmaMemberKind.Method,                
                Assembly = Assembly,
                Namespace = Namespace,
                DeclaringType = DeclaringType,
                Name = MethodName,
            };
        public int CompareTo(EcmaMethodDef src)
            => Member().CompareTo(src.Member());
    }
}