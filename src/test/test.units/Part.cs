//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Reflection;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Threading.Tasks;

global using static Z0.Root;

global using SQ = Z0.SymbolicQuery;
global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;


[assembly: PartId(PartId.TestUnits)]

namespace Z0.Parts
{
    public sealed class TestUnits : Part<TestUnits>
    {
        public static PartAssets Assets = new PartAssets();

        public sealed class PartAssets : Assets<PartAssets>
        {

        }
    }
}

namespace Z0
{
    [Free]
    public interface IExecutable
    {
        void Execute(params string[] args);
    }

    public interface IExplicitTest : IUnitTest, IExecutable
    {

    }

    public static class XSvc
    {
        class ServiceCache : AppServices<ServiceCache>
        {

            public IAppCmdSvc TestCmd(IWfRuntime wf)
                => Service<TestCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IAppCmdSvc TestCmd(this IWfRuntime wf)
            => Services.TestCmd(wf);
    }
}