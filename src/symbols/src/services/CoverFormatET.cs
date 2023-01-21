//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CoverFormat<E,T>
        where E : unmanaged, Enum
        where T : unmanaged
    {
        public readonly EnumCover<E,T> Source;

        public readonly EnumFormatMode Mode;

        [MethodImpl(Inline)]
        public CoverFormat(E src, EnumFormatMode mode)
        {
            Source = src;
            Mode = mode;
        }

        [MethodImpl(Inline)]
        public CoverFormat(T src, EnumFormatMode mode)
        {
            Source = src;
            Mode = mode;
        }

        public string Format()
            => CoverFormat.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CoverFormat<E,T>(E src)
            => new CoverFormat<E,T>(src, EnumFormatMode.Default);

        [MethodImpl(Inline)]
        public static implicit operator CoverFormat<E,T>(T src)
            => new CoverFormat<E,T>(src, EnumFormatMode.Default);

        [MethodImpl(Inline)]
        public static implicit operator CoverFormat<E,T>((E src, EnumFormatMode mode) x)
            => new CoverFormat<E,T>(x.src, x.mode);

        [MethodImpl(Inline)]
        public static implicit operator CoverFormat<E,T>((T src, EnumFormatMode mode) x)
            => new CoverFormat<E,T>(x.src, x.mode);
    }
}