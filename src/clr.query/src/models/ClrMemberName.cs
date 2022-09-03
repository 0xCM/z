//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Defines the name of a member
    /// </summary>
    public readonly struct ClrMemberName : IEquatable<ClrMemberName>, IComparable<ClrMemberName>
    {
        public @string Name {get;}

        [MethodImpl(Inline)]
        public ClrMemberName(MemberInfo src)
            => Name = src.Name.Replace(Chars.Pipe, (char)SymNotKind.Chi);

        [MethodImpl(Inline)]
        public ClrMemberName(string src)
            => Name = (src ?? EmptyString).Replace(Chars.Pipe, (char)SymNotKind.Chi);

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Name.GetHashCode();
        }

        public Count Count
        {
            [MethodImpl(Inline)]
            get => Name.Length;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Name.Length;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length * sizeof(char);
        }

        [MethodImpl(Inline), Ignore]
        public int CompareTo(ClrMemberName src)
            => compare(Name, src.Name);

        [MethodImpl(Inline), Ignore]
        public bool Equals(ClrMemberName src)
            => string.Equals(Name, src.Name);

        [MethodImpl(Inline)]
        public string Format()
            => Name;

        public override string ToString()
            => Name;

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is ClrMemberName n && Equals(n);

        [MethodImpl(Inline)]
        public static implicit operator string(ClrMemberName src)
            => src.Name;

        [MethodImpl(Inline)]
        public static implicit operator ClrMemberName(FieldInfo src)
            => new ClrMemberName(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrMemberName(PropertyInfo src)
            => new ClrMemberName(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrMemberName(EventInfo src)
            => new ClrMemberName(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrMemberName(MethodInfo src)
            => new ClrMemberName(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrMemberName(MemberInfo src)
            => new ClrMemberName(src);

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<char>(ClrMemberName src)
            => src.Name;

        [MethodImpl(Inline)]
        public static bool operator <(ClrMemberName x, ClrMemberName y)
            => x.CompareTo(y) < 0;

        [MethodImpl(Inline)]
        public static bool operator <=(ClrMemberName x, ClrMemberName y)
            => x.CompareTo(y) <= 0;

        [MethodImpl(Inline)]
        public static bool operator >(ClrMemberName x, ClrMemberName y)
            => x.CompareTo(y) > 0;

        [MethodImpl(Inline)]
        public static bool operator >=(ClrMemberName x, ClrMemberName y)
            => x.CompareTo(y) >= 0;

        [MethodImpl(Inline)]
        public static bool operator ==(ClrMemberName x, ClrMemberName y)
            => x.Equals(y);

        [MethodImpl(Inline)]
        public static bool operator !=(ClrMemberName x, ClrMemberName y)
            => !x.Equals(y);

        [MethodImpl(Inline), Op]
        public static int compare(string a, string b)
        {
            if(a == null || b == null)
                return 0;

            var result = 0;
            ref readonly var x = ref first(a);
            ref readonly var y = ref first(b);
            var count = min(a.Length, b.Length);
            for(var i=0u; i<count; i++)
            {
                ref readonly var cx = ref skip(x, i);
                ref readonly var cy = ref skip(y, i);
                if(cx == cy)
                    continue;
                else
                    return cx.CompareTo(cy);
            }
            return result;
        }
    }
}