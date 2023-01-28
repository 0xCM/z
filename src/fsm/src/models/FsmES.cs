//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a state machine with minimal feature-set
    /// </summary>
    /// <typeparam name="E">The incoming event type</typeparam>
    /// <typeparam name="S">The state type</typeparam>
    public class Fsm<E,S>
    {
        /// <summary>
        /// Identifies the machine within the process
        /// </summary>
        public string Id {get;}

        /// <summary>
        /// Specifies the maximum number of events that will be accepted prior to forceful termination
        /// </summary>
        readonly ulong Limit;

        /// <summary>
        /// Records the time spent actively running
        /// </summary>
        Stopwatch Runtime {get;}

        /// <summary>
        /// The machine transition function
        /// </summary>
        IFsmFunc<E,S> Transition {get;}

        /// <summary>
        /// The number of events that have been received
        /// </summary>
        public ulong ReceiptCount {get; private set;}

        /// <summary>
        /// The number of state transitions that have occurred
        /// </summary>
        public uint TransitionCount {get; private set;}

        /// <summary>
        /// The endstate which implicitly signals processing completion
        /// </summary>
        S EndState {get;}

        /// <summary>
        /// The current state
        /// </summary>
        S CurrentState;

        /// <summary>
        /// An error that occurred, if any, prior to normal completion
        /// </summary>
        Option<Exception> Error;

        public IPolySource Random {get;}

        /// <summary>
        /// Fires when input is received
        /// </summary>
        public event FsmFx.InputReceipt<E> InputReceipt;

        /// <summary>
        /// Fires when a transition occurs from one state to a different state
        /// </summary>
        public event FsmFx.Transitioned<S> Transitioned;

        /// <summary>
        /// Fires when the machine has reached endstate
        /// </summary>
        public event FsmFx.Completed Completed;

        /// <summary>
        /// Fires when an error is trapped
        /// </summary>
        public event FsmFx.MachineError Oops;

        /// <summary>
        /// Initializes a state machine
        /// </summary>
        /// <param name="id">The state machine identifier</param>
        /// <param name="wf">The executing workflow</param>
        /// <param name="random"></param>
        /// <param name="ground"></param>
        /// <param name="end"></param>
        /// <param name="transition"></param>
        /// <param name="limit"></param>
        public Fsm(string id, S ground, S end, IFsmFunc<E,S> transition, ulong? limit = null)
        {
            Id = id;
            CurrentState = ground;
            Random = Rng.pcg64();
            EndState = end;
            Error = Option.none<Exception>();
            Transition = transition;
            ReceiptCount = 0;
            TransitionCount = 0;
            Limit = limit ?? ulong.MaxValue;
            Runtime = Time.stopwatch(false);
        }

        public Fsm(string id, IFsmContext context, S ground, S end, IFsmFunc<E,S> transition)
        {
            Id = id;
            CurrentState = ground;
            EndState = end;
            Random = Rng.pcg64();
            Error = Option.none<Exception>();
            Transition = transition;
            ReceiptCount = 0;
            TransitionCount = 0;
            Limit = context.ReceiptLimit ?? ulong.MaxValue;
            Runtime = Time.stopwatch(false);
        }

        /// <summary>
        /// Specifies the events that the machine can accept
        /// </summary>
        public IEnumerable<E> Triggers
            => Transition.Triggers;

        /// <summary>
        /// Indicates whether the machine has finished
        /// </summary>
        public bool Finished
            => CurrentState.Equals(EndState) || Error.IsSome();

        /// <summary>
        /// Records the time at which the machine was started
        /// </summary>
        public ulong? StartTime {get; private set;}

        /// <summary>
        /// Records the time at which the machine stopped
        /// </summary>
        public ulong? EndTime {get; private set;}

        /// <summary>
        /// Specifies whether the machine has started
        /// </summary>
        public bool Started
            => StartTime.HasValue;

        public FsmStats QueryStats()
            => new FsmStats
            {
                MachineId = Id,
                StartTime = StartTime,
                EndTime = EndTime,
                ReceiptCount = ReceiptCount,
                Runtime = Duration.init(Runtime.ElapsedTicks),
                TransitionCount = TransitionCount
            };

        /// <summary>
        /// Begins machine execution
        /// </summary>
        public void Start()
        {
            StartTime = Time.timestamp();
        }

        bool CanProcess()
        {
            if(Finished)
            {
                RaiseWarning(Msg.ReceiptAfterFinish(Id));
                return false;
            }

            if(!Started)
            {
                RaiseWarning(Msg.ReceiptBeforeStart(Id));
                return false;
            }

            if(ReceiptCount > Limit)
            {
                RaiseError(ReceiptLimitExceeded.Define(Id, Limit));
                return false;
            }

            return true;
        }

        /// <summary>
        /// Submits input to the machine
        /// </summary>
        /// <param name="input">The input data</param>
        public void Submit(E input)
        {
            Runtime.Start();

            try
            {
                if(CanProcess())
                {
                    OnReceipt(input);
                    var prior = CurrentState;
                    CurrentState = Transition.Eval(input, CurrentState).ValueOrElse(CurrentState);

                    if(!prior.Equals(CurrentState))
                        OnTransition(prior, CurrentState);

                    if(Finished)
                        OnComplete(true);
                }
            }
            catch(Exception e)
            {
                OnError(e);
            }

            Runtime.Stop();
        }

        void OnComplete(bool asPlanned)
        {
            EndTime = Time.timestamp();
            Runtime.Stop();
            Completed?.Invoke(QueryStats(), asPlanned);
        }

        void OnTransition(S s0, S s1)
        {
            Transitioned?.Invoke(s0, s1);
            OnExit(s0);
            OnEntry(s1);
            TransitionCount++;
        }

        /// <summary>
        /// Called upon state entry
        /// </summary>
        /// <param name="entry">The entry state</param>
        protected virtual void OnEntry(S entry){ }

        /// <summary>
        /// Called upon state exit
        /// </summary>
        /// <param name="exit">The exit state</param>
        protected virtual void OnExit(S exit) { }

        void RaiseWarning(AppMsg msg)
        {
            OnWarning(msg);
        }

        void RaiseError(AppException e)
        {
            OnError(e);
        }

        void OnReceipt(E input)
        {
            ReceiptCount++;
            Option.Try(() => InputReceipt?.Invoke(input));
        }

        void OnWarning(AppMsg msg)
        {

        }

        void OnError(Exception e)
        {
            Error = e;

            Option.Try(() => Oops?.Invoke(e));

            OnComplete(false);
        }
    }

    public class ReceiptLimitExceeded : AppException
    {
        public static ReceiptLimitExceeded Define(string machine, ulong limit)
            => new ReceiptLimitExceeded(machine, limit);

        public ReceiptLimitExceeded(string machine, ulong limit)
            : base(AppMsg.called($"{machine} Event receipt limit of {limit} was exeeded", LogLevel.Warning))
        {

        }
    }
}