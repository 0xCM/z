//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static TestCaseRecords;

    partial class TestApp<A>
    {
        const string FieldSep = " | ";

        static string DurationPlaceholder
            => string.Empty.PadRight((int)DurationPad);

        static string FormatTs(DateTime ts)
            => ts.ToLexicalString().PadRight((int)FinishedPad);

        static string Format(TimeSpan elapsed)
            => $"{elapsed.TotalMilliseconds} ms".PadRight((int)DurationPad);

        static string FormatName(string testName)
            => $"{testName}".PadRight((int)CasePad);

        static string FormatStatus(string status)
            => status.PadRight((int)PassedPad);

        static string CaseName(IExplicitTest unit)
        {
            var owner = ApiIdentityKinds.owner(unit.GetType());
            var hostname = unit.GetType().Name;
            var opname = "explicit";
            return $"{owner}/{hostname}/{opname}";
        }

        static AppMsg PreCase(string testName, DateTime start)
        {
            var fields = text.join(FieldSep,
                FormatName(testName),
                FormatStatus("executing"),
                DurationPlaceholder,
                FormatTs(start)
                );

            return AppMsg.colorize(fields, FlairKind.Status);
        }

        static AppMsg PostCase(string testName, TimeSpan elapsed, DateTime start, DateTime end)
        {
            var msg = text.join(FieldSep,
                FormatName(testName),
                FormatStatus("executed"),
                Format(elapsed),
                FormatTs(start),
                FormatTs(end),
                Format(end - start)
                );

            return AppMsg.colorize(msg, FlairKind.Status);
        }

        static AppMsg PostUnit(_ApiHostUri host, TimeSpan elapsed, DateTime start, DateTime end)
        {
            var msg = text.join(FieldSep,
                FormatName(host.Format()),
                FormatStatus("completed"),
                Format(elapsed),
                FormatTs(start),
                FormatTs(end),
                Format(end - start)
                );

            return AppMsg.colorize(msg, FlairKind.Status);
        }
    }
}