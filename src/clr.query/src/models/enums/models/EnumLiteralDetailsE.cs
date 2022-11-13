//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an E-parametric literal index
    /// </summary>
    public readonly struct EnumLiteralDetails<E> : IIndex<EnumLiteralDetail<E>>
        where E : unmanaged, Enum
    {
        readonly Index<EnumLiteralDetail<E>> Data;

        [MethodImpl(Inline)]
        public EnumLiteralDetails(EnumLiteralDetail<E>[] src)
            => Data = src;

        public EnumLiteralDetail<E>[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public ReadOnlySpan<EnumLiteralDetail<E>> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public ref readonly EnumLiteralDetail<E> this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly EnumLiteralDetail<E> this[ulong i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public E[] LiteralValues
        {
            [MethodImpl(Inline)]
            get => Data.Map(x => x.LiteralValue);
        }

        public F[] Convert<F>()
            where F : unmanaged, Enum
        {
            var src = LiteralValues;
            var dst = new F[src.Length];
            for(var i=0; i< src.Length; i++)
                dst[i] = (F)(object)src[i];
            return dst;
        }

        public Index<NamedValue<E>> NamedValues
            => from i in Data select new NamedValue<E>(i.Name, i.LiteralValue);

        [MethodImpl(Inline)]
        public static implicit operator EnumLiteralDetails<E>(EnumLiteralDetail<E>[] src)
            => new EnumLiteralDetails<E>(src);
    }
}