//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public readonly struct FsmFx
    {
        /// <summary>
        /// Delegate for event that fires when an input event has been received
        /// </summary>
        /// <param name="input">The input event</param>
        /// <typeparam name="E">The input event type</typeparam>
        public delegate void InputReceipt<E>(E input);

        /// <summary>
        /// Delegate for event that fires when a state transition occurs
        /// </summary>
        /// <param name="source">The source/antecedent state</param>
        /// <param name="target">The target state</param>
        /// <typeparam name="S">The state type</typeparam>
        public delegate void Transitioned<S>(S source, S target);

        /// <summary>
        /// Delegate for event that fires when a machine attains endstate
        /// </summary>
        /// <param name="endstate"></param>
        /// <param name="asPlanned"></param>
        /// <typeparam name="S"></typeparam>
        public delegate void Completed(FsmStats stats, bool asPlanned);

        /// <summary>
        /// Delegate for error event
        /// </summary>
        /// <param name="error">The trapped exception</param>
        public delegate void MachineError(Exception error);

        /// <summary>
        /// Delegate that fires upon state entry
        /// </summary>
        /// <param name="entry"></param>
        /// <typeparam name="S">The state type</typeparam>
        /// <typeparam name="A">The action type</typeparam>
        public delegate void StateEntry<S,A>(S entry, A action);

        /// <summary>
        /// Delegate that fires upon state exit
        /// </summary>
        /// <param name="entry"></param>
        /// <typeparam name="S">The state type</typeparam>
        /// <typeparam name="A">The action type</typeparam>
        public delegate void StateExit<S,A>(S exit, A action);
    }
}