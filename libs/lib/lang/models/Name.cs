//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NameOld : IComparable<NameOld>, IEquatable<NameOld>
    {
        readonly string Data;

        [MethodImpl(Inline)]
        public NameOld(string src)
            => Data = src ?? EmptyString;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => string.IsNullOrEmpty(Data);
        }

        public string Text
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Content
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Content.GetHashCode();
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Content.Length;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
        }

        [MethodImpl(Inline)]
        public int CompareTo(NameOld src)
            => Content.CompareTo(src.Content);

        [MethodImpl(Inline)]
        public bool Equals(NameOld src)
            => string.Equals(Data, src.Data);


        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is NameOld n && Equals(n);

        [MethodImpl(Inline)]
        public static implicit operator NameOld(string src)
            => new NameOld(src);

        [MethodImpl(Inline)]
        public static implicit operator string(NameOld src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<char>(NameOld src)
            => src.Content;

        [MethodImpl(Inline)]
        public static bool operator <(NameOld x, NameOld y)
            => x.CompareTo(y) < 0;

        [MethodImpl(Inline)]
        public static bool operator <=(NameOld x, NameOld y)
            => x.CompareTo(y) <= 0;

        [MethodImpl(Inline)]
        public static bool operator >(NameOld x, NameOld y)
            => x.CompareTo(y) > 0;

        [MethodImpl(Inline)]
        public static bool operator >=(NameOld x, NameOld y)
            => x.CompareTo(y) >= 0;

        [MethodImpl(Inline)]
        public static bool operator ==(NameOld x, NameOld y)
            => x.Data == y.Data;

        [MethodImpl(Inline)]
        public static bool operator !=(NameOld x, NameOld y)
            => x.Data != y.Data;

        public static NameOld Empty
        {
            [MethodImpl(Inline)]
            get => new NameOld(EmptyString);
        }
    }
}