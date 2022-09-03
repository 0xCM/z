//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using NK = NumericKind;
    using EK = ClrEnumKind;

    public readonly struct ClrEnumLiteral
    {
        /// <summary>
        /// Determines the integral type refined by a parametrically-identified enum type
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        public static ClrEnumKind @base<E>()
            where E : unmanaged, Enum
                => @base(typeof(E).GetEnumUnderlyingType().NumericKind());

        /// <summary>
        /// Determines the integral type refined by a value-identified enum type
        /// </summary>
        /// <param name="value">The enum value</typeparam>
        [Op]
        public static ClrEnumKind @base(Enum value)
            => @base(value.GetType().GetEnumUnderlyingType().NumericKind());

        /// <summary>
        /// Determines the integral type refined by a specified enum type
        /// </summary>
        /// <typeparam name="E">The enum type</typeparam>
        [Op]
        public static ClrEnumKind @base(Type et)
            => @base(et.GetEnumUnderlyingType().NumericKind());

        [Op]
        public static ClrEnumKind @base(NumericKind src)
             => src switch{
                NK.U8 => EK.U8,
                NK.I8 => EK.I8,
                NK.U16 => EK.U16,
                NK.I16 => EK.I16,
                NK.U32 => EK.U32,
                NK.I32 => EK.I32,
                NK.I64 => EK.I64,
                NK.U64 => EK.U64,
                _ => ClrEnumKind.None,
            };
         
        public FieldInfo Definition {get;}

        [MethodImpl(Inline)]
        public ClrEnumLiteral(FieldInfo src)
            => Definition = src;

        [MethodImpl(Inline)]
        public string Format()
            => Definition.Name;

        [MethodImpl(Inline)]
        public bool Equals(ClrEnumLiteral src)
            => Definition.Equals(src.Definition);

        public override bool Equals(object obj)
            => Definition.Equals(obj);

        public override int GetHashCode()
            => Definition.GetHashCode();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(ClrEnumLiteral lhs, ClrEnumLiteral rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator !=(ClrEnumLiteral lhs, ClrEnumLiteral rhs)
            => !lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static implicit operator FieldInfo(ClrEnumLiteral src)
            => src.Definition;

        [MethodImpl(Inline)]
        public static implicit operator ClrEnumLiteral(FieldInfo src)
            => new ClrEnumLiteral(src);
    }
}