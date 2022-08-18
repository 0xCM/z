//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("coff")]
    public enum ImageSymType : ushort
    {
        NULL = 0,

        VOID = 1,

        CHAR = 2,

        SHORT = 3,

        INT = 4,

        LONG = 5,

        FLOAT = 6,

        DOUBLE = 7,

        STRUCT = 8,

        UNION = 9,

        ENUM = 10,

        MOE = 11,

        BYTE = 12,

        WORD = 13,

        UINT = 14,

        DWORD = 15
    }
}