//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    /// <summary>
    /// Defines an E-V parametric enum value
    /// </summary>
    public readonly struct EnumLiteralDetail<E,P> : IEnumLiteral<EnumLiteralDetail<E,P>,E,P>
        where E : unmanaged, Enum
        where P : unmanaged
    {
        public EnumLiteralDetail<E> Spec {get;}

        /// <summary>
        /// The literal V-value
        /// </summary>
        public P PrimalValue {get;}

        [MethodImpl(Inline)]
        public EnumLiteralDetail(EnumLiteralDetail<E> spec, P v)
        {
            Spec = spec;
            PrimalValue = v;
        }

        /// <summary>
        /// The literal declaration order, unique within the declaring enum
        /// </summary>
        public uint Position
        {
            [MethodImpl(Inline)]
            get => Spec.Position;
        }

        /// <summary>
        /// The literal identifier, unique within the declaring enum
        /// </summary>
        public string Name
        {
            [MethodImpl(Inline)]
            get => Field.Name;
        }

        /// <summary>
        /// The literal E-value
        /// </summary>
        public E LiteralValue
        {
            [MethodImpl(Inline)]
            get => Spec.LiteralValue;
        }

        public ulong ScalarValue
        {
            [MethodImpl(Inline)]
            get => core.bw64(LiteralValue);
        }

        /// <summary>
        /// The numeric kind refined by the enum
        /// </summary>
        public ClrEnumKind PrimalKind
        {
            [MethodImpl(Inline)]
            get => Enums.@base<E>();
        }

        public CliToken Token
        {
            [MethodImpl(Inline)]
            get => Spec.Token;
        }

        public FieldInfo Field
        {
            [MethodImpl(Inline)]
            get => Spec.DefiningField;
        }

        public Type PrimalType
        {
            [MethodImpl(Inline)]
            get => typeof(P);
        }


        [MethodImpl(Inline)]
        public bool Equals(EnumLiteralDetail<E,P> src)
            => Spec.Equals(src.Spec) && PrimalValue.Equals(src.PrimalValue);


        public override bool Equals(object src)
            => src is EnumLiteralDetail<E,P> x && Equals(x);

        public override int GetHashCode()
            => (int)Position;

        public override string ToString()
            => (this as IEnumLiteral).Format();
    }
}