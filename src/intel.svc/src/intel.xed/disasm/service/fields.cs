//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedOps;
    using static XedRules;

    partial class XedDisasm
    {
        public static InstFieldValues fields(in XedDisasmBlock src)
        {
            parse(src, out InstFieldValues dst);
            return dst;
        }

        public static XedDisasmFields fields()
            => XedDisasmFields.allocate();

        public static XedDisasmFields fields(in XedDisasmDetailBlock src, ref XedDisasmFields dst)
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