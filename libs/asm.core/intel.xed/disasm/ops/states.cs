//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedRules.OperandStates;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static OperandStates states(in DataFile src, bool pll = true)
        {
            if(pll)
            {
                var dst = sys.bag<StateRecord>();
                iter(src.Blocks, b => dst.Add(state(b)));
                return new OperandStates(dst.Array().Sort());
            }
            else
            {
                ref readonly var blocks = ref src.Blocks;
                var buffer = alloc<StateRecord>(blocks.Count);
                for(var i=0u; i<blocks.Count; i++ )
                    seek(buffer,i) = state(blocks[i]);
                return new OperandStates(buffer);
            }
        }

        public static StateRecord state(in DisasmBlock block)
        {
            var dst = StateRecord.Empty;
            dst.Asm = block.ParseAsm();
            dst.Ops = block.ParseOps();
            dst.Fields = XedDisasm.fields(block).ParseFields(out dst.State);
            return dst;
        }
    }
}