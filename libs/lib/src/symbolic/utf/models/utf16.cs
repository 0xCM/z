//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Utf16;

    public readonly struct utf16 : IComparable<utf16>, IEquatable<utf16>
    {
        readonly string Data;

        [MethodImpl(Inline)]
        public utf16(string src)
            => Data = src;

        string Content
        {
            [MethodImpl(Inline)]
            get => Data ?? EmptyString;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
        }

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        // public Span<char> Edit
        // {
        //     [MethodImpl(Inline)]
        //     get => edit(View);
        // }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => api.hash(this);
        }

        [MethodImpl(Inline)]
        public bool Equals(utf16 src)
            => Content.Equals(src.Content);

        [MethodImpl(Inline)]
        public string Format()
            => Data ?? EmptyString;

        public override int GetHashCode()
            => (int)Hash;

        public override string ToString()
            => Format();

        public override bool Equals(object src)
          => src is utf16 x && Equals(x);

        public int CompareTo(utf16 src)
            => Format().CompareTo(src.Format());

        public static bool operator ==(utf16 a, utf16 b)
            => a.Equals(b);

        public static bool operator !=(utf16 a, utf16 b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator utf16(string src)
            => new utf16(src);

        [MethodImpl(Inline)]
        public static implicit operator string(utf16 src)
            => src.Data;

        public static utf16 Empty
        {
            [MethodImpl(Inline)]
            get => new utf16(EmptyString);
        }
    }
}