//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// The hex bits found at the end of a uri
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ApiCodeBlock : IComparable<ApiCodeBlock>
    {
        /// <summary>
        /// The operation uri
        /// </summary>
        public readonly OpUri OpUri;

        /// <summary>
        /// The encoded operation data
        /// </summary>
        public readonly CodeBlock Code;

        [MethodImpl(Inline)]
        public ApiCodeBlock(MemoryAddress @base, OpUri uri, BinaryCode src)
        {
            OpUri = uri;
            Code = new CodeBlock(@base, src);
        }

        [MethodImpl(Inline)]
        public ApiCodeBlock(OpUri uri, in CodeBlock code)
        {
            OpUri = uri;
            Code = code;
        }

        public ApiHostUri HostUri
        {
            [MethodImpl(Inline)]
            get => OpUri.Host;
        }

        public PartId Part
        {
            [MethodImpl(Inline)]
            get => OpUri.Part;
        }

        [MethodImpl(Inline)]
        public bool StartsWith(byte src)
            => Code.IsNonEmpty ? Code[0] == src : false;

        public byte[] Storage
        {
            [MethodImpl(Inline)]
            get => Code.Storage;
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Code.Storage;
        }

        /// <summary>
        /// The code's base address
        /// </summary>
        public MemoryAddress BaseAddress
        {
             [MethodImpl(Inline)]
             get => Code.Address;
        }

        public MemoryRange AddressRange
        {
            [MethodImpl(Inline)]
            get => new MemoryRange(BaseAddress, (ByteSize)Length);
        }

        public OpIdentity OpId
        {
             [MethodImpl(Inline)]
             get => OpUri.OpId;
        }

        /// <summary>
        /// The encoded operation data
        /// </summary>
        public readonly BinaryCode Encoded
        {
            [MethodImpl(Inline)]
            get => Code;
        }

        public byte[] Data
        {
            [MethodImpl(Inline)]
            get => Encoded.Storage;
        }

        public uint Size
        {
            [MethodImpl(Inline)]
            get => (uint)Encoded.Length;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Encoded.Length;
        }

        public ref readonly byte this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Encoded[index];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Encoded.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Encoded.IsNonEmpty;
        }

        /// <summary>
        /// The identifier of the defined operation
        /// </summary>
        public OpIdentity Id
        {
            [MethodImpl(Inline)]
            get => OpUri.OpId;
        }

        [MethodImpl(Inline)]
        public bool Equals(ApiCodeBlock src)
            => Encoded.Equals(src.Encoded);

        public override int GetHashCode()
            => OpUri.GetHashCode();

        public string Format(int uripad)
            => string.Concat(BaseAddress.Format(), Space, OpUri.UriText.PadRight(uripad), Space, Encoded.Format());

        public string Format()
            => Format(60);


        public override string ToString()
            => Format();

        public int CompareTo(ApiCodeBlock src)
            => BaseAddress.CompareTo(src.BaseAddress);

        [MethodImpl(Inline)]
        public static implicit operator BinaryCode(ApiCodeBlock src)
            => src.Code;

        [MethodImpl(Inline)]
        public static implicit operator CodeBlock(ApiCodeBlock src)
            => src.Code;

        /// <summary>
        /// No code, no identity, no life
        /// </summary>
        public static ApiCodeBlock Empty
        {
            [MethodImpl(Inline)]
            get => new ApiCodeBlock(MemoryAddress.Zero, OpUri.Empty, BinaryCode.Empty);
        }
    }
}