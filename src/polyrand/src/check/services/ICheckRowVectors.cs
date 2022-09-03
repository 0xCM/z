//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICheckRowVectors : IClaimValidator
    {
        int length<T>(RowVector256<T> a, RowVector256<T> b)
            where T : unmanaged
                => CheckRowVectors.length(a,b);
    }

    public interface ICheckRowVectors<C> : ICheckRowVectors
        where C : ICheckRowVectors<C>, new()
    {

    }
}