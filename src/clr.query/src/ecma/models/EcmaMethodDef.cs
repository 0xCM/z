//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public record struct EcmaMethodDef
    {
        public EcmaToken Token;

        public string Name;

        public Address32 Rva;
        
        public BinaryCode SigData;

        public MethodAttributes Attributes;

        public MethodImplAttributes ImplAttributes;

    }
}