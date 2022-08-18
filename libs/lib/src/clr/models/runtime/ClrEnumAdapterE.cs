//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct ClrEnumAdapter<E>
        where E : unmanaged, Enum
    {
        public Type Definition => TD;

        [MethodImpl(Inline)]
        public ClrEnumInfo<E> Describe()
            => new ClrEnumInfo<E>(address(_Details), address(_Literals), address(_Fields), FieldCount);

        public Count FieldCount
        {
            [MethodImpl(Inline)]
            get => _Fields.Count;
        }

        public CliToken Token
        {
            [MethodImpl(Inline)]
            get => Definition.MetadataToken;
        }

        public ClrEnumAdapter Untyped
        {
            [MethodImpl(Inline)]
            get => new ClrEnumAdapter(Definition);
        }

        public ReadOnlySpan<E> Literals
        {
            [MethodImpl(Inline)]
            get => _Literals.View;
        }

        public ReadOnlySpan<ClrEnumFieldAdapter<E>> Fields
        {
            [MethodImpl(Inline)]
            get => _Fields.View;
        }

        public ReadOnlySpan<EnumLiteralDetail<E>> Details
        {
            [MethodImpl(Inline)]
            get => _Details.View;
        }

        public EnumDetails<E> DetailProvider
        {
            [MethodImpl(Inline)]
            get => Provider;
        }

        public ClrTypeName Name
        {
            [MethodImpl(Inline)]
            get => Definition;
        }

        [MethodImpl(Inline)]
        public static implicit operator ClrEnumAdapter(ClrEnumAdapter<E> src)
            => src.Untyped;

        [MethodImpl(Inline)]
        public static implicit operator Type(ClrEnumAdapter<E> src)
            => src.Definition;

        [MethodImpl(Inline)]
        public static implicit operator ClrTypeAdapter<E>(ClrEnumAdapter<E> src)
            => default;

        static readonly Type TD = typeof(E);

        static readonly EnumDetails<E> Provider = EnumDetails<E>.create();

        [FixedAddressValueType]
        static readonly Index<EnumLiteralDetail<E>> _Details = Provider.Details;

        [FixedAddressValueType]
        static Index<E> _Literals = Provider.LiteralValues;

        [FixedAddressValueType]
        static Index<ClrEnumFieldAdapter<E>> _Fields = Provider.EnumFields;
    }
}