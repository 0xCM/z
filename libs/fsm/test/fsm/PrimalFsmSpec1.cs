//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static PrimalFsmSpec1.Event;
    using static PrimalFsmSpec1.State;

    using api = PrimalFsmSpecs;

    public readonly struct PrimalFsmSpec1
    {
        public readonly Index<Event> Events;

        public readonly Index<State> States;

        public readonly Index<Result> Results;

        public readonly Index<FsmTransitionRule<Event,State>> Rules;

        [MethodImpl(Inline)]
        public PrimalFsmSpec1(Event[] events, State[] states, Result[] results)
        {
            Events = events;
            States = states;
            Results = results;
            Rules = core.array(api.rule(E1,S0,S1), api.rule(E1, S1, S2), api.rule(E1, S2, S3), api.rule(E1,S3, S4), api.rule(E1,S4,S5));
        }

        [MethodImpl(Inline)]
        public PrimalFsmSpec1(Event[] events, State[] states, Result[] results, FsmTransitionRule<Event,State>[] rules)
        {
            Events = events;
            States = states;
            Results = results;
            Rules = rules;
        }

        public FsmTransitionFunc<Event,State> Transition
        {
            [MethodImpl(Inline)]
            get => Fsm.transition(Rules.Storage);
        }

        public enum State : byte
        {
            S0, S1, S2, S3, S4, S5
        }

        public enum Event: byte
        {
            E1 , E2, E3, E4, E5, E6, E7
        }

        public enum Result : byte
        {
            O0, O1, O2, O3, O4, O5, O6, O7, O8, O9, O10
        }
    }
}