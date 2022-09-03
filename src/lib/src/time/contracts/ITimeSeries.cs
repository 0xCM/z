//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITimeSeries
    {
        long Id {get;}
    }

    public interface ITimeSeries<T> : ITimeSeries
        where T : unmanaged
    {
        SeriesTerm<T> Observed {get;}

        Interval<T> Domain {get;}
    }
}