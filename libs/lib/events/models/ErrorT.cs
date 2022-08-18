//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Error<E>
    {
        [MethodImpl(Inline)]
        public static Error<E> define(E src)
            => new Error<E>(src);

        public readonly bool IsEmpty;

        public readonly E Content;

        [MethodImpl(Inline)]
        public Error(E src)
        {
            Content = src;
            IsEmpty = src != null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
            => text.ifempty(Content?.ToString(), $"<!!{Null.Empty}!!>");

        public override string ToString()
            => Format();

        public static implicit operator Error<E>(E src)
            => new Error<E>(src);

        public static Error<E> Empty => new Error<E>(default(E));
    }
}