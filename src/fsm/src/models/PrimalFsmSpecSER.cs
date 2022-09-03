//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PrimalFsmSpec<S,E,R>
        where S : unmanaged
        where E : unmanaged
        where R : unmanaged
    {
        public Index<S> States {get;}

        public Index<E> Events {get;}

        public Index<R> Results {get;}

        public Index<FsmTransitionRule<E,S>> Rules {get;}

        [MethodImpl(Inline)]
        public PrimalFsmSpec(S[] states, E[] events, R[] results, params FsmTransitionRule<E,S>[] rules)
        {
            States = states;
            Events = events;
            Results = results;
            Rules = rules;
        }
    }
}