//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a thread of control with independent volition
    /// </summary>
    [Free]
    public interface IAgentMachine : IAgent
    {
        /// <summary>
        /// The agent state
        /// </summary>
        AgentStatus State {get;}

        /// <summary>
        /// Signals when the agents transitions from its current state to a different state
        /// </summary>
        event OnAgentTransition Transition;
    }
}