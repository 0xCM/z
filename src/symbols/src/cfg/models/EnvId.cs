//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct EnvId : IDataType<EnvId>, IDataString
    {
        public readonly @string Data;

        [MethodImpl(Inline)]
        public EnvId(string data)
        {
            Data = data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Data.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(EnvId src)
            => Data.Equals(src.Data);

        [MethodImpl(Inline)]
        public int CompareTo(EnvId src)
            => Data.CompareTo(src.Data);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EnvId(string src)
            => new EnvId(src);

        [MethodImpl(Inline)]
        public static implicit operator EnvId(@string src)
            => new EnvId(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator EnvId(Identifier src)
            => new EnvId(src.Content);

        [MethodImpl(Inline)]
        public static implicit operator string(EnvId src)
            => src.Data;

        public static EnvId Empty => new(EmptyString);
    }
}