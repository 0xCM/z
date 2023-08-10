//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public record struct SpinStats(ulong Count, ulong Ticks);

public class Spinners
{
    public static void spin(TimeSpan freq, Func<SpinStats,bool> f)
    {
        var spinner = new Spinner(freq);
        spinner.Spin(f);
    }
}
