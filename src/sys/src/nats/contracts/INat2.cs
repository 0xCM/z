//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INat2<F> : 
        INatNumber<N2>, 
        INatPrimitive<N2>, 
        INatSeq<N2>, 
        INatPrime<N2>, 
        INatPow<N2,N2,N1>, 
        INatEven<N2>, 
        INatPrior<N2,N1>, 
        INatPow2<N1>
            where F : unmanaged, INat2<F>
    {
        
    }
}