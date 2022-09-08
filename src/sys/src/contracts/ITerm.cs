//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// The idea is to loosely follow https://en.wikipedia.org/wiki/Term_(logic)
    /// </summary>
    [Free]
    public interface ITerm : IExpr
    {
        Index<IExpr> Terms => sys.empty<IExpr>();
    }

    [Free]
    public interface ITerm<V> : ITerm, IValued<V>
    {

    }

    [Free]
    public interface ITerm<T,V> : ITerm<V>
        where T : ITerm<T,V>
    {

    }
}