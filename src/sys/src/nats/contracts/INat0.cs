//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = N0;

    public interface INat0<F> : INatNumber<N>, INatSeq<N>, INatEven<N>, INatPrimitive<N>
        where F : unmanaged, INat0<F>
    {
        
    }
}