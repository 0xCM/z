//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/list/cpp")]
        void LlvmCppFiles()
            => Files(WsArchive.Files(FileKind.Cpp));
    }
}