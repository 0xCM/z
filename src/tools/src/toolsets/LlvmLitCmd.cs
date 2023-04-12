//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    class LlvmLitCmd : WfAppCmd<LlvmLitCmd>
    {       
        Python Python => Wf.Python();

        FilePath LitPath;

        static LlvmSettings LlvmSettings => AppSettings.LlvmSettings();

        public LlvmLitCmd()
        {
            LitPath = LlvmSettings.Vendor().Scoped("build/bin").Path("llvm-lit", FS.ext("py"));
        }

        [CmdOp("llvm-lit/help")]
        void Help()
        {
            Python.RunScript(LitPath, Cmd.args("--help"));
        }

        [CmdOp("llvm-lit/tests")]
        void ShowTests(CmdArgs args)
        {
            Python.RunScript(LitPath, Cmd.args("--show-tests") + args);
        }

        [CmdOp("llvm-lit")]
        void RunCommand(CmdArgs args)
        {
            Python.RunScript(LitPath, args);
        }
    }
}