//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using M = PrimalFsmSpec1;

    [ApiHost]
    public readonly struct PrimalFsmSpecs
    {
        [MethodImpl(Inline), Op]
        public static PrimalFsmSpec<M.State,M.Event,M.Result> modelG(M.State[] states, M.Event[] events, M.Result[] results)
            => create(states, events, results);

        [Op]
        public static PrimalFsmSpec1 model(M.Event[] events, M.State[] states, M.Result[] results)
            => new PrimalFsmSpec1(events, states, results);

        [MethodImpl(Inline)]
        public static FsmTransitionRule<E,S> rule<E,S>(E trigger, S source, S target)
            where E : unmanaged
            where S : unmanaged
                => (trigger,source,target);

        [MethodImpl(Inline)]
        public static PrimalFsmSpec<S,E,R> create<S,E,R>(S[] states, E[] events, R[] results)
            where S : unmanaged
            where E : unmanaged
            where R : unmanaged
                => new PrimalFsmSpec<S,E,R>(states, events, results);

        public static PrimalFsmSpec<M.State,M.Event,M.Result> model()
            => modelG(Enums.literals<M.State>(), Enums.literals<M.Event>(), Enums.literals<M.Result>());
    }
}