//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Spans;

    public struct And16ri8 : IAsmEncoding<And16ri8>
    {
        ByteBlock8 Data;

        public AsmId Id => AsmId.AND16ri8;

        public Span<byte> Buffer
        {
            [MethodImpl(Inline)]
            get => Data.Bytes;
        }

        public ReadOnlySpan<byte> Encoded
        {
            [MethodImpl(Inline)]
            get => slice(Buffer,0,EncodingSize);
        }

        byte IAsmEncoding.EncodingSize
        {
            [MethodImpl(Inline)]
            get => EncodingSize;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => EncodingSize == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => EncodingSize != 0;
        }

        public byte BufferSize
        {
            [MethodImpl(Inline)]
            get => (byte)Data.Bytes.Length;
        }

        public ref byte EncodingSize
        {
            [MethodImpl(Inline)]
            get => ref seek(Buffer, BufferSize - 1);
        }

        [MethodImpl(Inline)]
        public AsmHexCode ToAsmHex()
            => Encoded;
        public string Format()
            => ToAsmHex().Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(And16ri8 src)
            => (ulong)Data == (ulong)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator AsmEncoding<AsmId,ByteBlock8>(And16ri8 src)
            => new AsmEncoding<AsmId,ByteBlock8>(src.Id, src.Data);

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(And16ri8 src)
            => src.ToAsmHex();

        public static And16ri8 Empty => default;
    }
}