//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    public readonly record struct ApiUri<T> : IApiUri<ApiUri<T>>
        where T : IEquatable<T>, IComparable<T>
    {
        readonly public T Value {get;}

        public string UriText
        {
            [MethodImpl(Inline)]
            get => Value?.ToString() ?? EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(UriText);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(UriText);
        }

        [MethodImpl(Inline)]
        public ApiUri(T value)
        {
            Value = value;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(UriText);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => UriText;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(ApiUri<T> src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(ApiUri<T> src)
            => Value.CompareTo(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator ApiUri<T>(T src)
            => new ApiUri<T>(src);
    }
}