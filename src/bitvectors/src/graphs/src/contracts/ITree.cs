//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITree : IExpr
    {
        Seq<Tree> Children {get;}

        bool INullity.IsEmpty
            => Children.IsEmpty;
    }

    [Free]
    public interface ITree<V> : ITree, IEquatable<V>, IHashed
        where V : IDataType<V>, IExpr
    {

        new Seq<Tree<V>> Children {get;}

        Seq<Tree> ITree.Children
            => new Seq<Tree>(Children.Map(x =>new Tree(x)));
    }
}