//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CliMemberField
    {
        const string TableId = "cli.fields";

        [Render(10)]
        public CliToken Token;

        [Render(10)]
        public uint Offset;

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