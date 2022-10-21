//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static sys;

    public class EnvSvc : WfSvc<EnvSvc>
    {
        [CmdOp("env/process/paths")]
        void ProcPaths()
        {
            var src = Env.process();
            //iter(src, var => Channel.Row(var));
        }

    }
}