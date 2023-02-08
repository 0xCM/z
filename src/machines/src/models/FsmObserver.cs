//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Receives notifications from an active machine
    /// </summary>
    /// <typeparam name="E">The input event type</typeparam>
    /// <typeparam name="S">The state type</typeparam>
    public class FsmObserver<E,S>
    {
        readonly Fsm<E,S> Machine;

        readonly FsmTrace Tracing;

        readonly int ReceiptEmitRate;

        int ReceiptCounter;

        int TransitionCount;

        int CompletionCount;

        ulong ReceiptCount;

        public FsmObserver(Fsm<E,S> machine, FsmTrace? tracing = null, int? receiptEmitRate = null)
        {
            Machine = machine;
            machine.Transitioned += OnTransition;
            machine.Oops += OnError;
            machine.InputReceipt += OnReceipt;
            machine.Completed += OnComplete;
            Tracing = tracing  ?? FsmTrace.All;
            ReceiptEmitRate = receiptEmitRate ?? (int)Pow2.T20;
            TransitionCount = 0;
            CompletionCount = 0;
        }

        string Id => Machine.Id;

        void Trace(IAppMsg msg)
        {
            term.print(msg);
        }

        /// <summary>
        /// Receives notification that a state machine has attained its endstate
        /// </summary>
        protected virtual void OnComplete(FsmStats stats, bool asPlanned)
        {
            CompletionCount++;
            if(Tracing.TraceCompletions())
            {
                Trace(Msg.Completed(Id, stats, asPlanned));
                CompletionCount = 0;
            }
        }

        /// <summary>
        /// Receives notification that a transition has occurred
        /// </summary>
        /// <param name="s0">The source state</param>
        /// <param name="s1">The target state</param>
        protected virtual void OnTransition(S s0, S s1)
        {
            TransitionCount++;
            if(Tracing.TraceTransitions())
                Trace(Msg.Transition(Id,s0,s1));
        }

        /// <summary>
        /// Receives notification that an event has ben submitted
        /// </summary>
        /// <param name="input">The input event</param>
        protected virtual void OnReceipt(E input)
        {
            ++ReceiptCount;

            if(ReceiptCounter == ReceiptEmitRate && Tracing.TraceEvents())
            {
                Trace(Msg.Receipt(Id, input, ReceiptCount));
                ReceiptCounter = 0;
            }

            ReceiptCounter++;
        }

        /// <summary>
        /// Receives notification that an error has occurred
        /// </summary>
        /// <param name="e">The trapped exception</param>
        protected virtual void OnError(Exception e)
        {
            if(Tracing.TraceErrors())
            {
                switch(e)
                {
                    case AppException ae:
                        Trace(ae.Message);
                        break;
                    default:
                        Trace(Msg.Error(Id, e));
                    break;
                }
            }
        }
    }
}