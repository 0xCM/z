//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines common messages that are issued during setup/execution
    /// </summary>
    partial struct Msg
    {
        public static AppMsg Transition<S>(string machine, S s1, S s2)
            => AppMsg.colorize($"{machine} Transitioned {s1} -> {s2}", FlairKind.Ran);

        public static AppMsg Completed(string machine, FsmStats stats, bool asPlanned)
            => AppMsg.colorize($"{machine} executed for {stats.Runtime.Ms} ms and completed"
            + (asPlanned ? $" as planned after receiving {stats.ReceiptCount} events and experiencing {stats.TransitionCount} transitions" : " abnormally"),
                FlairKind.Status);

        public static AppMsg Receipt<E>(string machine, E input, ulong receipts)
            => AppMsg.babble($"{machine} received event {input.ToString().PadLeft(6)} | Total Receipts: {receipts}");

        public static AppMsg Error(string machine, Exception error)
            => AppMsg.error($"{machine} encountered an error: {error}");

        public static AppMsg ReceiptAfterFinish(string machine)
            => AppMsg.warn($"{machine} continuing to receive input after finished has been signaled");

        public static AppMsg ReceiptBeforeStart(string machine)
            => AppMsg.warn($"{machine} received input before start");
    }
}