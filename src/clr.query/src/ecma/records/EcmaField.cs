//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct EcmaField
    {
        const string TableId = "ecma.fields";

        [Render(10)]
        public EcmaToken Token;

        [Render(10)]
        public Address32 Offset;

        [Render(10)]
        public Address32 Rva;

        [Render(56)]
        public string FieldName;

        [Render(56)]
        public FieldAttributes Attribs;

        [Render(1)]
        public BinaryCode Sig;
    }
}