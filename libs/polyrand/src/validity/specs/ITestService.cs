//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    /// <summary>
    /// Defines a test service which is, by definition, a contextual service of test context kind
    /// </summary>
    public interface ITestService : IContextual<ITestContext>, IPolyrandProvider, ICheckSettings, ITestCaseIdentity, IClocked
    {
        IPolyrand IPolyrandProvider.Random => Context.Random;

        void Error(Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Context.Deposit(AppMsg.error(e, caller,file,line));
    }
}