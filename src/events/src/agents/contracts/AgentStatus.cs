//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Pow2;

    /// <summary>
    /// Defines canonical states in the lifecycle of an agent
    /// </summary>
    public enum AgentStatus : uint
    {
        /// <summary>
        /// The agent state after instantiation. If configuration data is available,
        /// the agent transitions automatically to the <see cref='Configuring' state/>
        /// </summary>
        Created = T00,

        /// <summary>
        /// The state in which the agent is consuming configuration data and adusting
        /// internal state accordingly and, upon successful completion, transitions to the
        /// <see cref='Configured'/> state
        /// </summary>
        Configuring = T01,

        /// <summary>
        /// The state to which the agent transitions after successful completion of the
        /// <see cref='Configuring' state/>. Transition to this state is a precondition
        /// to transition to the <see cref='Starting'/> state
        /// </summary>
        Configured = T02,

        /// <summary>
        /// The state in which the agent is initialzing internal state, predicated on configuration
        /// data, if any. Upon successful completion, the agent tansitions to the <see cref='Started' state/>
        /// </summary>
        Starting = T03,

        /// <summary>
        /// The state in which the agent has been initialized and, once entered, immediately transitions to
        /// the <see cref='Running'/> state unless the agent is configured to be inactive; if inactive,
        /// the agent remains in this state until the agent receives an administrative-level event
        /// that specifies the next state
        /// </summary>
        Started  = T04,

        /// <summary>
        /// The state in which the agent is working, querying for work or listening to events that define/imply
        /// work. The agent will remain in this state until a stop event is received, an unrecoverable eror
        /// occurs or other.
        /// </summary>
        Running = T05,

        /// <summary>
        /// The state in which the agent is gracefully terminating the run-loop
        /// </summary>
        Stopping = T06,

        Stopped = T07,

        Terminating = T08,

        Terminated = T09,

        Error = uint.MaxValue
    }
}