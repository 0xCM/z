//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataCalcs
    {
        public LlvmAsmOpCodeMap CalcAsmOpCodeMap(Index<X86InstDef> src)
        {
            var count = src.Length;
            var dst = dict<Identifier,DataList<X86InstDef>>();
            for(var i=0; i<count; i++)
            {
                ref readonly var inst = ref src[i];
                if(inst.isCodeGenOnly || inst.isPseudo)
                    continue;

                if(text.nonempty(inst.OpMap))
                {
                    if(dst.TryGetValue(inst.OpMap, out var map))
                    {
                        map.Add(inst);
                    }
                    else
                    {
                        dst[inst.OpMap] = new();
                        dst[inst.OpMap].Add(inst);
                    }
                }
            }
            return dst.Map(x => (x.Key, new Index<X86InstDef>(x.Value.Array()))).ToDictionary();
        }
    }
}