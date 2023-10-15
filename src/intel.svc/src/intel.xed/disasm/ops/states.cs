//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedFields;
using static XedRules;

partial class XedDisasm
{
    public static StateIndex states(in XedDisasmFile src, bool pll = true)
    {
        if(pll)
        {
            var dst = sys.bag<States>();
            iter(src.Blocks, b => dst.Add(state(b)));
            return new StateIndex(dst.Array().Sort());
        }
        else
        {
            ref readonly var blocks = ref src.Blocks;
            var buffer = alloc<States>(blocks.Count);
            for(var i=0u; i<blocks.Count; i++ )
                seek(buffer,i) = state(blocks[i]);
            return new StateIndex(buffer);
        }
    }

    public static States state(in XedDisasmBlock block)
    {
        var dst = States.Empty;
        dst.Asm = block.ParseAsm();
        dst.Ops = block.ParseOps();
        dst.FieldValues = fields(block).ParseFields(out dst.Fields);
        return dst;
    }
}
