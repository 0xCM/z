//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        Tooling ToolBox => Wf.Tooling();

        public Index<ToolHelpDoc> CalcHelpDocs()
            => ToolBox.LoadHelpDocs(LlvmPaths.HelpSouces()).Values.ToArray().Index();
    }
}