//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines inclusive lower and upper bounds for a comparable set of values
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    public readonly struct TimeInterval<T> : ITimeInterval<T>
        where T : IComparable
    {
        /// <summary>
        /// The minimum value in the range
        /// </summary>
        public T Min {get;}

        /// <summary>
        /// The maximum value in the range
        /// </summary>
        public T Max {get;}

        [MethodImpl(Inline)]
        public TimeInterval(T min, T max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Tests whether a value is in the range
        /// </summary>
        /// <param name="candidate">The value to test</param>
        public bool In(T candidate)
            => candidate.CompareTo(Min) >= 0  && candidate.CompareTo(Max) <= 0;

        public override string ToString()
            => $"[{Min}, {Max}]";
    }
}