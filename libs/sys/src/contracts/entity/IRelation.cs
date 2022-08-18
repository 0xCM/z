//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRelation : IExpr
    {
        dynamic Source {get;}

        dynamic Target {get;}

        string IExpr.Format()
            => $"{Source} -> {Target}";

        bool INullity.IsEmpty
            => Source == null || Target == null;

        bool INullity.IsNonEmpty
            => Source != null && Target != null;
    }

    [Free]
    public interface IRelation<S,T> : IRelation
    {
        new S Source {get;}

        new T Target {get;}

        dynamic IRelation.Source
            => Source;

        dynamic IRelation.Target
            => Target;
    }

    [Free]
    public interface IRelation<T> : IRelation<T,T>
    {

    }

    [Free]
    public interface IRelation<K,S,T> : IRelation<S,T>
    {
        K Kind {get;}
    }
}