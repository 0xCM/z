//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures an evaluation outcome
    /// </summary>
    public readonly struct ApiEvalResult<T>
    {
        public TimedEval Outcome {get;}

        public T Transition {get;}

        [MethodImpl(Inline)]
        public ApiEvalResult(TimedEval outcome, T transition)
        {
            Transition = transition;
            Outcome = outcome;
        }

        [MethodImpl(Inline)]
        public static implicit operator TimedEval(ApiEvalResult<T> src)
            => src.Outcome;

        [MethodImpl(Inline)]
        public static implicit operator ApiEvalResult<T>((TimedEval outcome, T transition) src)
            => new ApiEvalResult<T>(src.outcome, src.transition);
    }
}