//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct EcmaMethodDef
    {
        public AssemblyKey Assembly;
        
        public EcmaToken Token;

        public @string Namespace;

        public @string DeclaringType;

        public @string MethodName;

        public Address32 Rva;
        
        public BinaryCode SigData;

        public MethodAttributes Attributes;

        public MethodImplAttributes ImplAttributes;
    }
}