//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     /// <summary>
    ///  Characterizes a state machine rule predicated wholly or in part on a source state
    /// </summary>
    public interface IFsmStateRule<S> : IFsmRule
    {
        /// <summary>
        /// The source state
        /// </summary>
        S Source {get;}
    }
}