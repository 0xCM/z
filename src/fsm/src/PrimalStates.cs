//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using M = PrimalStates.PrimalFsmSpec1;

    using static PrimalStates.PrimalFsmSpec1.Event;
    using static PrimalStates.PrimalFsmSpec1.State;

    using System.Linq;

    [ApiHost]
    public partial class PrimalStates
    {
        const NumericKind Closure = UInt16k;

        public static void example2()
        {
            var machineCount = Pow2.T04;
            var spec = specify<ushort>("Fsm2",750,750,100,120,Pow2.T15);
            var stats = run(Rng.pcg64(), spec, machineCount);
            var counts = stats.Select(x => x.ReceiptCount).ToArray().AsSpan().ReadOnly();
            var count = gcalc.sum(counts);
            term.inform($"A total of {count} events were processed");
        }

        /// <summary>
        /// Executes one or more primal state machines
        /// </summary>
        /// <param name="spec">The FSM spec that determines machine characteristics </param>
        /// <param name="machineCount">The number of machines to execute</param>
        /// <param name="sequential">Specifies whether the machines will be executed sequentially</param>
        /// <typeparam name="T">The primal type</typeparam>
        [Op, Closures(Closure)]
        public static IEnumerable<FsmStats> run<T>(IPolySource random, PrimalFsmSpec<T> spec, int machineCount, bool sequential = false)
            where T : unmanaged
        {
            var seeds = Entropy.Values<ulong>(machineCount);
            var indices = gcalc.stream(0xFFFFul, 0xFFFFFFFFul).Where(x => x % 2 != 0).Take(machineCount).ToArray();
            if(sequential)
                return PrimalStates.sequential(random,spec, seeds, indices).Array();
            else
                return concurrent(random, spec,seeds, indices).Array();
        }

        /// <summary>
        /// Executes the specified machines sequentially
        /// </summary>
        /// <param name="spec">The machine definition</param>
        /// <param name="seeds">The rng seeds that determine initial states of the randomizers</param>
        /// <param name="indices">The rng stream position indices</param>
        /// <typeparam name="T">The primal FSM type</typeparam>
        [Op, Closures(Closure)]
        static IEnumerable<FsmStats> sequential<T>(IPolySource random, PrimalFsmSpec<T> spec, Span<ulong> seeds, Span<ulong> indices)
            where T : unmanaged
        {
            var stats = new ConcurrentBag<FsmStats>();
            for(var i=0; i<seeds.Length; i++)
            {
               var machine = PrimalStates.machine(spec, seeds[i], indices[i]);
               var result = Fsm.run(machine, random).Result;
               result.OnSome(s => stats.Add(s));
            }
            return stats;
        }

        /// <summary>
        /// Executes the specified machines concurrently
        /// </summary>
        /// <param name="spec">The machine definition</param>
        /// <param name="seeds">The rng seeds that determine initial states of the randomizers</param>
        /// <param name="indices">The rng stream position indices</param>
        /// <typeparam name="T">The primal FSM type</typeparam>
        [Op, Closures(Closure)]
        static IEnumerable<FsmStats> concurrent<T>(IPolySource random, PrimalFsmSpec<T> spec, Span<ulong> seeds, Span<ulong> indices)
            where T : unmanaged
        {
            var stats = new ConcurrentBag<FsmStats>();
            var tasks = new Task[seeds.Length];
            for(var i=0; i< tasks.Length; i++)
            {
                var machine = PrimalStates.machine(spec, seeds[i],indices[i]);
                tasks[i] = Fsm.run(machine,random).ContinueWith(t => t.Result.OnSome(s => stats.Add(s)));
            }

            Task.WaitAll(tasks);
            return stats;
        }

        /// <summary>
        /// Defines a primal state machine
        /// </summary>
        /// <param name="classifier">An identifier that defines a membership class that is propagaged to all machines predicated on the specification</param>
        /// <param name="states">The number of states the machine will support</param>
        /// <param name="events">The number of events the machine will recognize</param>
        /// <param name="minSamples">The minimum number of events that will be sampled for each state</param>
        /// <param name="maxSamples">The maximum number of events that will be sampled for each state</param>
        /// <param name="maxReceipts">The maximum number of events that the machine will accept</param>
        /// <typeparam name="T">A scalar type of sufficient size to accommodate specified characteristics</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static PrimalFsmSpec<T> specify<T>(string classifier, T states, T events, T minSamples, T maxSamples, ulong maxReceipts)
            where T : unmanaged
                => new PrimalFsmSpec<T>(classifier, states, events, minSamples, maxSamples, maxReceipts);

        // [Op, Closures(Closure)]
        // static FsmTransitionFunc<T,T> transition<T>(IPolyrandProvider context, PrimalFsmSpec<T> spec)
        //     where T : unmanaged
        // {
        //     var sources = gcalc.stream<T>(spec.StateCount).ToArray();
        //     var random = context.Random;
        //     var rules = new List<FsmTransitionRule<T,T>>();
        //     foreach(var source in sources)
        //     {
        //         var evss = random.Next<T>(spec.MinEventSamples, spec.MaxEventSamples);
        //         var targets = from t in random.Distinct(spec.StateCount, evss) where gmath.neq(t,source) select t;
        //         var events = random.Distinct(spec.EventCount, evss);
        //         rules.AddRange(events.Zip(targets).Select(x => Fsm.transition(x.First, source, x.Second)));
        //     }
        //     return rules.ToFunction();
        // }


        [Op, Closures(Closure)]
        static FsmTransitionFunc<T,T> transition<T>(IPolySource src, PrimalFsmSpec<T> spec)
            where T : unmanaged
        {
            var sources = gcalc.stream<T>(spec.StateCount).ToArray();
            var rules = new List<FsmTransitionRule<T,T>>();
            foreach(var source in sources)
            {
                var evss = src.Next<T>(spec.MinEventSamples, spec.MaxEventSamples);
                var targets = from t in src.Distinct(spec.StateCount, evss) where gmath.neq(t,source) select t;
                var events = src.Distinct(spec.EventCount, evss);
                rules.AddRange(events.Zip(targets).Select(x => Fsm.transition(x.First, source, x.Second)));
            }
            return rules.ToFunction();
        }

        static int MachineCounter = 0;

        [MethodImpl(Inline), Op, Closures(Closure)]
        static string identify<T>(PrimalFsmSpec<T> spec)
            where T : unmanaged
                => $"{spec.Classifier}-{Interlocked.Increment(ref MachineCounter)}";

        /// <summary>
        /// Creates a primal FSM according to a supplied spec with a specified random seed and stream index
        /// </summary>
        /// <param name="spec">The FSM definition</param>
        /// <param name="seed">The rng seed</param>
        /// <param name="index">The rng stream index</param>
        /// <typeparam name="T">The primal fsm type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Fsm<T,T> machine<T>(IWfRuntime wf, IPolyrand random, PrimalFsmSpec<T> spec, ulong seed, ulong index)
            where T : unmanaged
                => PrimalStates.machine(wf, random, spec);

        /// <summary>
        /// Creates a primal FSM according to a supplied spec with a specified random seed and stream index
        /// </summary>
        /// <param name="spec">The FSM definition</param>
        /// <typeparam name="T">The primal fsm type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Fsm<T,T> machine<T>(IWfRuntime wf, IPolyrand random, PrimalFsmSpec<T> spec)
            where T : unmanaged
                => Fsm.machine(identify(spec), spec.StartState, spec.EndState, transition(random, spec), spec.ReceiptLimit);

        /// <summary>
        /// Creates a primal FSM according to a supplied spec with a specified random seed and stream index
        /// </summary>
        /// <param name="spec">The FSM definition</param>
        /// <param name="seed">The rng seed</param>
        /// <param name="index">The rng stream index</param>
        /// <typeparam name="T">The primal fsm type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Fsm<T,T> machine<T>(PrimalFsmSpec<T> spec, ulong seed, ulong index)
            where T : unmanaged
        {
            var random = Rng.pcg64(seed, index);
            return Fsm.machine(identify(spec), Fsm.context(spec.ReceiptLimit), spec.StartState, spec.EndState, transition(random, spec));
        }

        [MethodImpl(Inline), Op]
        public static PrimalFsmSpec<M.State,M.Event,M.Result> modelG(M.State[] states, M.Event[] events, M.Result[] results)
            => create(states, events, results);

        [Op]
        public static PrimalFsmSpec1 model(M.Event[] events, M.State[] states, M.Result[] results)
            => new PrimalFsmSpec1(events, states, results);

        [MethodImpl(Inline)]
        public static PrimalFsmSpec<S,E,R> create<S,E,R>(S[] states, E[] events, R[] results)
            where S : unmanaged
            where E : unmanaged
            where R : unmanaged
                => new PrimalFsmSpec<S,E,R>(states, events, results);

        public static PrimalFsmSpec<M.State,M.Event,M.Result> model()
            => modelG(Enums.literals<M.State>(), Enums.literals<M.Event>(), Enums.literals<M.Result>());

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
                Rules = sys.array(Fsm.rule(E1,S0,S1), Fsm.rule(E1, S1, S2), Fsm.rule(E1, S2, S3), Fsm.rule(E1,S3, S4), Fsm.rule(E1,S4,S5));
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
}