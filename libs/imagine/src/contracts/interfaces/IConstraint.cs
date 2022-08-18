//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IConstraint
    {
        bool Satisfies(object src);
    }

    public interface IConstraint<C> : IConstraint
    {

    }

    public interface IConstraint<C,T> : IConstraint<C>
        where C : IConstraint<C>
    {
        bool Satisfies(T src);

        bool IConstraint.Satisfies(object src)
            => Satisfies((T)src);
    }
}