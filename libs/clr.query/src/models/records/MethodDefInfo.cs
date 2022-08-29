//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MethodDefInfo
    {
        const string TableId = "method.defs";

        [Render(32)]
        public string Name;

        [Render(12)]
        public CliToken Token;

        [Render(8)]
        public Address32 Rva;

        [Render(32)]
        public CliSig CliSig;

        [Render(32)]
        public string Component;

        [Render(32)]
        public MethodImplAttributes ImplAttributes;

        [Render(1)]
        public MethodAttributes Attributes;
    }
}