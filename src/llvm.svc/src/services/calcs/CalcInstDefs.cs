//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static sys;

    partial class LlvmDataCalcs
    {
        public Index<Z0.LlvmInstDef> CalcInstDefs(AsmIdentifiers lookup, ReadOnlySpan<LlvmEntity> entities)
        {
            var found = list<Paired<ushort,X86InstDef>>();
            var count = entities.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref entities[i];
                if(entity.IsInstruction())
                {
                    var inst = entity.ToInstruction();
                    if(lookup.Find(inst.InstName, out var id))
                        found.Add((id.Id,inst));
                }
            }

            var src = found.ViewDeposited();
            var buffer = alloc<Z0.LlvmInstDef>(src.Length);
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var pair = ref skip(src,i);
                ref readonly var id = ref pair.Left;
                ref readonly var entity = ref pair.Right;
                ref var dst = ref seek(buffer,i);
                var asmstr = entity.AsmString;
                dst.AsmId = id;
                dst.CgOnly = entity.isCodeGenOnly;
                dst.Pseudo = entity.isPseudo;
                dst.InstName = entity.InstName;
                dst.Mnemonic = asmstr.Mnemonic;
                dst.FormatPattern = asmstr.FormatPattern;
                dst.InOperandList = entity.InOperandList;
                dst.OutOperandList = entity.OutOperandList;
                dst.VarCode = entity.VarCode;
            }
            return buffer.Sort();
        }
    }
}