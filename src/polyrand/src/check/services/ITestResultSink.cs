//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ITestResultSink : ISink<TestCaseRecord>
    {
        void ReportCaseResult(string casename, bool succeeded, TimeSpan duration)
            => Deposit(TestCaseRecord.define(casename, succeeded, duration));

        void ISink<TestCaseRecord>.Deposit(TestCaseRecord src)
            => term.print(TestCaseRecords.format(src));
    }
}