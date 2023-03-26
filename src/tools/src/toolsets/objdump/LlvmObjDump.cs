//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using static sys;

    class LlvmObjDump : WfAppCmd<LlvmObjDump>
    {        
        [CmdOp("llvm/objdump")]
        void Run(CmdArgs args)
        {
            var src = FS.dir(args[0]);
            var index = FS.index(Archives.modules(src).Files(FileKind.Obj, FileKind.Exe, FileKind.Dll));
            var tool = AppSettings.LlvmSettings().Tool("llvm-objdump");
            var cmdargs = Cmd.args(tool.Format(PathSeparator.BS),"", "--x86-asm-syntax=att", "--disassemble");
            iter(index.Distinct(), path => {
                var _args = cmdargs.Replicate();
                _args[1] = Cmd.arg(path);
                var result = ProcExec.redirect(Channel, _args).Result;                
            });
        }
    }
}