//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    public readonly struct SeriesEvolution<T>
        where T : unmanaged
    {
        public readonly ulong[] Seed;

        public readonly Interval<T> Domain;

        public readonly SeriesTerm<T> FirstTerm;

        public readonly SeriesTerm<T> FinalTerm;

        public readonly Duration Time;

        [MethodImpl(Inline)]
        public SeriesEvolution(ulong[] seed, Interval<T> domain, SeriesTerm<T> first, SeriesTerm<T> final, Duration time)
        {
            Seed = seed;
            Domain = domain;
            FirstTerm = first;
            FinalTerm = final;
            Time = time;
        }
    }
}