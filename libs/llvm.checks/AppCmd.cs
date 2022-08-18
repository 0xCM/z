//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    unsafe class AppCmd : AppCmdService<AppCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.WfCmd(),
                wf.LlvmCmd(),
                wf.AsmCoreCmd()
            };

        public static AppCmd commands(IWfRuntime wf)
            => create(wf, providers(wf));
    }
}