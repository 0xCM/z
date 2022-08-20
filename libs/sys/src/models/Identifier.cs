//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a legal identifier within a given context
    /// </summary>
    public readonly record struct Identifier
    {
        readonly string Data;

        public string Content
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public Identifier(string src)
            => Data = src ?? EmptyString;

        public string Text
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(Content);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
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

        [MethodImpl(Inline)]
        public string Format()
            => Content;

        [MethodImpl(Inline)]
        public int CompareTo(Identifier src)
            => Content.CompareTo(src.Content);

        [MethodImpl(Inline)]
        public bool Equals(Identifier src)
            => Content.Equals(src.Content);

        public override string ToString()
            => Content;

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static implicit operator Identifier(string src)
            => new Identifier(src);

        [MethodImpl(Inline)]
        public static implicit operator string(Identifier src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<char>(Identifier src)
            => src.Content;

        [MethodImpl(Inline)]
        public static bool operator <(Identifier x, Identifier y)
            => x.CompareTo(y) < 0;

        [MethodImpl(Inline)]
        public static bool operator <=(Identifier x, Identifier y)
            => x.CompareTo(y) <= 0;

        [MethodImpl(Inline)]
        public static bool operator >(Identifier x, Identifier y)
            => x.CompareTo(y) > 0;

        [MethodImpl(Inline)]
        public static bool operator >=(Identifier x, Identifier y)
            => x.CompareTo(y) >= 0;

        public static Identifier Empty
        {
            [MethodImpl(Inline)]
            get => new Identifier(EmptyString);
        }
    }
}