//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Requires k:K => k % 2 == 0
    /// </summary>
    /// <typeparam name="K">An even natural type</typeparam>
    public interface INatEven<K> : ITypeNat, INatDivisible<K,N2>
        where K : unmanaged, ITypeNat
    {

    }    

}