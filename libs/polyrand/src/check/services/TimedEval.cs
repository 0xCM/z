//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using R = TimedEval;

    /// <summary>
    /// Describes the outcome of a test case
    /// </summary>
    [ApiHost]
    public struct TimedEval : IRecord<TimedEval>
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static R result<T>(int seq, in T id, Duration duration, Exception error)
            => new R(seq, $"{id}", false, duration, error.ToString());

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static R result<T>(int seq, in T id, Duration duration, bool succeeded)
            => new R(seq, $"{id}", succeeded, duration, $"{succeeded}");

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static R result<T>(int seq, in T id, Duration duration, object message, bool succeeded)
            => new TimedEval(seq,$"{id}", succeeded, duration, message?.ToString());

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static R result<T>(uint seq, in T id, Duration duration, Exception error)
            => new R((int)seq, $"{id}", false, duration, error.ToString());

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static R result<T>(uint seq, in T id, Duration duration, bool succeeded)
            => new R((int)seq, $"{id}", succeeded, duration, "Ok");

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static R result<T>(uint seq, in T id, Duration duration, object message, bool succeeded)
            => new R((int)seq,$"{id}",  succeeded, duration, message?.ToString());

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static R result<T>(int seq, in T id, Duration duration, AppMsg message)
            => new R(seq,$"{id}", message.Kind != LogLevel.Error, duration, message.Format());


        public int Sequence;

        public string CaseName;

        public EvalStatusKind Status;

        public Duration Duration;

        public DateTime Timestamp;

        public string Message;

        public TimedEval(int seq, string name, bool succeeded, Duration duration, string message)
        {
            Sequence = seq;
            CaseName = name;
            Status = succeeded ? EvalStatusKind.Passed : EvalStatusKind.Failed;
            Duration = duration;
            Timestamp = DateTime.Now;
            Message = message ?? "Empty result!";
        }
    }
}