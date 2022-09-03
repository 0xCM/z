//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using api = Time;

    /// <summary>
    /// Represents a contiguous finite interval of time with calendar day resolution
    /// </summary>
    public readonly struct DateRange : ITimeInterval<Date>
    {
        /// <summary>
        /// The inclusive lower bound
        /// </summary>
        public Date Min {get;}

        /// <summary>
        /// The inclusive upper bound
        /// </summary>
        public Date Max {get;}

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> type
        /// </summary>
        /// <param name="min">The inclusive lower bound of the period</param>
        /// <param name="max">The inclusive upper bound of the period</param>
        [MethodImpl(Inline)]
        public DateRange(Date min, Date max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Converts a <see cref="DateRange"/> value to a <see cref="TimeInterval{DateTime}"/> value
        /// </summary>
        /// <param name="x">The source range</param>
        [MethodImpl(Inline)]
        public static implicit operator TimeInterval<DateTime>(DateRange x)
            => new TimeInterval<DateTime>(x.Min.ToDateTime().StartOfDay(), x.Max.ToDateTime().EndOfDay());

        /// <summary>
        /// Produces a <see cref="DateRange"/> that [begins | ends] on the [first | last] day of a given year
        /// </summary>
        /// <param name="Year">The year on which the range will be based</param>
        [MethodImpl(Inline)]
        public static DateRange FY(int Year)
            => new DateRange(new Date(Year, 1, 1), new Date(Year, 12, 1).EndOfMonth());

        /// <summary>
        /// Produces a <see cref="DateRange"/> that begins on the first day of the year
        /// and ends on the last day of the sixth month of that year
        /// </summary>
        /// <param name="Year">The year on which the range will be based</param>
        [MethodImpl(Inline)]
        public static DateRange Q1(int Year)
            => new DateRange(new Date(Year, 1, 1), new Date(Year, 3, 1).EndOfMonth());

        /// <summary>
        /// Produces a <see cref="DateRange"/> that begins on the first day of the fourth month
        /// and ends on the last day of the sixth month of a specified year
        /// </summary>
        /// <param name="Year">The year on which the range will be based</param>
        [MethodImpl(Inline)]
        public static DateRange Q2(int Year)
            => new DateRange(new Date(Year, 4, 1), new Date(Year, 6, 1).EndOfMonth());

        /// <summary>
        /// Produces a <see cref="DateRange"/> that begins on the first day of the seventh month
        /// and ends on the last day of the ninth month of a specified year
        /// </summary>
        /// <param name="Year">The year on which the range will be based</param>
        [MethodImpl(Inline)]
        public static DateRange Q3(int Year)
            => new DateRange(new Date(Year, 7, 1), new Date(Year, 9, 1).EndOfMonth());

        /// <summary>
        /// Produces a <see cref="DateRange"/> that begins on the first day of the tenth month
        /// and ends on the last day of the of a specified year
        /// </summary>
        /// <param name="Year">The year on which the range will be based</param>
        [MethodImpl(Inline)]
        public static DateRange Q4(int Year)
            => new DateRange(new Date(Year, 10, 1), new Date(Year, 12, 1).EndOfMonth());

        /// <summary>
        /// Produces a date range from a 2-tuple
        /// </summary>
        /// <param name="x">The source tuple</param>
        [MethodImpl(Inline)]
        public static implicit operator DateRange((Date Min, Date Max) x)
            => new DateRange(x.Min, x.Max);

        /// <summary>
        /// Determines whether the test value is within the range
        /// </summary>
        /// <param name="test">The date to test</param>
        [MethodImpl(Inline)]
        public bool In(Date test)
            => test >= Min && test <= Max;

        /// <summary>
        /// Determines whether the test value is outside the range
        /// </summary>
        /// <param name="test">The date to test</param>
        [MethodImpl(Inline)]
        public bool Out(Date test)
            => test < Min || test > Max;

        /// <summary>
        /// Produces a montnly <see cref="DateRange"/> sequence
        /// </summary>
        /// <param name="min">The inclusive minimum month</param>
        /// <param name="max">The inclusive maximum month</param>
        public static IEnumerable<DateRange> Months(Date min, Date max)
        {
            var start = new DateRange(min.FirstDayOfMonth, min.LastDayOfMonth);
            var end = new DateRange(max.FirstDayOfMonth, max.LastDayOfMonth);
            var next = start;
            if (next.Min == end.Min)
                yield return start;
            else
            {
                while (next.Min <= end.Max)
                {
                    yield return next;
                    next = next.AddMonth().Round();
                }
            }
        }

        DateRange Round()
            => new DateRange(Min.FirstDayOfMonth, Max.LastDayOfMonth);

        [MethodImpl(Inline)]
        public DateRange AddMonth()
            => new DateRange(Min.AddMonths(1), Max.AddMonths(1));

        /// <summary>
        /// The days that comprise the range
        /// </summary>
        public IEnumerable<Date> GetDates()
            => api.dates(this);

        /// <summary>
        /// The number of days in the range
        /// </summary>
        public int TotalDays
            => Max.DaysSince(Min);

        public Option<DateRange> Intersect(DateRange src)
        {
            var dates = GetDates().Intersect(src.GetDates()).ToList();
            return dates.Any()
                ? dates.Min().To(dates.Max())
                : Option.none<DateRange>();
        }

        /// <summary>
        /// Specifies whether the left and right boundaries are equal
        /// </summary>
        public bool IsDegenerate
        {
            [MethodImpl(Inline)]
            get => Min == Max;
        }

        public override string ToString()
            => $"[{Min.ToIsoString()},{Max.ToIsoString()}]";

        public string ToIntervalString()
            => ToString();

        public string ToDelimitedString(char delimiter = '.')
            => $"{Min.ToIsoString()}{delimiter}{Max.ToIsoString()}";
    }
}