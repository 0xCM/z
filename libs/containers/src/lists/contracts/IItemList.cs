//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IItemList<I> : IIndex<I>
        where I : IListItem
    {

    }

    public interface IItemList<I,K,T> : IItemList<I>
        where K : unmanaged
        where I : IListItem
    {

    }
}