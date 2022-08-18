//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    unsafe partial struct LoopModels
    {
        public readonly struct Limits3
        {
            public readonly int I;

            public readonly int J;

            public readonly int K;

            [MethodImpl(Inline)]
            public Limits3(int i, int j, int k)
            {
                I = i;
                J = j;
                K = k;
            }

            [MethodImpl(Inline)]
            public void Destrucuture(out int i, out int j, out int k)
            {
                i = I;
                j = J;
                k = K;
            }

            [MethodImpl(Inline)]
            public static implicit operator Limits3((int i, int j, int k) src)
                => new Limits3(src.i,src.j,src.k);
        }
    }
}