//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Bears witness to an occurrence of something of identifiable interest
    /// at a unique point in spacetime. The (Location,Timestamp,EventKind) triplet
    /// confers upon the event a logical identity that identifies it across all spacetime.
    /// The implicit invariant that this construct confers upon an event source, which has
    /// a fixed location, is that the source many not produce two events of the same kind
    /// at the same moment in time, relative to timestamp resolution
    /// </summary>
    [Free]
    public interface IAgentEvent
    {
        /// <summary>
        /// Identifies a system event with respect to time/space/subject
        /// </summary>
        AgentEventId Identity {get;}

        /// <summary>
        /// Specifies an event classifier that can be used to aggregate/distinguish sorts of events
        /// </summary>
        ulong EventKind
            => Identity.EventKind;

        /// <summary>
        /// Identifies the server that originated the event
        /// </summary>
        uint ServerId
            => Identity.ServerId;

        /// <summary>
        /// Identifies the server-owned agent that originated the event
        /// </summary>
        uint AgentId
            => Identity.AgentId;

        /// <summary>
        /// A value that uniquely identifies the logical event source, predicated
        /// on server and agent identity
        /// </summary>
        ulong LocationId
            => Identity.Location;

        /// <summary>
        /// The time of occurrence, expressed as number of elapsed units
        /// from some fixed point in time
        /// </summary>
        Timestamp Timestamp
            => Identity.Timestamp;
    }
}