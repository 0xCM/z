//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ResourceName : IComparable<ResourceName>
    {
        readonly string Data;

        [MethodImpl(Inline)]
        public ResourceName(string src)
            => Data = src;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Algs.hash(Data);
        }

        public bool Equals(ResourceName src)
            => Data == src.Data;

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Data;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(ResourceName src)
            => Data.CompareTo(src.Data);
    }
}