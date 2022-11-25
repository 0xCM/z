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
            var counter = 0u;
            var ticks = 0L;
            void Receiver(long t)
            {
                counter++;
                ticks += t;
                channel.Write(string.Format("{0:D4}:{1:D12}", counter, ticks));
            }

            var spinner = new Spinner(TimeSpan.FromSeconds(1));
            spinner.Spin(f);
        }
    }
}