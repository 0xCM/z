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
        [MethodImpl(Inline)]
        public static Field init(FieldKind kind, bit value)
            => new ((ushort)value, kind, FieldDataKind.Bit);

        [MethodImpl(Inline)]
        public static Field init(FieldKind kind, byte value)
            => new ((ushort)value, kind, FieldDataKind.Byte);

        [MethodImpl(Inline)]
        public static Field init(FieldKind kind, ushort value)
            => new ((ushort)value, kind, FieldDataKind.Word);

        [MethodImpl(Inline)]
        public static Field init(FieldKind kind, Register value)
            => new ((ushort)value, kind, FieldDataKind.Reg);

        [MethodImpl(Inline)]
        public static Field init(FieldKind kind, ChipCode value)
            => new ((ushort)value, kind, FieldDataKind.Chip);

        [MethodImpl(Inline)]
        public static Field init(FieldKind kind, XedInstClass value)
            => new ((ushort)value, kind, FieldDataKind.InstClass);

        [MethodImpl(Inline), Op]
        public static XedInstClass value(Field src, out XedInstClass dst)
        {
            dst = src;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static Register value(Field src, out Register dst)
        {
            dst = src;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static bit value(Field src, out bit dst)
        {
            dst = src;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static byte value(Field src, out byte dst)
        {
            dst = src;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ushort value(Field src, out ushort dst)
        {
            dst = src;
            return dst;
        }

        readonly ushort Data;

        public readonly FieldKind Kind;

        readonly FieldDataKind Type;

        [MethodImpl(Inline)]
        Field(ushort content, FieldKind kind, FieldDataKind type)
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
        Register Reg()
            => (Register)Data;

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
        public static implicit operator Register(Field src)
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
        public static implicit operator uint3(Field src)
            => src.Byte();

        [MethodImpl(Inline)]
        public static implicit operator LLRC(Field src)
            => (LLRC)src.Byte();

        [MethodImpl(Inline)]
        public static implicit operator uint2(Field src)
            => src.Byte();

        [MethodImpl(Inline)]
        public static implicit operator Hex8(Field src)
            => src.Byte();

        [MethodImpl(Inline)]
        public static implicit operator ushort(Field src)
            => src.Word();

        [MethodImpl(Inline)]
        public static implicit operator Field((FieldKind kind, Register data) src)
            => init(src.kind, src.data);

        [MethodImpl(Inline)]
        public static implicit operator Field((FieldKind kind, ChipCode data) src)
            => init(src.kind, src.data);

        [MethodImpl(Inline)]
        public static implicit operator Field((FieldKind kind, XedInstClass data) src)
            => init(src.kind, src.data);

        [MethodImpl(Inline)]
        public static implicit operator Field(Paired<FieldKind,bit> src)
            => init(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Field(Paired<FieldKind,byte> src)
            => init(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator Field((FieldKind kind, ushort data) src)
            => init(src.kind, src.data);

        public static Field Empty => default;
    }
}
