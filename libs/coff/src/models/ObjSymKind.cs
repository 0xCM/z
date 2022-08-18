//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource("coff")]
    public enum ObjSymKind : byte
    {
        None = 0,

        AbsoluteSymbol = 1,

        BssSection = 2,

        BssObject = 3,

        CodeObject = 4,

        CodeSection = 5,

        Common = 6,

        CoffDebugSymbol = 7,

        DataSection = 8,

        DataObject = 9,

        ReadOnlyDataSection = 0xA,

        ReadOnlyDataObject = 0xB,

        DebugSymbol = 0xC,

        UndefinedSymbol = 0xD,

        Other = 0xF,
    }
}