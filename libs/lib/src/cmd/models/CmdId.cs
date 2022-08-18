//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct CmdId : IIdentity<CmdId>
    {
        readonly asci32 Data;

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
            => Cmd.identify(spec);

        [MethodImpl(Inline)]
        public static implicit operator CmdId(string name)
            =>new CmdId(name);

        public static CmdId Empty => default;
    }
}