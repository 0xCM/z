//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    partial class ProjectCmd
    {
        [CmdOp("project/build/llc")]
        void LlcBuild()
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Avx512);

        [CmdOp("project/build/llc-sse")]
        void LlcSse()
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Sse);

        [CmdOp("project/build/llc-sse2")]
        void LlcSse2()
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Sse2);

        [CmdOp("project/build/llc-sse3")]
        void LlcSse3()
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Sse3);

        [CmdOp("project/build/llc-sse41")]
        void LlcSse41()
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Sse41);

        [CmdOp("project/build/llc-sse42")]
        void LlcSse42()
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Sse42);

        [CmdOp("project/build/llc-avx")]
        void LlcAvx()
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Avx);

        [CmdOp("project/build/llc-avx2")]
        void LlcAvx2()
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Avx2);

        [CmdOp("project/build/llc-avx512")]
        void LlcAvx512()
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Avx512);

        [CmdOp("project/build+run/llc-avx512")]
        void LlcAvx512BuildRun()
            => ProjectSvc.BuildLlc(Project(), LlvmSubtarget.Avx512);
    }
}