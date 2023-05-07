//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags]
    public enum AsciTableKind : byte
    {
        None = 0,

        Digits = 1,

        LowerLetters = 2,

        UpperLetters = 4,

        Full = 128,
    }
}