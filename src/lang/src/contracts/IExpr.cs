//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public interface IExpr<T> : IExpr, IEquatable<T>, INullity, IHashed
        where T : IExpr<T>, new()
    {

    }
}