//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    using api = Utf16;

    public unsafe readonly struct utf16p : IEquatable<utf16p>, IComparable<utf16p>
    {
        internal readonly char* pData;

        [MethodImpl(Inline)]
        public utf16p(char* pSrc)
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

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => cover(pData, Size);
        }

        public Span<char> Edit
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
            => text.format(View);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(utf16p src)
            => pData == src.pData;

        public override bool Equals(object src)
            => src is utf16p x && Equals(x);

        [MethodImpl(Inline)]
        public int CompareTo(utf16p src)
            => Address.CompareTo(src.Address);

        [MethodImpl(Inline)]
        public static implicit operator utf16p(char* pSrc)
            => new utf16p(pSrc);

        [MethodImpl(Inline)]
        public static implicit operator utf16p(MemoryAddress src)
            => new utf16p(src.Pointer<char>());
    }
}