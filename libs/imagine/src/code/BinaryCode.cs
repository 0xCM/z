//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Arrays;
    using static Algs;

    public readonly record struct BinaryCode : IDataType<BinaryCode>
    {
        /// <summary>
        /// The encoded bytes
        /// </summary>
        readonly byte[] Data;

        [MethodImpl(Inline)]
        public BinaryCode(byte[] bytes)
            => Data = bytes;

        public byte[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref byte First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        public ref byte Last
        {
            [MethodImpl(Inline)]
            get => ref seek(Data, Length - 1);
        }

        /// <summary>
        /// Covers the encoded content with a readonly span
        /// </summary>
        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        /// <summary>
        /// Covers the encoded content with a span
        /// </summary>
        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => hash(Data);
        }
        public int Length
        {
            [MethodImpl(Inline)]
            get => Data?.Length ?? 0;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Length*8;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => (uint)Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => (Length == 0 ) || (Length == 1 && Data[0] == 0);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public ref byte this[long index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data,index);
        }

        public ref byte this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Data,index);
        }

        [MethodImpl(Inline)]
        public bool Equals(BinaryCode src)
            => equals(this, src);

        public string Format()
            => FormatThisX.format(View, HexOptionData.HexDataOptions);

        public string Format(HexFormatOptions config)
            => FormatThisX.format(View, config);


        public override int GetHashCode()
            => Hash;

        public override string ToString()
            => Format();

        public int CompareTo(BinaryCode src)
            => View.SequenceCompareTo(src.View);

        [MethodImpl(Inline)]
        public static implicit operator BinaryCode(Span<byte> src)
            => new BinaryCode(src.ToArray());

        [MethodImpl(Inline)]
        public static implicit operator byte[](BinaryCode src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator BinaryCode(byte[] src)
            => new BinaryCode(src);

        [MethodImpl(Inline)]
        public static implicit operator ReadOnlySpan<byte>(BinaryCode src)
            => src.Data;

        [Op]
        public static bool equals(BinaryCode a, BinaryCode b)
        {
            if(a.IsNonEmpty && b.IsNonEmpty)
                return a.View.SequenceEqual(b.View);
            else
            {
                if(a.Length == 0 && a.Length == 0)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// The canonical zero
        /// </summary>
        public static BinaryCode Empty
            => new BinaryCode(sys.empty<byte>());
    }
}