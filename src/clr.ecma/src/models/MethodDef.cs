//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
        public record class MethodDef : IComparable<MethodDef>
        {
            const string TableName = "methods.defs";

            [Render(12)]
            public EcmaToken Token;

            [Render(48)]            
            public AssemblyKey AssemblyKey;
            
            [Render(24)]
            public @string Namespace;

            [Render(24)]
            public @string DeclaringType;

            [Render(24)]
            public @string MethodName;

            [Render(16)]
            public Address32 Rva;
            
            [Render(48)]
            public EcmaSig BinarySig;

            [Render(82)]
            public MethodAttributes Attributes;

            [Render(48)]
            public MethodImplAttributes ImplAttributes;

            [Render(1)]
            public MethodSignature<string> MethodSignature;

            public EcmaMember Member()
                => new EcmaMember{
                    Token = Token,
                    Kind = EcmaMemberKind.Method,                
                    AssemblyName = AssemblyKey.AssemblyName,
                    Namespace = Namespace,
                    DeclaringType = DeclaringType,
                    Name = MethodName,
                };
            public int CompareTo(MethodDef src)
                => Member().CompareTo(src.Member());
        }
    }
}