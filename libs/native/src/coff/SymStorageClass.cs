//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("coff")]
    public enum SymStorageClass : byte
    {
        None = 0,

        Auto = 1,

        Extern = 2,

        Static = 3,

        Register = 4,

        ExternDef = 5,

        Label = 6,

        UndefinedLabel = 7,

        StructMember = 8,

        Argument = 9,

        StructTag = 10,

        UnionMember = 11,

        UnionTag = 12,

        TypeDef = 13,

        UndefinedStatic = 14,

        EnumTag = 15,

        EnumMember = 16,

        RegisterParm = 17,

        Bitfield = 18,

        Block = 100,

        Function = 101,

        StructEnd = 102,

        File = 103,

        Section = 104,

        ExternWeak = 105,

        ClrToken = 107,

        FunctionEnd = 255,
    }
}