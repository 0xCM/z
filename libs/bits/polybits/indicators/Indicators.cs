//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Indicators
    {
        [MethodImpl(Inline)]
        public static Indicator1u enabled(bit src)
            => new Indicator1u(new Indicator<bit>(src, src));

        [MethodImpl(Inline)]
        public static Indicator<T> enabled<T>(T src)
            where T : unmanaged
                => new Indicator<T>(src);

        [MethodImpl(Inline)]
        public static Indicator<T> disabled<T>()
            where T : unmanaged
                => Indicator<T>.Empty;

        public readonly record struct Indicator1u : IIndicator<Indicator1u,bit>
        {
            readonly Indicator<bit> Data;

            [MethodImpl(Inline)]
            public Indicator1u(Indicator<bit> src)
            {
                Data = src;
            }

            public bit Value
            {
                [MethodImpl(Inline)]
                get => Data.Value;
            }

            public bit Enabled
            {
                [MethodImpl(Inline)]
                get => Data.Enabled;
            }

            [MethodImpl(Inline)]
            public int CompareTo(Indicator1u src)
                => Data.CompareTo(src.Data);

            public string Format()
                => Data.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Indicator1u(Indicator<bit> src)
                => new Indicator1u(src);

            [MethodImpl(Inline)]
            public static implicit operator Indicator<bit>(Indicator1u src)
                => new Indicator<bit>(src.Data.Value, src.Enabled);
        }
    }
}