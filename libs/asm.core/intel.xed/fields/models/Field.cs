//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using DT = XedRules.FieldDataKind;

    partial class XedRules
    {
        /// <summary>
        /// Specifies the value of a <see cref='OperandState'/> field for a specified <see cref='FieldKind'/>
        /// </summary>
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct Field
        {
            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, bit value)
                => new Field((ushort)value, kind, FieldDataKind.Bit);

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, byte value)
                => new Field((ushort)value, kind, FieldDataKind.Byte);

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, ushort value)
                => new Field((ushort)value, kind, FieldDataKind.Word);

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, Register value)
                => new Field((ushort)value, kind, FieldDataKind.Reg);

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, ChipCode value)
                => new Field((ushort)value, kind, FieldDataKind.Chip);

            [MethodImpl(Inline)]
            public static Field init(FieldKind kind, AmsInstClass value)
                => new Field((ushort)value, kind, FieldDataKind.InstClass);

            [MethodImpl(Inline), Op]
            public static ref AmsInstClass value(Field src, out AmsInstClass dst)
            {
                dst = src;
                return ref dst;
            }

            [MethodImpl(Inline), Op]
            public static ref Register value(Field src, out Register dst)
            {
                dst = src;
                return ref dst;
            }

            [MethodImpl(Inline), Op]
            public static ref bit value(Field src, out bit dst)
            {
                dst = src;
                return ref dst;
            }

            [MethodImpl(Inline), Op]
            public static ref byte value(Field src, out byte dst)
            {
                dst = src;
                return ref dst;
            }

            [MethodImpl(Inline), Op]
            public static ref ushort value(Field src, out ushort dst)
            {
                dst = src;
                return ref dst;
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
            AmsInstClass Inst()
                => (AmsInstClass)Data;

            [MethodImpl(Inline)]
            BCastKind BCast()
                => (BCastKind)Data;

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
            public static implicit operator AsmInstKind(Field src)
                => src.Inst();

            [MethodImpl(Inline)]
            public static implicit operator AmsInstClass(Field src)
                => src.Inst();

            [MethodImpl(Inline)]
            public static implicit operator BCastKind(Field src)
                => src.BCast();

            [MethodImpl(Inline)]
            public static implicit operator ChipCode(Field src)
                => src.Chip();

            [MethodImpl(Inline)]
            public static implicit operator bit(Field src)
                => src.Bit();

            [MethodImpl(Inline)]
            public static implicit operator byte(Field src)
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
            public static implicit operator Field((FieldKind kind, AmsInstClass data) src)
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
}