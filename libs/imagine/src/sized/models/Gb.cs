//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Sized;

    public readonly record struct Gb : IDataString<Gb>
    {
        public const string UOM = "gb";

        public readonly ulong Count;

        [MethodImpl(Inline)]
        public Gb(ulong src)
        {
            Count = src;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => api.size(this);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Size == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Size != 0;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Algs.hash(Size);
        }

        [MethodImpl(Inline)]
        public int CompareTo(Gb src)
            => Size.CompareTo(src.Size);

        public string Format()
            => string.Format("{0} {1}", Count != 0 ? Count.ToString("#,#") : "0", UOM);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Gb src)
            => Count == src.Count;

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public static implicit operator ulong(Gb src)
            => src.Count;
    }
}