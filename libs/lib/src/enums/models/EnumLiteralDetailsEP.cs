//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an E-V parametric literal index
    /// </summary>
     public readonly struct EnumLiteralDetails<E,P> : IIndex<EnumLiteralDetail<E,P>>
        where E : unmanaged, Enum
        where P : unmanaged
    {
        readonly Index<EnumLiteralDetail<E,P>> Data;

        [MethodImpl(Inline)]
        public EnumLiteralDetails(EnumLiteralDetail<E,P>[] src)
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

        public EnumLiteralDetail<E,P>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<EnumLiteralDetail<E,P>> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ReadOnlySpan<EnumLiteralDetail<E,P>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public ref readonly EnumLiteralDetail<E,P> this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly EnumLiteralDetail<E,P> this[ulong i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        [MethodImpl(Inline)]
        public static implicit operator EnumLiteralDetails<E,P>(EnumLiteralDetail<E,P>[] src)
            => new EnumLiteralDetails<E,P>(src);
    }
}