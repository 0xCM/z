//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableName), StructLayout(LayoutKind.Sequential, Pack =1)]
    public struct EcmaMethodInfo : IComparable<EcmaMethodInfo>
    {
        const string TableName = "ecma.methods";

        [Render(12)]
        public EcmaToken Token;

        [Render(48)]            
        public VersionedName AssemblyName;

        [Render(24)]
        public @string Namespace;

        [Render(24)]
        public @string DeclaringType;

        [Render(32)]
        public @string MethodName;

        [Render(8)]
        public Address32 Rva;

        [Render(32)]
        public EcmaSig CliSig;

        [Render(32)]
        public MethodImplAttributes ImplAttributes;

        [Render(1)]
        public MethodAttributes Attributes;

        public EcmaMember Member()
            => new EcmaMember{
                Token = Token,
                Kind = EcmaMemberKind.Method,
                AssemblyName = AssemblyName,
                Namespace = Namespace,
                DeclaringType = DeclaringType,
                Name = MethodName
            };

        public int CompareTo(EcmaMethodInfo src)
            => Member().CompareTo(src.Member());

        public static EcmaMethodInfo Empty => new ();
    }
}