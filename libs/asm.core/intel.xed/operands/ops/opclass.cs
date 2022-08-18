//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedOps
    {
        [MethodImpl(Inline), Op]
        public static bit IsRegLit(OpType src)
            => src == OpType.REG;

        [MethodImpl(Inline), Op]
        public static bit IsImmLit(OpType src)
            => src == OpType.IMM;

        [MethodImpl(Inline), Op]
        public static bit IsRule(OpType src)
            => src == OpType.NT_LOOKUP_FN || src == OpType.NT_LOOKUP_FN2 || src == OpType.NT_LOOKUP_FN4;

        public static InstOpClass opclass(in OpSpec src)
        {
            var dst = InstOpClass.Empty;
            dst.Kind = src.Kind;
            dst.BitWidth = src.BitWidth;
            dst.ElementType = src.ElementType;
            dst.ElementCount = src.ElementCount;
            dst.IsRegLit = src.Reg.IsNonEmpty;
            dst.IsRule = src.Rule.IsNonEmpty;
            dst.WidthCode = src.WidthCode;
            return dst;
        }

        public static InstOpClass opclass(MachineMode mode, in OpSpec spec)
        {
            var desc = describe(spec.WidthCode);
            var width = XedOps.width(mode, spec.WidthCode);
            var dst =  new InstOpClass {
                        Kind = spec.Kind,
                        BitWidth = width.Bits,
                        ElementType = desc.ElementType,
                        IsRegLit = IsRegLit(spec.OpType),
                        IsRule = IsRule(spec.OpType),
                        ElementCount = desc.ElementCount,
                        WidthCode = spec.WidthCode,
                    };

            return dst;
        }

        public static InstOpClass opclass(in InstOpDetail src)
        {
            var dst = InstOpClass.Empty;
            dst.Kind = src.Kind;
            dst.BitWidth = src.BitWidth;
            dst.ElementType = src.ElementType;
            dst.ElementCount = src.SegInfo.CellCount;
            dst.IsRegLit = src.IsRegLit;
            dst.IsRule = src.IsNonterm;
            dst.WidthCode = src.WidthCode;
            return dst;
        }
    }
}