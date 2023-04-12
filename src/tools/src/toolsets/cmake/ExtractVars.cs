//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools.CMake
{
    [CmdRoute(ExtractVarsCmd.CmdName)]
    class ExtractVarsHandler : CmdHandler<ExtractVarsCmd>
    {
        public override BoundCmd<ExtractVarsCmd> Bind(CmdArgs args)
            => new(new ExtractVarsCmd{
                BuildRoot = FS.dir(args[0]),
                Target = FS.path(args[1])
            }, args);

        public override void Run(ExtractVarsCmd cmd)
        {
            Wf.CMake().Execute(cmd);
        }
    }    
}