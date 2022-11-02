//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly record struct ArgPrefix : IDataType<ArgPrefix>
    {
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(string src)
            => prefix(chars(src));

        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(ReadOnlySpan<char> src)
            => new ArgPrefix(src);

        readonly asci8 Spec;

        [MethodImpl(Inline)]
        internal ArgPrefix(ReadOnlySpan<char> src)
        {
            Spec = src;
        }

        [MethodImpl(Inline)]
        internal ArgPrefix(AsciCode c0)
        {
            Spec = new(c0);
        }

        [MethodImpl(Inline)]
        internal ArgPrefix(AsciCode c0, AsciCode c1)
        {
            Spec=new(c0, c1);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Spec.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Spec.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Spec.Hash;
        }

        public byte Length
        {
            [MethodImpl(Inline)]
            get => (byte)Spec.Length;
        }

        public bool Equals(ArgPrefix src)
            => Spec == src.Spec;

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Spec.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(ArgPrefix src)
            => Spec.CompareTo(src.Spec);

        [MethodImpl(Inline)]
        public static implicit operator string(ArgPrefix src)
            => src.Format();

        [MethodImpl(Inline)]
        public static implicit operator ArgPrefix(string src)
            => prefix(src);

        public static ArgPrefix Empty
            => default;

        public static ArgPrefix DoubleDash
            => new ArgPrefix(AsciCode.Dash, AsciCode.Dash);

        public static ArgPrefix Dash
            => new ArgPrefix(AsciCode.Dash);

        public static ArgPrefix FSlash
            => new ArgPrefix(AsciCode.FS);

        public static ArgPrefix Space
            => new ArgPrefix(AsciCode.Space);

        public static ArgPrefix Default
            => DoubleDash;
    }
}