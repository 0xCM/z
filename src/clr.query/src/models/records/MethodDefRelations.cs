//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MethodDefRelations
    {
        const string TableId = "method.defs.relations";

        [Render(12)]
        public CliToken Token;

        [Render(12)]
        public Address32 Rva;

        [Render(12)]
        public CliStringIndex NameKey;

        [Render(12)]
        public CliBlobIndex SigKey;

        [Render(12)]
        public CliRowKey FirstParam;

        [Render(12)]
        public ushort ParamCount;

        [Render(32)]
        public MethodImplAttributes ImplAttributes;

        [Render(1)]
        public MethodAttributes Attributes;
    }
}