//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableName), StructLayout(LayoutKind.Sequential, Pack =1)]
    public struct EcmaMethodInfo 
    {
        const string TableName = "ecma.method.defs.info";

        [Render(32)]
        public @string Name;

        [Render(12)]
        public EcmaToken Token;

        [Render(8)]
        public Address32 Rva;

        [Render(32)]
        public EcmaSig CliSig;

        [Render(32)]
        public @string Component;

        [Render(32)]
        public MethodImplAttributes ImplAttributes;

        [Render(1)]
        public MethodAttributes Attributes;

        public static EcmaMethodInfo Empty => new ();
    }
}