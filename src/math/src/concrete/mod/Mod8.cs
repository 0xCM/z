//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Mod8
    {
        const ulong N = 8;

        const ulong M = (ulong.MaxValue / N) + 1;

        [MethodImpl(Inline)]
        public static uint mod(uint a)
            => ModOps.mod(M, N, a);

        [MethodImpl(Inline)]
        public static uint div(uint a)
            => ModOps.div(M, N, a);

        [MethodImpl(Inline)]
        public static int mod(int a)
            => (int)ModOps.mod(M, N, (uint)a);

        [MethodImpl(Inline)]
        public static int div(int a)
            => (int)ModOps.div(M, N, (uint)a);
    }

    public static class Mod25
    {
        const ulong N = 25;

        const ulong M = (ulong.MaxValue / N) + 1;

        [MethodImpl(Inline)]
        public static uint mod(uint a)
            => ModOps.mod(M, N, a);

        [MethodImpl(Inline)]
        public static uint div(uint a)
            => ModOps.div(M, N, a);
    }

    public static class Mod32
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

    public static class Mod128
    {
        const ulong N = 128;

        const ulong M = (ulong.MaxValue / N) + 1;

        [MethodImpl(Inline)]
        public static uint mod(uint a)
            => ModOps.mod(M, N, a);

        [MethodImpl(Inline)]
        public static uint div(uint a)
            => ModOps.div(M, N, a);
    }
}