//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Time;

    partial class XTend
    {
        /// <summary>
        /// Renders a string in a more rational manner than the default behavior
        /// </summary>
        /// <param name="t">The instant to render</param>
        /// <param name="accuracy">The accuracy with which to render the instant</param>
        public static string ToLexicalString(this DateTime t, TimeResolution accuracy = TimeResolution.Ms)
            => api.lexical(t, accuracy);

        public static IEnumerable<DateRange> Partition(this DateRange Period, int MaxLen)
            => api.partition(Period, MaxLen);

        /// <summary>
        /// Creates an integer of the form YYYYMMDD corresponding to a supplied date
        /// </summary>
        /// <param name="d">The date whose integer representation will be determined</param>
        public static int ToDateKey(this DateTime d)
        {
            if (d.Date > new DateTime(2050, 1, 1))
                return 99991231;
            else if (d.Date < new DateTime(2000, 1, 1))
                return 0;
            else
                return Int32.Parse(d.ToString("yyyyMMdd"));
        }

        /// <summary>
        /// Creates an integer of the form YYYYMMDD corresponding to a supplied date if the date
        /// is not null and returns 0 otherwise
        /// </summary>
        /// <param name="d">The date whose integer representation will be determined</param>
        public static int ToDateKey(this DateTime? d)
            => d != null ? d.Value.ToDateKey() : 0;

        public static int ToDateKey(this Date d)
        {
            if (d > new Date(2050, 1, 1))
                return 99991231;
            else if (d < new Date(2000, 1, 1))
                return 0;
            else
                return Int32.Parse(d.ToString("yyyyMMdd"));
        }

        public static int ToDateKey(this Date? d)
            => d != null ? d.Value.ToDateKey() : 0;

        /// <summary>
        /// Represents a date value as an array of integers
        /// </summary>
        /// <param name="x">The date to convert to an array</param>
        [MethodImpl(Inline)]
        public static int[] GetItemArray(this Date x)
            => sys.array(x.Year, x.Month, x.Day);

        /// <summary>
        /// Returns the instant that is one day less than the specified instant
        /// </summary>
        /// <param name="x">The reference data</param>
        [MethodImpl(Inline)]
        public static DateTime Yesterday(this DateTime x)
            => x.AddDays(-1);

        /// <summary>
        /// Returns the instant that is one day less than the specified instant
        /// </summary>
        /// <param name="x">The reference data</param>
        [MethodImpl(Inline)]
        public static DateTime LastMonth(this DateTime x)
            => x.AddMonths(-1);

        /// <summary>
        /// Returns the instant that is one day less than the specified instant
        /// </summary>
        /// <param name="x">The reference data</param>
        [MethodImpl(Inline)]
        public static DateTime NextMonth(this DateTime x)
            => x.AddMonths(1);

        /// <summary>
        /// The last day of the current year
        /// </summary>
        /// <param name="x">The reference data</param>
        [MethodImpl(Inline)]
        public static Date EndOfYear(this Date x)
            => new Date(x.Year, 12, 31);

        /// <summary>
        /// Returns the instant that is one day less than the specified instant
        /// </summary>
        /// <param name="x">The reference data</param>
        [MethodImpl(Inline)]
        public static Date Yesterday(this Date x)
            => x.AddDays(-1);

        /// <summary>
        /// Returns the instant that is one day more than the specified instant
        /// </summary>
        /// <param name="x">The reference data</param>
        [MethodImpl(Inline)]
        public static DateTime Tomorrow(this DateTime x)
            => x.AddDays(1);

        /// <summary>
        /// Returns the instant that is one day more than the specified instant
        /// </summary>
        /// <param name="x">The reference data</param>
        [MethodImpl(Inline)]
        public static Date Tomorrow(this Date x)
            => x.AddDays(1);

        [MethodImpl(Inline)]
        public static Date FirstDayOfNextMonth(this Date x)
            => x.LastDayOfMonth.AddDays(1);

        [MethodImpl(Inline)]
        public static Date LastDayOfPriorMonth(this Date x)
            => x.FirstDayOfMonth.AddDays(-1);

        /// <summary>
        /// Gets the time at which the day ends
        /// </summary>
        /// <param name="d">The instant in time</param>
        [MethodImpl(Inline)]
        public static DateTime EndOfDay(this DateTime d)
            => new DateTime(d.Year, d.Month, d.Day, 23, 59, 59, 999);

        /// <summary>
        /// Gets the time at which the day begins
        /// </summary>
        /// <param name="d">The instant in time</param>
        [MethodImpl(Inline)]
        public static DateTime StartOfDay(this DateTime d)
            => d.Date;

        /// <summary>
        /// Creates a contiguous range of dates within a supplied range
        /// </summary>
        /// <param name="min">The first date in the range</param>
        /// <param name="max">The last date in the range</param>
        public static IReadOnlyList<DateTime> ContiguousDatesTo(this DateTime min, DateTime max)
        {
            var dates = new List<DateTime>();
            var currentDate = new DateTime(min.Year, min.Month, min.Day, 0, 0, 0, DateTimeKind.Local);
            while (currentDate <= max)
            {
                dates.Add(currentDate);
                currentDate = currentDate.AddDays(1.0);
            }
            return dates;
        }

        /// <summary>
        /// Creates a contiguous range of dates within a supplied range
        /// </summary>
        /// <param name="min">The first date in the range</param>
        /// <param name="max">The last date in the range</param>
        public static IReadOnlyList<Date> ContiguousDatesTo(this Date min, Date max)
        {
            var dates = new List<Date>();
            var currentDate = new Date(min.Year, min.Month, min.Day);
            while (currentDate <= max)
            {
                dates.Add(currentDate);
                currentDate = currentDate.AddDays(1);
            }
            return dates;
        }

        /// <summary>
        /// Determines whether the <see cref="DateTime"/> values occur on the same day
        /// </summary>
        /// <param name="d">One subject</param>
        /// <param name="other">The other subject</param>
        [MethodImpl(Inline)]
        public static bool IsSameDay(this DateTime d, DateTime other)
            => d.Date == other.Date;

        /// <summary>
        /// Returns the number of seconds elapsed since midnight
        /// </summary>
        /// <param name="d">The subject</param>
        [MethodImpl(Inline)]
        public static uint ToTimeKey(this DateTime d)
            => (uint)(d - d.Date).TotalSeconds;

        /// <summary>
        /// Returns the number of seconds elapsed since midnight if date is not null, 0 otherwise
        /// </summary>
        /// <param name="d">The subject</param>
        [MethodImpl(Inline)]
        public static uint ToTimeKey(this DateTime? d)
            => d != null ? d.Value.ToTimeKey() : 0;

        /// <summary>
        /// Returns the <see cref="Date"/> part of the supplied <see cref="DateTime"/>
        /// </summary>
        /// <param name="src">The subject</param>
        [MethodImpl(Inline)]
        public static Date ToDate(this DateTime src)
            => api.date(src);

        /// <summary>
        /// Renders a <see cref="DateTime"/> to the form YYYY-MM-DD
        /// </summary>
        /// <param name="t"></param>
        public static string ToLexicalDateString(this DateTime t)
            => t.ToLexicalString(TimeResolution.Date);
    }
}