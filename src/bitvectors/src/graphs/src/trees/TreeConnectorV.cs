//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct TreeConnector<V> : IEdge<V>, IEquatable<TreeConnector<V>>
    where V : IDataType<V>, IExpr, ITree<V>
{
    public readonly V Source;

    public readonly V Target;

    [MethodImpl(Inline)]
    public TreeConnector(V src, V dst)
    {
        Source = src;
        Target = dst;
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => Source.Hash | Target.Hash;
    }

    V IArrow<V,V>.Source
        => Source;

    V IArrow<V,V>.Target
        => Target;

    public override int GetHashCode()
        => Hash;

    [MethodImpl(Inline)]
    public bool Equals(TreeConnector<V> src)
        => Source.Equals(src.Source) && Target.Equals(src.Target);

    public string Format()
        => string.Format("{0} -> {1}", Source, Target);

    public override string ToString()
        => Format();
}
