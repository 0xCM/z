//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFsmActionRule<A> : IFsmRule
    {
        /// <summary>
        /// The action invoked
        /// </summary>
        A Action {get;}
    }

    public interface IFsmActionRule<S,A> : IFsmActionRule<A>
    {
        /// <summary>
        /// The state upon which the rule is predicated
        /// </summary>
        S Source {get;}
    }
}