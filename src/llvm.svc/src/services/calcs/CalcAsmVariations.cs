//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataCalcs
    {
        public Index<LlvmAsmVariation> CalcAsmVariations(AsmIdentifiers asmid, ReadOnlySpan<InstEntity> entities)
        {
            var count = entities.Length;
            var variations = list<LlvmAsmVariation>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var inst = ref entities[i];
                var name = inst.EntityName.Content;
                var asmstr = inst.AsmString;
                var mnemonic = asmstr.Mnemonic;
                var id = z16;
                if(asmid.Find(name, out var descriptor))
                    id = descriptor.Id;
                else
                    Warn(string.Format("Instruction id for '{0}' not found", name));

                var j = text.index(name.ToLower(), mnemonic.Content);
                var vcode = inst.VarCode;
                if(vcode.IsNonEmpty)
                    variations.Add(new LlvmAsmVariation(id, name, mnemonic, vcode));
            }

            return variations.Array();
        }
    }
}