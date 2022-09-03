//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    ///  Characterizes a rule of the form (input : E, source : S) -> target : S
    /// </summary>
    /// <typeparam name="E">The input event type</typeparam>
    /// <typeparam name="S">The source state</typeparam>
    public interface IFsmTransitionRule<E,S> : IFsmRule<E,S>
    {
        /// <summary>
        /// The target state
        /// </summary>
        S Target {get;}
    }
}