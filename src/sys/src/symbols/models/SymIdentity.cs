//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct SymIdentity : IComparable<SymIdentity>, IEquatable<SymIdentity>
    {
        readonly string Data;

        [MethodImpl(Inline)]
        public SymIdentity(string src)
            => Data = src ?? EmptyString;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => empty(Data);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Data);
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

        public Count Count
        {
            [MethodImpl(Inline)]
            get => Content.Length;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Content.Length;
        }

        [MethodImpl(Inline)]
        public int CompareTo(SymIdentity src)
            => string.Compare(Content, src.Content);

        [MethodImpl(Inline)]
        public bool Equals(SymIdentity src)
            => string.Equals(Data, src.Data);


        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is SymIdentity n && Equals(n);

        [MethodImpl(Inline)]
        public static implicit operator SymIdentity(string src)
            => new SymIdentity(src);

        [MethodImpl(Inline)]
        public static implicit operator string(SymIdentity src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<char>(SymIdentity src)
            => src.Content;

        [MethodImpl(Inline)]
        public static bool operator <(SymIdentity x, SymIdentity y)
            => x.CompareTo(y) < 0;

        [MethodImpl(Inline)]
        public static bool operator <=(SymIdentity x, SymIdentity y)
            => x.CompareTo(y) <= 0;

        [MethodImpl(Inline)]
        public static bool operator >(SymIdentity x, SymIdentity y)
            => x.CompareTo(y) > 0;

        [MethodImpl(Inline)]
        public static bool operator >=(SymIdentity x, SymIdentity y)
            => x.CompareTo(y) >= 0;

        [MethodImpl(Inline)]
        public static bool operator ==(SymIdentity x, SymIdentity y)
            => x.Data == y.Data;

        [MethodImpl(Inline)]
        public static bool operator !=(SymIdentity x, SymIdentity y)
            => x.Data != y.Data;

        public static SymIdentity Empty
        {
            [MethodImpl(Inline)]
            get => new SymIdentity(EmptyString);
        }
    }
}