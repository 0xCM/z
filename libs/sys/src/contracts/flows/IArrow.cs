//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IArrow : IExpr
    {
        dynamic Source {get;}

        dynamic Target {get;}

        bool INullity.IsEmpty
            => Source == null || Target == null;
    }

    /// <summary>
    /// Characterizes an association between two parties of heterogenous type
    /// </summary>
    /// <typeparam name="S">The first party type</typeparam>
    /// <typeparam name="T">The second party type</typeparam>
    [Free]
    public interface IArrow<S,T> : IArrow
    {
        new S Source {get;}

        new T Target {get;}

        dynamic IArrow.Source
            => ((IArrow<S,T>)this).Source;

        dynamic IArrow.Target
            => ((IArrow<S,T>)this).Target;

        string IExpr.Format()
            => string.Format("{0} -> {1}", Source, Target);
    }

    [Free]
    public interface IArrow<T> : IArrow<T,T>
    {

    }

    [Free]
    public interface IArrow<S,T,K> : IArrow<S,T>
    {
        K Kind {get;}
   }
}