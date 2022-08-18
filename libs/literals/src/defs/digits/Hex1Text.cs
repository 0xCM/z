//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = Hex1Kind;

    [LiteralProvider(hex_digits)]
    public readonly struct Hex1Text
    {
        public const string x00 = nameof(K.x00);

        public const string x01 = nameof(K.x01);
    }
}