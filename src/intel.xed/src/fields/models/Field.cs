//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static XedModels;

using DT = XedRules.FieldDataKind;

partial class XedRules
{
    /// <summary>
    /// Specifies the value of a <see cref='XedFieldState'/> field for a specified <see cref='FieldKind'/>
    /// </summary>
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public readonly struct Field
    {
        readonly ushort Data;

        public readonly FieldKind Kind;

        readonly FieldDataKind Type;

        [MethodImpl(Inline)]
        internal Field(ushort content, FieldKind kind, FieldDataKind type)
        {
            Data = content;
            Kind = kind;
            Type = type;
        }

        [MethodImpl(Inline)]
        bit Bit()
            => (bit)Data;

        [MethodImpl(Inline)]
        byte Byte()
            => (byte)Data;

        [MethodImpl(Inline)]
        ushort Word()
            => Data;

        [MethodImpl(Inline)]
        RegExpr Reg()
            => (RegExpr)Data;

        [MethodImpl(Inline)]
        ChipCode Chip()
            => (ChipCode)Data;

        [MethodImpl(Inline)]
        XedInstClass Inst()
            => (XedInstClass)Data;

        [MethodImpl(Inline)]
        BroadcastKind BCast()
            => (BroadcastKind)Data;

        [MethodImpl(Inline)]
        AsmVL VL()
            => (AsmVL)Data;

        [MethodImpl(Inline)]
        RuleOperator Operator()
            => (OperatorKind)Data;

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
            switch(Type)
            {
                case DT.Bit:
                    dst = Bit().ToString();
                break;
                case DT.Byte:
                    dst = Byte().ToString();
                break;
                case DT.Word:
                    dst = Word().ToString();
                break;
                case DT.Reg:
                    dst = XedRender.format(Reg());
                break;
                case DT.Chip:
                    dst = XedRender.format(Chip());
                break;
                case DT.InstClass:
                    dst = XedRender.format(Inst());
                break;
            }
            return dst;
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator RegExpr(Field src)
            => src.Reg();

        [MethodImpl(Inline)]
        public static implicit operator XedRegId(Field src)
            => src.Reg();

        [MethodImpl(Inline)]
        public static implicit operator XedInstKind(Field src)
            => src.Inst();

        [MethodImpl(Inline)]
        public static implicit operator XedInstClass(Field src)
            => src.Inst();

        [MethodImpl(Inline)]
        public static implicit operator BroadcastKind(Field src)
            => src.BCast();

        [MethodImpl(Inline)]
        public static implicit operator ChipCode(Field src)
            => src.Chip();

        [MethodImpl(Inline)]
        public static implicit operator AsmVL(Field src)
            => src.VL();

        [MethodImpl(Inline)]
        public static implicit operator bit(Field src)
            => src.Bit();

        [MethodImpl(Inline)]
        public static implicit operator byte(Field src)
            => src.Byte();

        [MethodImpl(Inline)]
        public static implicit operator LLRC(Field src)
            => (LLRC)src.Byte();

        [MethodImpl(Inline)]
        public static implicit operator uint2(Field src)
            => src.Byte();

        [MethodImpl(Inline)]
        public static implicit operator num2(Field src)
            => src.Byte();

        [MethodImpl(Inline)]
        public static implicit operator num3(Field src)
            => src.Byte();

        [MethodImpl(Inline)]
        public static implicit operator Hex8(Field src)
            => src.Byte();

        [MethodImpl(Inline)]
        public static implicit operator ushort(Field src)
            => src.Word();

        [MethodImpl(Inline)]
        public static implicit operator Field((FieldKind kind, RegExpr data) src)
            => XedFields.init(src.kind, src.data);

        [MethodImpl(Inline)]
        public static implicit operator Field((FieldKind kind, ChipCode data) src)
            => XedFields.init(src.kind, src.data);

        [MethodImpl(Inline)]
        public static implicit operator Field((FieldKind kind, XedInstClass data) src)
            => XedFields.init(src.kind, src.data);

        [MethodImpl(Inline)]
        public static implicit operator Field(Paired<FieldKind,bit> src)
            => XedFields.init(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Field(Paired<FieldKind,byte> src)
            => XedFields.init(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Field((FieldKind kind, ushort data) src)
            => XedFields.init(src.kind, src.data);

        public static Field Empty => default;
    }
}
