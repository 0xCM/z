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

    public readonly struct EnumValues<E,T> : IIndex<EnumValue<E,T>>
        where E : unmanaged, Enum
    {
        readonly Index<EnumValue<E,T>> Data;

        [MethodImpl(Inline)]
        public EnumValues(params EnumValue<E,T>[] src)
            => Data = src;

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ReadOnlySpan<EnumValue<E,T>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public EnumValue<E,T>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ref readonly EnumValue<E,T> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        [MethodImpl(Inline)]
        public static implicit operator EnumValues<E,T>(EnumValue<E,T>[] src)
            => new EnumValues<E,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator EnumValues<E,T>((FieldInfo field, E eValue, T tValue)[] src)
            => new EnumValues<E,T>(src.Select(x => new EnumValue<E,T>(x.field, x.eValue, x.tValue)));

        [MethodImpl(Inline)]
        public static implicit operator EnumValue<E,T>[](EnumValues<E,T> src)
            => src.Data;
    }
}