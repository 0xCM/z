//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Requires that the natural representative is nonzero
    /// </summary>
    public interface INonZeroNat : ITypeNat
    {

    }

    /// <summary>
    /// Requires k:K => k != 0
    /// </summary>
    /// <typeparam name="K">A nonzero natural type</typeparam>
    public interface INonZeroNat<K> : INonZeroNat
        where K : unmanaged, ITypeNat
    {

    }
}