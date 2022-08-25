//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    partial class TestApp<A>
    {
        public void EmitLogs()
        {
            var basename = AppName;
            var results = SortResults();

            FilePath CaseLogSummary()
                => AppDb.Logs("test").Path(FS.file(AppName, FS.Csv));

            if(results.Any())
            {
                var timing = results.Sum(x => x.Duration.TimeSpan.TotalSeconds);
                var dst = CaseLogSummary();
                Wf.Status($"Emitting case log to {dst.ToUri()} with execution time of {timing} seconds");
                EmitTestCaseLog(dst, results);
            }
        }

        void EmitTestCaseLog(FilePath dst, TestCaseRecord[] records)
        {
            if(records.Length != 0)
                Tables.emit(@readonly(records), dst);
        }
    }
}