//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVar : IExpr
    {
        Name Name {get;}

        bool IsNamed
            => Name.IsNonEmpty;
    }

    [Free]
    public interface IVar<T> : IVar
        where T : IEquatable<T>, IComparable<T>
    {
        T Value {get;}
    }
}