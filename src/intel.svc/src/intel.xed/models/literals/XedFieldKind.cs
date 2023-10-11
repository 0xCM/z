//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    public static ReadOnlySeq<XedFeldType> FieldTypes => new XedFeldType[]{
        new(XedFieldKind.Bits,"bit"),
    };

    public readonly record struct XedFeldType
    {
        public readonly XedFieldKind Kind;

        public readonly asci8 Name;

        internal XedFeldType(XedFieldKind kind, asci8 name)
        {
            Kind = kind;
            Name = name;
        }

        public Hash32 Hash
        {
            get => Name.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();
    }

    [SymSource(xed), DataWidth(4,8)]
    public enum XedFieldKind : byte
    {
        [Symbol("xed_bits_t")]
        Bits,

        [Symbol("xed_reg_enum_t")]
        Reg,

        [Symbol("xed_iclass_enum_t")]
        IClass,

        [Symbol("xed_chip_enum_t")]
        Chip,

        [Symbol("xed_uint8_t")]
        U8,

        [Symbol("xed_int8_t")]
        I8,

        [Symbol("xed_uint16_t")]
        U16,

        [Symbol("xed_int16_t")]
        I16,

        [Symbol("xed_uint32_t")]
        U32,

        [Symbol("xed_int32_t")]
        I32,

        [Symbol("xed_uint64_t")]
        U64,

        [Symbol("xed_int64_t")]
        I64,

        [Symbol("xed_error_enum_t")]
        Error,
    }
}
