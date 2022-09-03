//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdId : IIdentity<CmdId>
    {
        public static CmdId identify<T>()
            => identify(typeof(T));

        [Op]
        public static CmdId identify(Type spec)
        {
            var tag = spec.Tag<CmdAttribute>();
            if(tag)
            {
                var name = tag.Value.Name;
                if(sys.empty(name))
                    return new CmdId(spec.Name);
                else
                    return new CmdId(name);
            }
            else
                return new CmdId(spec.Name);
        }

        readonly @string Data;

        [MethodImpl(Inline)]
        public CmdId(string src)
            => Data = src;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Data;

        [MethodImpl(Inline)]
        public bool Equals(CmdId src)
            => string.Equals(Data, src.Data);

        public override string ToString()
            => Format();

        public int CompareTo(CmdId src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator CmdId(Type spec)
            => identify(spec);

        [MethodImpl(Inline)]
        public static implicit operator CmdId(string name)
            =>new CmdId(name);

        public static CmdId Empty => default;
    }
}