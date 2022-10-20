//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public partial class ProjectCmd : WfAppCmd<ProjectCmd>
    {
        CoffServices Coff => Wf.CoffServices();

        ToolScripts Scripts => Wf.ToolScripts();

        AsmObjects AsmObjects => Wf.AsmObjects();

        ProjectSvc ProjectSvc => Wf.ProjectSvc();

        ToolScripts Projects => Wf.ToolScripts();

        AsmRegSets Regs => Service(AsmRegSets.create);

        Dictionary<string,string> BuildCmdNames {get;}
            = new (string project, string cmd)[]{
                        ("mc.models", "project/build/asm"),
                        ("clang.models","project/build/c"),
                        ("llvm.models","project/build/llc"),
                        ("canonical","project/build/builtins")
            }.ToDictionary();
   }
}