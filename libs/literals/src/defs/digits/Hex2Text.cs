//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = Hex2Kind;

    [LiteralProvider(hex_digits)]
    public readonly struct Hex2Text
    {
        public const string x00 = nameof(K.x00);

        public const string x01 = nameof(K.x01);

        public const string x02 = nameof(K.x02);

        public const string x03 = nameof(K.x03);
    }
}