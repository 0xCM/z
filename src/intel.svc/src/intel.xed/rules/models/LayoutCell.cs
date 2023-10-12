//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules.LayoutCellKind;
using static XedModels;

partial class XedRules
{
    public readonly record struct LayoutCell
    {
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
