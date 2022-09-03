//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ITestContext :
        IMessageSink,
        IDisposable,
        IPolyrandProvider,
        ITestService,
        ITestQueue,
        IClocked,
        ICheckAction,
        ICheckSettings,
        ITestCaseIdentity,
        IClaimValidator
    {
        bool DiagnosticMode {get;}

    }

    public interface ITestContext<U> : ITestContext
        where U : ITestContext<U>
    {
        Type IClaimValidator.HostType
            => typeof(U);
    }
}