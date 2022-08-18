//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IBranch : ITree
    {

    }

    [Free]
    public interface IBranch<B,L> : IBranch, ITree<B,L>
        where B : IBranch
        where L : ILeaf
    {

    }
}