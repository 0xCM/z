//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
   /// <summary>
   /// Defines a state machine that supports state entry actions
   /// </summary>
   /// <typeparam name="E">The incoming event type</typeparam>
   /// <typeparam name="S">The state type</typeparam>
   /// <typeparam name="A">The action type</typeparam>
    public class Fsm<E,S,A> : Fsm<E,S>
    {
        internal Fsm(string Id, IWfRuntime wf, S s0, S end,
                FsmTransitionFunc<E,S> Transition, FsmEntryFunc<S,A> entry, FsmExitFunc<S,A> exit, ulong? limit = null)
            : base(Id, wf, s0, end, Transition, limit)
        {
            EntryFunc = entry;
            ExitFunc = exit;
        }

        /// <summary>
        /// The function to evaluate upon state entry to determine the associated action, if any
        /// </summary>
        readonly FsmEntryFunc<S,A> EntryFunc;

        /// <summary>
        /// The function to evaluate upon state exit to determine the associated action, if any
        /// </summary>
        readonly FsmExitFunc<S,A> ExitFunc;

        /// <summary>
        /// The entry action
        /// </summary>
        public FsmFx.StateEntry<S,A> EntryAction;

        /// <summary>
        /// The exit action
        /// </summary>
        public FsmFx.StateExit<S,A> ExitAction;

        protected override void OnEntry(S s)
        {
            EntryFunc.Eval(s).OnSome(action => EntryAction?.Invoke(s, action));
        }

        protected override void OnExit(S s)
        {
            ExitFunc.Eval(s).OnSome(action => ExitAction?.Invoke(s,action));
        }
    }
}