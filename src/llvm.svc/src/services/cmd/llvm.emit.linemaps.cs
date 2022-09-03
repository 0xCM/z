//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/linemaps")]
        void EmitLineMaps()
        {
            core.exec(true,
                () => LineMaps.EmitMap("llvm", "nvvm.defs", LineMaps.CalcDefMap("llvm","nvvm")),
                () => LineMaps.EmitMap("llvm", "amdgcn.defs", LineMaps.CalcDefMap("llvm","amdgcn")),
                () => LineMaps.EmitMap("llvm", "wasm.defs", LineMaps.CalcDefMap("llvm","wasm")),
                () => LineMaps.EmitMap("llvm", "x86.defs", LineMaps.CalcDefMap("llvm","x86"))
                );
        }

        [CmdOp("llvm/emit/filestats")]
        void EmitFileStats()
        {
            var src = LlvmPaths.RecordFiles("llvm");
            for(var i=0; i<src.Count; i++)
            {
                //var stats = AsciLines.stats(src[i].Path);
            }
        }
    }
}