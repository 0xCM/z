//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface INaturalSeq<N,T> : ISeq<T>
        where N : unmanaged, ITypeNat
    {
        uint ICounted.Count
            => Typed.nat32u<N>();
    }
}