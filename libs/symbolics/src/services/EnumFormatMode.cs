//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags]
    public enum EnumFormatMode : byte
    {
        Default = 0,

        Expr = 1,

        Name = 2,

        Base10 = 4,

        Base2 = 8,

        Base16 = 16,

        EmptyZero = 32,

        Custom = 255,
    }
}