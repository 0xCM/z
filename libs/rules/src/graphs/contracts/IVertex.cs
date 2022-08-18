//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVertex : IExpr
    {
        object Value {get;}

        Seq<Vertex> Targets {get;}

        bool INullity.IsEmpty
            => Value == null;
    }

    [Free]
    public interface IVertex<V> : IVertex, IEquatable<V>, IHashed
        where V : IDataType<V>, IExpr
    {
        new V Value {get;}

        new Seq<Vertex<V>> Targets {get;}

        object IVertex.Value
            => Value;

        Seq<Vertex> IVertex.Targets
            => new Seq<Vertex>(Targets.Map(x =>new Vertex(x)));
    }
}