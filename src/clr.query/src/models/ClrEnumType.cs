//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ClrEnumType : IClrEnumType
    {
        public readonly string Name;

        public readonly ClrEnumKind EnumKind;

        public readonly NativeClass NativeClass;

        [MethodImpl(Inline)]
        public ClrEnumType(Identifier name, ClrEnumKind kind)
        {
            Name = name;
            EnumKind = kind;
            NativeClass = kind.IsSigned() ? NativeClass.I : NativeClass.U;
        }

        ClrEnumKind IClrEnumType.EnumKind
            => EnumKind;

        Identifier IClrType.Name
            => Name;

        public string Format()
            => string.Format("enum<{0}:{1}>", Name, EnumKind.CsKeyword());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ClrEnumKind(ClrEnumType src)
            => src.EnumKind;
    }
}