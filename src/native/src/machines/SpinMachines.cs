//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record struct SpinStats(ulong Count, ulong Ticks);

    public class SpinMachines
    {
        public static void spin(IWfChannel channel, Func<SpinStats,bool> f)
        {
            var stats = new SpinStats();            
            var counter = 0u;
            var ticks = 0L;

            void Receiver(long t)
            {
                stats.Count++;
                stats.Ticks += (ulong)t;
                channel.Write(string.Format("{0:D4}:{1:D12}", stats.Count, stats.Ticks));
            }

            var spinner = new Spinner(TimeSpan.FromSeconds(1), Receiver);
            spinner.Spin();
        }
    }
}