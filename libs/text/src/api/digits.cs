//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        [Op]
        public static string digits(byte n)
            => embrace($"0:D{n}");

        public static string digits(byte index, byte n)
            => Chars.LBrace + $"{index}:D{n}" + Chars.RBrace;
    }
}