//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an enumeration literal as the triple (index,identifier,value)
    /// </summary>
    /// <remarks>
    /// Defining a literal this way attempts to overcome troublesome aspects in which C#/clr enums
    /// are implemented and preserves all enum information content. It is value-invariant in the sense
    /// that the numeric content of does of a member not impact the n index/name content.
    /// Thus, enum value duplication isn't an issue since all data are preserved, the api end-user can decide what
    /// value duplication means in a given context
    /// </remarks>
    public readonly struct EnumLiteralDetail<E> : IEnumLiteral<EnumLiteralDetail<E>, E>
        where E : unmanaged, Enum
    {
        /// <summary>
        /// The compiler-emitted field that defines the literal
        /// </summary>
        public FieldInfo DefiningField {get;}

        /// <summary>
        /// The kind of primitive specialized by the enum
        /// </summary>
        public ClrEnumKind PrimalKind {get;}

        /// <summary>
        /// The literal declaration order, unique within the declaring enum
        /// </summary>
        public uint Position {get;}

        /// <summary>
        /// The literal identifier, unique within the declaring enum
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The literal E-value
        /// </summary>
        public E LiteralValue {get;}

        /// <summary>
        /// The system data type
        /// </summary>
        public Type PrimalType {get;}

        /// <summary>
        /// The metadata token that identifies the backing field
        /// </summary>
        public EcmaToken Token
        {
            [MethodImpl(Inline)]
            get => DefiningField;
        }

        public ulong ScalarValue
        {
            [MethodImpl(Inline)]
            get => sys.bw64(LiteralValue);
        }

        [MethodImpl(Inline)]
        public EnumLiteralDetail(FieldInfo field, ClrEnumKind kind, uint index, string identifier, E value)
        {
            DefiningField = field;
            PrimalKind = kind;
            PrimalType = typeof(E).GetEnumUnderlyingType();
            Name = identifier;
            Position = index;
            LiteralValue = value;
        }

        [MethodImpl(Inline)]
        public bool Equals(EnumLiteralDetail<E> src)
            => Token == src.Token
            && Position == src.Position
            && Name == src.Name
            && LiteralValue.Equals(src.LiteralValue);

        public override bool Equals(object src)
            => src is EnumLiteralDetail<E> x && Equals(x);

        public override int GetHashCode()
            => (int)Position;

        public override string ToString()
            => (this as IEnumLiteral).Format();
    }
}