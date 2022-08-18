//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies a transition that occurred
    /// </summary>
    public readonly struct AgentTransition
    {
        /// <summary>
        /// Specifies the agent that experienced the transition
        /// </summary>
        public readonly AgentIdentity Agent;

        /// <summary>
        /// Indicates the relative time at which the transition ocurred
        /// </summary>
        public readonly ulong Timestamp;

        /// <summary>
        /// Specifies the state of the agent before the transition
        /// </summary>
        public readonly AgentStatus SourceState;

        /// <summary>
        /// Specifies the state of the agent after the transition
        /// </summary>
        public readonly AgentStatus TargetState;

        [MethodImpl(Inline)]
        public AgentTransition(AgentIdentity id, ulong timestamp, AgentStatus src, AgentStatus dst)
        {
            Agent = id;
            Timestamp = timestamp;
            SourceState = src;
            TargetState = dst;
        }

        public override string ToString()
            => $"Agent {Agent}: {SourceState} -> {TargetState}";
    }
}