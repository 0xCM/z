//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Represents a legal identifier
    /// </summary>
    public readonly struct Identifier<T> : IIdentifier<Identifier<T>,T>
        where T : IComparable<T>
    {
        public T Value {get;}

        [MethodImpl(Inline)]
        public Identifier(T src)
            => Value = src;

        public string Content
        {
            [MethodImpl(Inline)]
            get => Value?.ToString() ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        public override string ToString()
            => Format();

        public bool Equals(Identifier<T> src)
            => Content.Equals(src.Content);
        public int CompareTo(Identifier<T> other)
            => Value?.CompareTo(other.Value) ?? 0;

        [MethodImpl(Inline)]
        public static implicit operator Identifier<T>(T src)
            => new Identifier<T>(src);
    }
}