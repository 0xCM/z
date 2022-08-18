//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SeriesTerm<T>
        where T : unmanaged
    {
        public long Index {get;}

        public T Observed {get;}

        [MethodImpl(Inline)]
        public SeriesTerm(long index, T observation)
        {
            Index = index;
            Observed = observation;
        }

        public string Format()
            => $"({Index}, {Observed})";

        public override string ToString()
            => Format();
    }
}