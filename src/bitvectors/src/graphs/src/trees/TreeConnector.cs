//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly struct TreeConnector : IEquatable<TreeConnector>, IEdge<Tree>
{
    public readonly Tree Source {get;}

    public readonly Tree Target {get;}

    [MethodImpl(Inline)]
    public TreeConnector(Tree src, Tree dst)
    {
        Source = src;
        Target = dst;
    }

    [MethodImpl(Inline)]
    public void Deconstruct(out Tree src, out Tree dst)
    {
        src = Source;
        dst = Target;
    }

    public string Format()
        => string.Format("{0} -> {1}", Source, Target);

    [MethodImpl(Inline)]
    public bool Equals(TreeConnector src)
        => Source == src.Source && Target == src.Target;

    public override string ToString()
        => Format();

    public override int GetHashCode()
        => Source.Hash | Target.Hash;

    public override bool Equals(object src)
        => src is TreeConnector e && Equals(e);

    [MethodImpl(Inline)]
    public static implicit operator TreeConnector((Tree src, Tree dst) x)
        => new TreeConnector(x.src, x.dst);

    [MethodImpl(Inline)]
    public static bool operator ==(TreeConnector a, TreeConnector b)
        => a.Equals(b);

    [MethodImpl(Inline)]
    public static bool operator !=(TreeConnector a, TreeConnector b)
        => !a.Equals(b);
}
