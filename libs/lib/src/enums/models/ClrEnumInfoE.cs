//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct ClrEnumInfo<E>
        where E : unmanaged, Enum
    {
        readonly MemoryAddress DetailAddress;

        readonly MemoryAddress LiteralAddress;

        readonly MemoryAddress FieldAddress;

        public uint FieldCount {get;}

        readonly uint Filler;

        [MethodImpl(Inline)]
        public ClrEnumInfo(MemoryAddress details, MemoryAddress literals, MemoryAddress fields, uint count)
        {
            DetailAddress = details;
            LiteralAddress = literals;
            FieldAddress = fields;
            FieldCount = count;
            Filler = 0;
        }

        ref EnumLiteralDetail<E> FirstDetailCell
        {
            [MethodImpl(Inline)]
            get => ref @ref<Index<EnumLiteralDetail<E>>>(DetailAddress).First;
        }

        ref ClrEnumFieldAdapter<E> FirstFieldCell
        {
            [MethodImpl(Inline)]
            get => ref @ref<Index<ClrEnumFieldAdapter<E>>>(DetailAddress).First;
        }

        ref E FirstLiteralCell
        {
            [MethodImpl(Inline)]
            get => ref @ref<Index<E>>(DetailAddress).First;
        }

        public ReadOnlySpan<EnumLiteralDetail<E>> LiteralDetails
        {
            [MethodImpl(Inline)]
            get => cover<EnumLiteralDetail<E>>(address(FirstDetailCell), FieldCount);
        }

        public ReadOnlySpan<ClrEnumFieldAdapter<E>> EnumFields
        {
            [MethodImpl(Inline)]
            get => cover<ClrEnumFieldAdapter<E>>(address(FirstFieldCell), FieldCount);
        }

        public ReadOnlySpan<E> LiteralValues
        {
            [MethodImpl(Inline)]
            get => cover<E>(address(FirstLiteralCell), FieldCount);
        }
    }
}