//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDataFlow : IArrow
    {
        Actor Actor {get;}
    }

    /// <summary>
    /// Characterizes a data flow
    /// </summary>
    /// <typeparam name="S">The source type</typeparam>
    /// <typeparam name="T">The target type</typeparam>
    [Free]
    public interface IDataFlow<S,T> : IDataFlow, IArrow<S,T>
    {
        string IExpr.Format()
            => string.Format("{0}:{1} -> {2}", Actor, Source, Target);
    }

    [Free]
    public interface IDataFlow<A,S,T> : IDataFlow<S,T>
    {
        new A Actor {get;}
    }
}