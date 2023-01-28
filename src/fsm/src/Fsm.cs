//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.Threading.Tasks;

    using static Fsm1Spec.StateKinds;

    [ApiHost]
    public readonly struct Fsm
    {
        public static void example1()
        {
            var spec = new Fsm1Spec();
            var tasks = new Task[Pow2.T08];
            var indices = gcalc.stream(0xFFFFul, 0xFFFFFFFFul).Where(x => x % 2 != 0).Take(Pow2.T08).ToArray();
            for(var i=0u; i<tasks.Length; i++)
            {
                var machine = Fsm.machine($"Fsm1-{i}", Fsm.context(), S0,S5, spec.TransFunc);
                tasks[i] = Fsm.run(machine,Rng.pcg64(0,indices[i]));
            }
            Task.WaitAll(tasks);
        }

        [MethodImpl(Inline)]
        public static FsmTransitionRule<E,S> rule<E,S>(E trigger, S source, S target)
            where E : unmanaged
            where S : unmanaged
                => (trigger,source,target);

        /// <summary>
        /// Creates a machine context
        /// </summary>
        /// <param name="random">The random source</param>
        [MethodImpl(Inline), Op]
        public static IFsmContext context(ulong? receiptLimit = null)
            => new FsmContext(receiptLimit);

        /// <summary>
        /// Defines a single state transition rule of the form (trigger : E, source : S) -> target : S
        /// </summary>
        /// <param name="trigger">The incoming event</param>
        /// <param name="source">The source state</param>
        /// <param name="target">The target state</param>
        /// <typeparam name="E">The event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static FsmTransitionRule<E,S> transition<E,S>(E trigger, S source, S target)
            => new FsmTransitionRule<E,S>(trigger,source,target);

        /// <summary>
        /// Defines a machine transition function (trigger : E, source: S) -> target : S
        /// that determines machine transition behavior
        /// </summary>
        /// <param name="rules">The rules that comprise the function</param>
        /// <typeparam name="E">The event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static FsmTransitionFunc<E,S> transition<E,S>(IEnumerable<IFsmTransitionRule<E,S>> rules)
            => new FsmTransitionFunc<E,S>(rules);

        /// <summary>
        /// Defines an output rule of the form (trigger : E, source : S) -> output : O
        /// that specifies that output to emit when an input is received when in the source state
        /// </summary>
        /// <param name="trigger">The triggering event</param>
        /// <param name="source">The source state</param>
        /// <param name="output">The output value</param>
        /// <typeparam name="E">The event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static FsmOutputRule<E,S,O> output<E,S,O>(E trigger, S source, O output)
            => (trigger, source, output);

        /// <summary>
        /// Defines a machine transition function (trigger : E, source: S) -> target : S
        /// that determines machine transition behavior
        /// </summary>
        /// <param name="rules"></param>
        /// <typeparam name="E">The event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static FsmOutputFunc<E,S,O> output<E,S,O>(IEnumerable<IFsmOutputRule<E,S,O>> rules)
            => new FsmOutputFunc<E, S, O>(rules);

        /// <summary>
        /// Defines an action that fires upon state entry
        /// </summary>
        /// <param name="source">The source state</param>
        /// <param name="target">The the entry action</param>
        /// <typeparam name="S">The state type</typeparam>
        /// <typeparam name="A">The action type</typeparam>
        [MethodImpl(Inline)]
        public static FsmActionRule<S,A> entry<S,A>(S source, A action)
            => new FsmActionRule<S,A>(source,action);

        /// <summary>
        /// Defines an entry action function
        /// </summary>
        /// <param name="rules">The state entry rules</param>
        /// <typeparam name="S">The state type</typeparam>
        /// <typeparam name="A">The action type</typeparam>
        [MethodImpl(Inline)]
        public static FsmEntryFunc<S,A> entry<S,A>(IEnumerable<IFsmActionRule<S,A>> rules)
            => new FsmEntryFunc<S,A>(rules);

        /// <summary>
        /// Defines an action that fires upon state exit
        /// </summary>
        /// <param name="source">The source state</param>
        /// <param name="target">The the exit action</param>
        /// <typeparam name="S">The state type</typeparam>
        /// <typeparam name="A">The action type</typeparam>
        [MethodImpl(Inline)]
        public static FsmActionRule<S,A> exit<S,A>(S source, A action)
            => new FsmActionRule<S,A>(source,action);

        /// <summary>
        /// Defines an exit action function
        /// </summary>
        /// <param name="rules">The state exit rules</param>
        /// <typeparam name="S">The state type</typeparam>
        /// <typeparam name="A">The action type</typeparam>
        [MethodImpl(Inline)]
        public static FsmExitFunc<S,A> exit<S,A>(IEnumerable<IFsmActionRule<S,A>> rules)
            => new FsmExitFunc<S,A>(rules);

        /// <summary>
        /// Defines the most basic FSM, predicated only on ground-state, end-state and transition function
        /// </summary>
        /// <param name="id">Identifies the machine within the context of the executing process</param>
        /// <param name="s0">The ground-state</param>
        /// <param name="sZ">The end-state</param>
        /// <param name="f">The transition function</param>
        /// <typeparam name="E">The event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static Fsm<E,S> machine<E,S>(string id, IFsmContext context, S s0, S sZ, FsmTransitionFunc<E,S> f)
            => new Fsm<E,S>(id, context, s0, sZ, f);

        /// <summary>
        /// Defines the most basic FSM, predicated only on ground-state, end-state and transition function
        /// </summary>
        /// <param name="id">Identifies the machine within the context of the executing process</param>
        /// <param name="s0">The ground-state</param>
        /// <param name="sZ">The end-state</param>
        /// <param name="f">The transition function</param>
        /// <typeparam name="E">The event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static Fsm<E,S> machine<E,S>(string id, S s0, S sZ, FsmTransitionFunc<E,S> f, ulong? limit = null)
            => new Fsm<E,S>(id, s0, sZ, f, limit);

        /// <summary>
        /// Defines an output rule key
        /// </summary>
        /// <param name="source">The antecedent state</param>
        /// <param name="input">The output value</param>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static FsmOutputRuleKey<E,S> outKey<E,S>(E trigger, S source)
            => (trigger,source);

        /// <summary>
        /// Defines an entry rule key
        /// </summary>
        /// <param name="source">The antecedent state</param>
        /// <param name="input">The output value</param>
        /// <typeparam name="E">The input event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static FsmActionRuleKey<S> entryKey<S>(S source)
            => source;

        /// <summary>
        /// Defines an exit rule key
        /// </summary>
        /// <param name="source">The antecedent state</param>
        /// <param name="input">The output value</param>
        /// <typeparam name="E">The input event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static FsmActionRuleKey<S> exitKey<S>(S source)
            => source;

        /// <summary>
        /// Defines a key for a transition rule
        /// </summary>
        /// <param name="trigger">The triggering event</param>
        /// <param name="source">The source state</param>
        /// <typeparam name="E">The event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static FsmTransitionRuleKey<E,S> transitionKey<E,S>(E trigger, S source)
            => (trigger,source);

        /// <summary>
        /// Defines a machine that supports entry/exit actions on a per-state basis
        /// </summary>
        /// <param name="id">Identifies the machine within the context of the executing process</param>
        /// <param name="s0">The ground-state</param>
        /// <param name="sZ">The end-state</param>
        /// <param name="t">The transition function</param>
        /// <param name="entry">The entry function</param>
        /// <param name="exit">The exit function</param>
        /// <typeparam name="E">The event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        /// <typeparam name="A">The entry action type</typeparam>
        [MethodImpl(Inline)]
        public static Fsm<E,S,A> machine<E,S,A>(string id, S s0, S sZ, FsmTransitionFunc<E,S> t, FsmEntryFunc<S,A> entry, FsmExitFunc<S,A> exit, ulong? limit = null)
            => new Fsm<E,S,A>(id, s0, sZ, t, entry,exit, limit);

        /// <summary>
        /// Creates a default machine observer
        /// </summary>
        /// <param name="fsm">The machine under observation</param>
        /// <param name="trace">Whether to emit trace messages</param>
        /// <typeparam name="E">The event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static FsmObserver<E,S> observer<E,S>(Fsm<E,S> fsm, FsmTrace? tracing = null)
            => new FsmObserver<E,S>(fsm, tracing);

        /// <summary>
        /// Runs a machine
        /// </summary>
        /// <param name="context">The machine context</param>
        /// <param name="machine">The specified machine</param>
        /// <typeparam name="E">The event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        public static Task<Option<FsmStats>> run<E,S>(Fsm<E,S> machine, IPolySource random)
            => Task.Factory.StartNew(() => RunMachine(machine, random));

        static Option<FsmStats> RunMachine<E,S>(Fsm<E,S> machine, IPolySource random)
        {
            try
            {
                var o = Fsm.observer(machine, FsmTrace.Completions | FsmTrace.Errors);
                var events = machine.Triggers.ToArray();
                var domain = Intervals.closed(0, events.Length);
                var eventstream = random.Stream(domain).Select(i => events[i]);
                machine.Start();
                while(!machine.Finished)
                    machine.Submit(eventstream.First());
                return machine.QueryStats();
            }
            catch(Exception e)
            {
                term.error(e);
                return default;
            }
        }

        /// <summary>
        /// Forms a transition function from a sequence of transition rules
        /// </summary>
        /// <param name="rules">The individual rules that will comprise the function</param>
        /// <typeparam name="E">The input event type</typeparam>
        /// <typeparam name="S">The state type</typeparam>
        [MethodImpl(Inline)]
        public static FsmTransitionFunc<E,S> transition<E,S>(params FsmTransitionRule<E,S>[] rules)
            => new FsmTransitionFunc<E,S>(rules);
    }
}