//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class Forest
{
    MutableSet<TreeConnector> _EdgeSet;

    Index<Tree> _Vertices;

    Index<TreeConnector> _Edges;

    bool Sealed;

    public Forest()
    {
        _EdgeSet = new();
        _Vertices = Index<Tree>.Empty;
        _Edges = Index<TreeConnector>.Empty;
        Sealed = false;
    }

    public Forest(TreeConnector[] src)
    {
        _EdgeSet = new MutableSet<TreeConnector>(src);
        Sealed = false;
    }

    public void Connect(Tree src, Tree dst)
    {
        if(!Sealed)
            _EdgeSet.Include((src,dst));
    }

    public Forest Seal()
    {
        if(!Sealed)
        {
            var vertices = hashset<Tree>();
            foreach(var e in _EdgeSet)
            {
                vertices.Add(e.Source);
                vertices.Add(e.Target);
            }
            _Vertices = vertices.Array();
            _Edges = _EdgeSet.Array();
            Sealed = true;
        }
        return this;
    }

    public uint Order
    {
        [MethodImpl(Inline)]
        get => _Vertices.Count;
    }

    public uint EdgeCount
    {
        [MethodImpl(Inline)]
        get => _Edges.Count;
    }

    public ReadOnlySpan<TreeConnector> Edges
    {
        [MethodImpl(Inline)]
        get => _Edges.View;
    }

    public ReadOnlySpan<Tree> Vertices
    {
        [MethodImpl(Inline)]
        get => _Vertices.View;
    }

    public void Walk(Action<TreeConnector> receiver)
        => iter(_EdgeSet, receiver);
}
