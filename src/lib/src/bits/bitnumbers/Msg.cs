//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Msg
    {
        public static MsgPattern<string> UnevenNibbles
            => "An even number of nibbles was not provided in the source text '{0}'";

        public static MsgPattern<string> HexParseFailure
            => "The value '{0}' could not be parsed as a hex number";
    }
}