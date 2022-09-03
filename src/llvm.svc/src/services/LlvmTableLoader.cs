//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public partial class LlvmTableLoader : AppService<LlvmTableLoader>
    {
        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);
    }
}