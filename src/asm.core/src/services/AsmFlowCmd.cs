//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AsmFlowCmd : AppCmdService<AsmFlowCmd>
    {
        [CmdOp("mc/cleanse")]
        Outcome ExecMcCleanse(CmdArgs args)
        {
            var cmdname = "cleanse";
            var scope = "att/64";
            var project = Project();
            //var cmd = AsmFlows.Select(SToAsm.Instance);
            //cmd.Execute(project, (scope, cmdname));
            return true;
        }

        [CmdOp("mc/asm-to-mcasm")]
        Outcome ExecAsmToMcAsm(CmdArgs args)
        {
            var cmdname = "asm-to-mcasm";
            var scope = "asm";
            var project = Project();
            //var builder = AsmFlows.Select(AsmToMcAsm.Instance);
            //builder.Execute(project, (scope, cmdname));
            return true;
        }
    }
}