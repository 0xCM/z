//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedOps;
    using static XedRules;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static InstFieldValues fields(in DisasmBlock src)
        {
            parse(src, out InstFieldValues dst);
            return dst;
        }

        public static DisasmFieldBuffer fields()
            => DisasmFieldBuffer.allocate();

        public static DisasmFieldBuffer fields(in DisasmDetailBlock src, ref DisasmFieldBuffer dst)
        {
            dst.Clear();
            ref readonly var lines = ref src.SummaryLines;
            dst.Props = fields(lines.Block);
            FieldParser.parse(dst.Props, dst.Fields, false);
            dst.Asm = asminfo(lines.Block);
            dst.Lines = lines.Block;
            dst.Detail = src.DetailRow;
            dst.Summary = lines.Row;
            dst.Selected = dst.Fields.MemberKinds();
            XedOps.update(dst.Fields, dst.Selected, ref dst.State);
            dst.Encoding = XedCode.encoding(dst.State, lines.Row.Encoded);
            return dst;
        }
    }
}