//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TokenDispenser
    {
        static long StartToken;

        static long EndToken;

        public static TokenDispenser create()
            => new TokenDispenser();

        [MethodImpl(Inline)]
        public ExecToken Open()
            => new ExecToken((ulong)sys.inc(ref StartToken));

        [MethodImpl(Inline)]
        public ExecToken Close(ExecToken src)
            => src.Complete((ulong)sys.inc(ref EndToken));
    }
}