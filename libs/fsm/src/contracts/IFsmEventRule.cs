//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    ///  Characterizes a state machine rule predicated wholly or in part on an input event
    /// </summary>
    public interface IFsmEventRule<E> : IFsmRule
    {
        /// <summary>
        /// The triggering event
        /// </summary>
        E Trigger {get;}
    }
}