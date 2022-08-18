//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INatNumber<F> : ITypeNat<F>
        where F : unmanaged, INatNumber<F>
    {

    }
}