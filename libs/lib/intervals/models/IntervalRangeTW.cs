//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct IntervalRange<T,W>
        where W : unmanaged, IEquatable<W>
    {
        public readonly T Name;

        public readonly ClosedInterval<W> Width;

        [MethodImpl(Inline)]
        public IntervalRange(T name, ClosedInterval<W> width)
        {
            Name = name;
            Width = width;
        }

        /// <summary>
        /// The minimum content width
        /// </summary>
        public W Min
        {
            [MethodImpl(Inline)]
            get => Width.Min;
        }

        /// <summary>
        /// The maximum content width
        /// </summary>
        public W Max
        {
            [MethodImpl(Inline)]
            get => Width.Max;
        }
    }
}