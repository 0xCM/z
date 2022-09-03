//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using F = TestCaseRecords;
    /// <summary>
    /// Describes the outcome of a test case
    /// </summary>
    [Record(TableId)]
    public struct TestCaseRecord : IRecord<TestCaseRecord>, ITextual
    {
        const string TableId = "test.results";

        //public const byte FieldCount = 6;

        [Render(F.CasePad)]
        public string CaseName;

        [Render(F.PassedPad)]
        public bool Passed;

        [Render(F.StartedPad)]
        public Timestamp Started;

        [Render(F.FinishedPad)]
        public Timestamp Finished;

        [Render(F.DurationPad)]
        public Duration Duration;

        [Render(F.MessagePad)]
        public string Message;

        // public static FormatCell<TestCaseRecord> FormatFunction
        //     => TestCaseRecords.format;

        public static TestCaseRecord define(string name, bool succeeded, Duration duration)
            => new TestCaseRecord(name, succeeded, duration, EmptyString);

        public static TestCaseRecord define(string name, bool succeeded, Timestamp started, Timestamp finished, Duration duration, string msg = EmptyString)
            => new TestCaseRecord(name, succeeded, started, finished, duration, msg);

        internal TestCaseRecord(string name, bool succeeded, Timestamp started, Timestamp finished, Duration duration, string msg)
        {
            CaseName = name ?? "<missing_name>";
            Passed = succeeded;
            Duration = duration;
            Started = started;
            Message = msg;
            Finished = finished;
        }

        internal TestCaseRecord(string name, bool succeeded, Duration duration, string msg)
        {
            CaseName = name ?? "<missing_name>";
            Passed = succeeded;
            Duration = duration;
            Started = now();
            Message = msg;
            Finished = now();
        }

        public string Format()
            => TestCaseRecords.format(this);
    }
}