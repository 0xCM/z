//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INat1<F> : INatNumber<N1> ,INatPrimitive<N1>, INatPrior<N1,N0>, INatSeq<N1>, INatPow<N1,N1,N0>, INatOdd<N1>, INatPow2<N0>
        where F : unmanaged, INat1<F>
    {
        
    }
}