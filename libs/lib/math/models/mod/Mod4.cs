//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Mod4
    {
        const ulong N = 4;

        const ulong M = (ulong.MaxValue / N) + 1;

        [MethodImpl(Inline)]
        public static uint mod(uint a)
            => ModOps.mod(M, N, a);

        [MethodImpl(Inline)]
        public static uint div(uint a)
            => ModOps.div(M, N, a);
    }
}