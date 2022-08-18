//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    using api = Utf8;

    public unsafe readonly struct utf8p : IEquatable<utf8p>, IComparable<utf8p>
    {
        internal readonly byte* pData;

        [MethodImpl(Inline)]
        public utf8p(byte* pSrc)
        {
            pData = pSrc;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => api.size(this);
        }

        public MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => pData;
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => cover(pData, Size);
        }

        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => cover(pData, Size);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => !IsNonEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => api.nonempty(this);
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => api.hash(this);
        }


        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => api.decode(View, out string dst);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(utf8p src)
            => pData == src.pData;

        public override bool Equals(object src)
            => src is utf8p x && Equals(x);

        [MethodImpl(Inline)]
        public int CompareTo(utf8p src)
            => Address.CompareTo(src.Address);

        [MethodImpl(Inline)]
        public static implicit operator utf8p(byte* pSrc)
            => new utf8p(pSrc);

        [MethodImpl(Inline)]
        public static implicit operator utf8p(MemoryAddress src)
            => new utf8p(src.Pointer<byte>());
    }
}