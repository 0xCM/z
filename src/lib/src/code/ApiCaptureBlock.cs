//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    ///  Defines the dataset accumulated for an operation-targeted capture workflow
    /// </summary>
    public struct ApiCaptureBlock
    {
        public CodeBlock Raw;

        public CodeBlock Parsed;

        public OpUri OpUri;

        public MethodInfo Method;

        public ExtractTermCode TermCode;

        public ApiMsil Msil;

        public EcmaSig CliSig;

        public ByteSize RawSize
        {
            [MethodImpl(Inline)]
            get => Raw.Length;
        }

        public ByteSize ParsedSize
        {
            [MethodImpl(Inline)]
            get => Parsed.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Parsed.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Parsed.IsNonEmpty;
        }

        public ApiCodeBlock CodeBlock
        {
             [MethodImpl(Inline)]
             get => new ApiCodeBlock(BaseAddress, OpUri, Parsed);
        }

        public OpIdentity MemberId
        {
            [MethodImpl(Inline)]
            get => OpUri.OpId;
        }

        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Parsed.Address;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => BaseAddress.Hash;
        }

        public ulong Hash64
        {
            [MethodImpl(Inline)]
            get => BaseAddress;
        }

        [MethodImpl(Inline)]
        public bool Identical(in ApiCaptureBlock src)
            => Parsed.Equals(src.Parsed);

        [MethodImpl(Inline), Ignore]
        public int Compare(in ApiCaptureBlock src)
            => BaseAddress.CompareTo(src.BaseAddress);

        [Ignore]
        public string Format()
            => Parsed.Format();


        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is ApiCaptureBlock x && Identical(x);

        public static ApiCaptureBlock Empty
            => default;
    }
}