//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Sized;

    public readonly record struct Mb : IDataString<Mb>
    {
        public const string UOM = "mb";

        public readonly ulong Count;

        [MethodImpl(Inline)]
        public Mb(ulong src)
        {
            Count = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Count == 0;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => api.size(this);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Count.GetHashCode();
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Mb src)
            => Count == src.Count;

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(Mb src)
            => Count.CompareTo(src.Count);

        [MethodImpl(Inline)]
        public static implicit operator ulong(Mb src)
            => src.Count;
    }
}