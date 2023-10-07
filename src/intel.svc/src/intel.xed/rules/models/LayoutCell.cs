//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules.LayoutCellKind;
using static XedModels;

using K = XedRules.RuleCellKind;

partial class XedRules
{
    public readonly record struct LayoutCell
    {
        public static LayoutCell from(CellValue src)
        {
            var dst = ByteBlock16.Empty;
            switch(src.CellKind)
            {
                case K.BitLit:
                    dst[0] = src.AsBitLit();
                    dst[15] = (byte)BL;
                break;
                case K.HexLit:
                    dst[0] = src.AsHexLit();
                    dst[15] = (byte)XL;
                break;
                case K.WidthVar:
                    dst[0] = (byte)src.AsWidthVar();
                    dst[15] = (byte)WV;
                break;

                case K.InstSeg:
                {
                    var iseg = src.AsInstSeg();
                    dst[14] = (byte)iseg.Field;
                    if(iseg.IsLiteral)
                        @as<FieldSeg>(dst.First) = FieldSeg.literal(iseg.Field, iseg.ToLiteral());
                    else
                        @as<FieldSeg>(dst.First) = FieldSeg.symbolic(iseg.Field, InstSegTypes.pattern(iseg.Type));
                    dst[15] = (byte)LayoutCellKind.FS;
                }
                break;
                case K.NtCall:
                    @as<Nonterminal>(dst.First) = src.AsNonterm();
                    dst[15] = (byte)NT;
                break;
                default:
                    Errors.Throw(AppMsg.UnhandledCase.Format(src.CellKind));
                break;

            }
            return new LayoutCell(dst);
        }

        public const byte RenderWidth = 22;

        readonly ByteBlock16 Data;

        [MethodImpl(Inline)]
        internal LayoutCell(ByteBlock16 data)
        {
            Data = data;
        }

        public FieldKind Field
        {
            [MethodImpl(Inline)]
            get => @as<FieldKind>(Data[14]);
        }

        [MethodImpl(Inline)]
        public Hex8 AsHexLit()
            => @as<Hex8>(Data.First);

        [MethodImpl(Inline)]
        public uint5 AsBitLit()
            => @as<uint5>(Data.First);

        [MethodImpl(Inline)]
        public WidthVar AsWidthVar()
            => @as<WidthVar>(Data.First);

        [MethodImpl(Inline)]
        public FieldSeg AsFieldSeg()
            => @as<FieldSeg>(Data.First);

        [MethodImpl(Inline)]
        public SegVar AsSegVar()
            => @as<SegVar>(Data.First);

        [MethodImpl(Inline)]
        public Nonterminal AsNonterm()
            => @as<Nonterminal>(Data.First);

        public LayoutCellKind Kind
        {
            [MethodImpl(Inline)]
            get => @as<LayoutCellKind>(Data[15]);
        }

        public bool IsRule
        {
            [MethodImpl(Inline)]
            get => Kind == LayoutCellKind.NT;
        }

        [MethodImpl(Inline)]
        public static explicit operator ulong(LayoutCell src)
            => src.Data.A;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public string Format()
        {
            var dst = EmptyString;
            switch(Kind)
            {
                case None:
                    dst = EmptyString;
                break;
                case BL:
                    dst = XedRender.format(AsBitLit());
                break;
                case XL:
                    dst = XedRender.format(AsHexLit());
                break;
                case LayoutCellKind.FS:
                    dst = XedRender.format(AsFieldSeg());
                break;
                case NT:
                    dst = XedRender.format(AsNonterm());
                break;
            }
            return dst;
        }

        public override string ToString()
            => Format();

        public static LayoutCell Empty => default;
    }
}
