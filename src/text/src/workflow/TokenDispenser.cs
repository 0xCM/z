//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class TokenDispenser
    {
        public static ref readonly TokenDispenser Service => ref Instance;

        long StartToken;

        long EndToken;

        static TokenDispenser Instance;
        
        private TokenDispenser()
        {
            StartToken = 0;
            EndToken = 0;
        }

        public static TokenDispenser create()
            => Instance;

        [MethodImpl(Inline), Op]
        public ExecToken Open()
            => new ExecToken((ulong)inc(ref StartToken));

        [MethodImpl(Inline), Op]
        public ExecToken Close(ExecToken src, bool success = true)
            => src.Complete((ulong)inc(ref EndToken), success);

        static TokenDispenser()
        {
            Instance = new();
        }
    }
}