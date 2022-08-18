//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITree
    {
        Index<IBranch> Branches {get;}

        Index<ILeaf> Leaves {get;}
    }

    public interface ITree<T> : ITree
        where T : ILeaf
    {
        new Index<IBranch> Branches {get;}

        new Index<T> Leaves {get;}

        Index<IBranch> ITree.Branches
            => Branches.Cast<IBranch>();

        Index<ILeaf> ITree.Leaves
            => Branches.Cast<ILeaf>();
    }

    public interface ITree<B,L> : ITree
        where B : IBranch
        where L : ILeaf
    {
        new Index<B> Branches {get;}

        new Index<L> Leaves {get;}

        Index<IBranch> ITree.Branches
            => Branches.Cast<IBranch>();

        Index<ILeaf> ITree.Leaves
            => Branches.Cast<ILeaf>();
    }
}