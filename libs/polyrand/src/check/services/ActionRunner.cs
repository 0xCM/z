//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class DynamicActions : Service<DynamicActions>
    {
        int seq;

        [MethodImpl(Inline)]
        public void Invoke(in DynamicAction action)
            => action.Invoke();

        public void Run(in DynamicAction fx)
        {
            var flow = Running(fx.Id);
            try
            {
                fx.Invoke();
            }
            catch(Exception e)
            {
                Error(GetType(), e);
            }
        }

        public TimedEval Measure(in DynamicAction fx)
        {
            var clock = Time.counter(true);
            try
            {
                fx.Invoke();
                return TimedEval.result(seq, fx.Id, clock, true);
            }
            catch(Exception e)
            {
                return TimedEval.result(seq, fx.Id, clock, e);
            }
        }
    }
}