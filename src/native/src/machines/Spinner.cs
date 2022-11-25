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

        public Spinner(TimeSpan frequency, Action<long> receiver = null)
        {
            Continue = true;
            Cycles = 0;
            Cycles= new();
            Receive = receiver ?? Looped;
            Frequency = frequency;
            Time = Timestamp.Zero;
        }

        void Looped(long cycles) {}

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

        public void Spin(Func<SpinStats,bool> f)
        {
            var stats = new SpinStats();
            Time = timestamp();
            while(f(stats))
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
                stats.Count++;
                stats.Ticks += (delta.TickCount);
            }            
        }
    }
}