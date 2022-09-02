//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Threading;

    using static sys;

    /// <summary>
    /// Extends the semantics of <see cref='SpinWait'/> to form a run loop
    /// </summary>
    public class Spinner
    {
        volatile bool Continue;

        readonly SpinWait Wait;

        long Cycles;

        Action<long> Receive;

        readonly Duration Frequency;

        Timestamp Time;

        public Spinner(TimeSpan frequency, Action<long> receiver)
        {
            Continue = true;
            Cycles = 0;
            Cycles= new();
            Receive = receiver;
            Frequency = frequency;
            Time = Timestamp.Zero;
        }

        public void Stop()
        {
            Continue = false;
        }

        public void Spin()
        {
            Time = timestamp();
            while(Continue)
            {
                var now = timestamp();
                var prior = Time;
                Duration delta = now - prior;
                if(delta > Frequency)
                {
                    var cycles = Cycles;
                    start(() => Receive(cycles));
                    Time = timestamp();
                }

                Wait.SpinOnce();
                Cycles++;
            }
        }
    }
}