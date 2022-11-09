//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsmLoopLimits
    {
        public readonly int I;

        public readonly int J;

        public readonly int K;

        [MethodImpl(Inline)]
        public AsmLoopLimits(int i, int j, int k)
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
        public static implicit operator AsmLoopLimits((int i, int j, int k) src)
            => new AsmLoopLimits(src.i,src.j,src.k);
    }    
}