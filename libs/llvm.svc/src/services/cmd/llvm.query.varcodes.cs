//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    using static core;
    partial class LlvmCmd
    {
        LlvmPaths LlvmPaths => Wf.LlvmPaths();

        const string AsmVarCodeQuery = "llvm/asm/varcodes";

        [CmdOp("llvm/query/asmvars")]
        void EmitVarCodes(CmdArgs args)
        {
            var src = DataProvider.AsmVariations();
            var dst = hashset<AsmVariationCode>();
            iter(src, v => {

                    if(v.IsNonEmpty)
                        dst.Add(v.Code);
                }
                );

            Query.FileEmit(dst.Array().Sort().ToReadOnlySpan(), "llvm.asm.variations", FileKind.List);
        }
    }
}

