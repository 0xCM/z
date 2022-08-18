//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies a state machine via scalar values
    /// </summary>
    /// <typeparam name="T">A scalar type of sufficient size to accommodate specified characteristics</typeparam>
     public struct PrimalFsmSpec<T>
        where T : unmanaged
    {
        /// <summary>
        /// An identifier that defines a membership class that is propagaged to all machines predicated on the specification
        /// </summary>
        public string Classifier;

        /// <summary>
        /// The number of states the machine will support
        /// </summary>
        public T StateCount;

        /// <summary>
        /// The number of events the machine will recognize
        /// </summary>
        public T EventCount;

        /// <summary>
        /// The minimum number of events that will be sampled for each state
        /// </summary>
        public T MinEventSamples;

        /// <summary>
        /// The maximum number of events that will be sampled for each state
        /// </summary>
        public T MaxEventSamples;

        /// <summary>
        /// The maximum number of events that the machine will accept
        /// </summary>
        public ulong ReceiptLimit;

        /// <summary>
        /// The initial state as determined by the default value of the primal type, i.e. StartState = default
        /// </summary>
        public T StartState;

        /// <summary>
        /// The final state as determined by the state count, i.e. EndState := StateCount - 1
        /// </summary>
        public T EndState;

        public PrimalFsmSpec(string classifier, T states, T events, T minSamples, T maxSamples, ulong maxReceipts)
        {
            Classifier = classifier;
            StateCount = states;
            EventCount = events;
            MinEventSamples = minSamples;
            MaxEventSamples = maxSamples;
            ReceiptLimit = maxReceipts;
            StartState = default;
            EndState = gmath.dec(states);
        }
    }
}