//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class Mod256
    {
        const ulong N = 32;

        const ulong M = (ulong.MaxValue / N) + 1;

        [MethodImpl(Inline)]
        public static uint mod(uint a)
            => ModOps.mod(M, N, a);

        [MethodImpl(Inline)]
        public static uint div(uint a)
            => ModOps.div(M, N, a);
    }
}