//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct TestCaseRecords
    {
        const string Delimiter = "| ";

        const int WidthOffset = 16;

        public const byte CasePad = (byte)TestCaseField.CaseName;

        public const byte StartedPad = (byte)TestCaseField.Started;

        public const byte FinishedPad = (byte)TestCaseField.Finished;

        public const byte DurationPad = (byte)TestCaseField.Duration;

        public const byte PassedPad = (byte)TestCaseField.Passed;

        public const byte MessagePad = (byte)TestCaseField.Message;

        public static string format(in TestCaseRecord src)
            => Tables.formatFx<TestCaseRecord>()(src);

    }
}