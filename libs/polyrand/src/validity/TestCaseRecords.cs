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

        // public static void render(in TestCaseRecord src, ITextBuffer dst)
        // {
        //     dst.AppendPadded(src.CaseName, CasePad, Delimiter);
        //     dst.AppendPadded(src.Passed, PassedPad, Delimiter);
        //     dst.AppendPadded(src.Duration, DurationPad, Delimiter);
        //     dst.AppendPadded(src.Started, StartedPad, Delimiter);
        //     dst.AppendPadded(src.Finished, FinishedPad, Delimiter);
        //     dst.AppendPadded(src.Message, MessagePad, Delimiter);
        // }

        public static string format(in TestCaseRecord src)
            => Tables.formatFx<TestCaseRecord>()(src);

        // {
        //     var dst = text.buffer();
        //     render(src, dst);
        //     return dst.Emit();
        // }
    }
}