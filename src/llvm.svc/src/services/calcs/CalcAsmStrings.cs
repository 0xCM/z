//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static sys;

    partial class LlvmDataCalcs
    {
        public Index<LlvmAsmPattern> CalcAsmStrings(Index<LlvmEntity> src)
        {
            var count = src.Count;
            var dst = sys.bag<LlvmAsmPattern>();
            iter(src, entity => {

                if(entity.IsInstruction())
                {
                    var inst = entity.ToInstruction();
                    if(!inst.isCodeGenOnly && !inst.isPseudo)
                        dst.Add(inst.AsmString);
                }

            }, true);
            return dst.Array().Sort();
        }
    }
}