//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using T = FsmTrace;

    public static class FsmX
    {
        /// <summary>
        /// Forms a transition function from a sequence of transition rules
        /// </summary>
        /// <param name="rules">The individual rules that will comprise the function</param>
        /// <typeparam name="E">The input event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static FsmTransitionFunc<E,S> ToFunction<E,S>(this IEnumerable<FsmTransitionRule<E,S>> rules)
            => Fsm.transition(rules.Array());

        /// <summary>
        /// Specifies whether an observer should be notified when a machine transitions from
        /// one state to a different state
        /// </summary>
        /// <param name="trace">The trace specification</param>
        [MethodImpl(Inline)]
        public static bool TraceTransitions(this FsmTrace trace)
            => (trace & T.Transitions) == T.Transitions;

        /// <summary>
        /// Specifies whether an observer should be notified when a machine receives an event
        /// </summary>
        /// <param name="trace">The trace specification</param>
        [MethodImpl(Inline)]
        public static bool TraceEvents(this FsmTrace trace)
            => (trace & T.Events) == T.Events;

        /// <summary>
        /// Specifies whether an observer should be notified when a machine attains the completion state
        /// </summary>
        /// <param name="trace">The trace specification</param>
        [MethodImpl(Inline)]
        public static bool TraceCompletions(this FsmTrace trace)
            => (trace & T.Completions) == T.Completions;

        /// <summary>
        /// Specifies whether an observer should be notified when an error condition is detected
        /// </summary>
        /// <param name="trace">The trace specification</param>
        public static bool TraceErrors(this FsmTrace trace)
            => (trace & T.Errors) == T.Errors;
    }
}