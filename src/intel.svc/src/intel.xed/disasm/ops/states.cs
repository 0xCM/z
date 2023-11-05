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
    public static FieldStateIndex states(in XedDisasmFile src, bool pll = true)
    {
        if(pll)
        {
            var dst = sys.bag<FieldStates>();
            iter(src.Blocks, b => dst.Add(state(b)));
            return new FieldStateIndex(dst.Array().Sort());
        }
        else
        {
            ref readonly var blocks = ref src.Blocks;
            var buffer = alloc<FieldStates>(blocks.Count);
            for(var i=0u; i<blocks.Count; i++ )
                seek(buffer,i) = state(blocks[i]);
            return new FieldStateIndex(buffer);
        }
    }

    public static FieldStates state(in XedDisasmBlock block)
    {
        var dst = FieldStates.Empty;
        dst.Asm = block.ParseAsm();
        dst.Ops = block.ParseOps();
        dst.FieldValues = fields(block).ParseFields(out dst.Fields);
        return dst;
    }
}
