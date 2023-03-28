//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ArgPrefix : IDataType<ArgPrefix>
    {
        [MethodImpl(Inline), Op]
        public static ArgPrefix prefix(string src)
            => new ArgPrefix(src);

        readonly @string Spec;

        [MethodImpl(Inline)]
        public ArgPrefix(string src)
        {
            Spec = src;
        }

        [MethodImpl(Inline)]
        public ArgPrefix(params AsciCode[] src)
        {
            Spec = sys.@string(src.Map(x => (char)x));
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