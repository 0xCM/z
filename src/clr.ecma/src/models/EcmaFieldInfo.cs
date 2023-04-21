//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableName), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct EcmaFieldInfo
    {
        const string TableName = "ecma.fieldinfo";

        public EcmaToken Index;

        public Address32 Offset;

        public Address32 Rva;

        public @string FieldName;

        public FieldAttributes Attribs;

        public BinaryCode Sig;
    }

}