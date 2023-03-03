//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public record class EcmaMethodDef
    {
        [Render(12)]
        public EcmaToken Token;

        [Render(32)]
        public string Name;

        [Render(12)]
        public Address32 Rva;

        [Render(32)]
        public MethodImplAttributes ImplAttributes;

        [Render(1)]
        public MethodAttributes Attributes;
    }
}