//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    ///  Characterizes a rule of the form (input : E, source : S) -> output : S
    /// </summary>
    /// <typeparam name="S">The state type</typeparam>
    /// <typeparam name="O">The output type</typeparam>
    public interface IFsmOutputRule<E,S,O> : IFsmRule<E,S>
    {
        /// <summary>
        /// The output produced
        /// </summary>
        O Output {get;}
    }
}