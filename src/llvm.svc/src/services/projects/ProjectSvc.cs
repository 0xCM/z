//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;
    using static llvm.LlvmSubtarget;

    public partial class ProjectSvc : WfAppCmd<ProjectSvc>
    {
        WfScripts Scripts => Wf.ToolScripts();

        CoffServices Coff => Wf.CoffServices();

        public FilePath AsmSyntaxTable(ProjectId project)
            => EtlContext.table<AsmSyntaxRow>(project);

        public void BuildLlc(IProjectWorkspace project, LlvmSubtarget subtarget, bool runexe = false)
        {
            var scriptid = subtarget switch
            {
                Sse => "llc-build-sse",
                Sse2 => "llc-build-sse2",
                Sse3 => "llc-build-sse3",
                Sse41 => "llc-build-sse41",
                Sse42 => "llc-build-sse42",
                Avx => "llc-build-avx",
                Avx2 => "llc-build-avx2",
                Avx512 => "llc-build-avx512",
                _ => EmptyString
            };
            Scripts.RunScripts(project, FileKind.Llir, project.Script(scriptid), runexe);
        }
   }
}