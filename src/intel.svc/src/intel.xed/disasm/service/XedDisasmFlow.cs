//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedOps;

readonly struct XedDisasmFlow : IXedDisasmFlow
{
    public XedDisasmToken Run(FilePath src, IXedDisasmTarget dst)
    {
        var token = dst.Starting(src);
        if(token.IsNonEmpty)
        {
            var doc = XedDisasm.detail(src);
            var lookup = doc.Blocks.Select(x => (x.DetailRow.IP, x)).ToDictionary();
            var keys = lookup.Keys.Array().Sort().Index();
            var blocks = alloc<XedDisasmDetailBlock>(keys.Count);
            for(var i=0u; i<keys.Count; i++)
            {
                var block = lookup[keys[i]];
                block.DetailRow.Seq = i;
                seek(blocks,i) = block.WithRow(block.DetailRow);
            }

            for(var i=0u; i<blocks.Length; i++)
                Step(i, skip(blocks,i), dst);

            dst.Finished(token);
        }
        return token;
    }

    void Step(uint seq, in XedDisasmDetailBlock src, IXedDisasmTarget dst)
    {
        ref readonly var detail = ref src.DetailRow;
        ref readonly var block = ref src.SummaryLines;
        ref readonly var lines = ref block.Block;
        ref readonly var summary = ref block.Row;
        ref readonly var asmhex = ref summary.Encoded;
        ref readonly var asmtxt = ref summary.Asm;
        ref readonly var ip = ref summary.IP;
        ref readonly var ops = ref detail.Ops;

        dst.Computing(seq, src.Instruction);

        dst.Computed(seq, XedDisasm.asminfo(lines));

        var props = InstFieldValues.Empty;

        XedDisasm.parse(lines, out props);
        dst.Computed(seq, props);

        var fields = Fields.allocate();
        FieldParser.parse(props, fields, false);
        dst.Computed(seq, fields);

        var kinds = fields.MemberKinds();
        dst.Computed(seq, kinds);
        dst.Computed(seq, ops);

        var state = XedOperandState.Empty;
        XedOps.update(fields, kinds, ref state);
        dst.Computed(seq, state);

        var encoding = XedCode.encoding(state, asmhex);
        dst.Computed(seq, encoding);
        dst.Computed(seq, src.Instruction);
    }
}
