//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
       [CmdOp("llvm/list/build/obj")]
        void ObjFiles()
            => Files(WsArchive.BuildFiles(FileKind.Obj));
    }
}