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

        [Render(12)]
        public EcmaToken Token;

        public AssemblyKey AssemblyKey;

        [Render(48)]            
        public VersionedName AssemblyName;
        
        [Render(24)]
        public @string Namespace;

        [Render(24)]
        public @string DeclaringType;

        [Render(24)]
        public @string Name;

        public Address32 Rva;
        
        public BinaryCode SigData;

        public MethodAttributes Attributes;

        public MethodImplAttributes ImplAttributes;

        public EcmaMember Member()
            => new EcmaMember{
                Token = Token,
                Kind = EcmaMemberKind.Method,                
                AssemblyName = AssemblyName,
                Namespace = Namespace,
                DeclaringType = DeclaringType,
                Name = Name,
            };
        public int CompareTo(EcmaMethodDef src)
            => Member().CompareTo(src.Member());
    }
}