//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IIteratorRelay<T> : IOutputIterator<T>, IMutableIterator<T>, IReadOnlyIterator<T>
    {

    }

    public interface IIteratorRelay<H,T> : IIteratorRelay<T>, IOutputIterator<H,T>, IMutableIterator<H,T>, IReadOnlyIterator<H,T>
        where H: IIteratorRelay<H,T>
    {

    }
}