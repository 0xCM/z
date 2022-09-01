//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Algs;
    using static Spans;

    public readonly struct AsmEncoding<K,T> : IAsmEncoding<K,T>
        where T : unmanaged, IStorageBlock<T>
        where K : unmanaged
    {
        public readonly K Kind;

        public readonly T Data;

        [MethodImpl(Inline)]
        public AsmEncoding(K id, T data)
        {
            Kind = id;
            Data = data;
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
            get => (byte)size<T>();
        }

        public Span<byte> Buffer
        {
            [MethodImpl(Inline)]
            get => Data.Bytes;
        }

        public ref byte EncodingSize
        {
            [MethodImpl(Inline)]
            get => ref seek(Buffer, BufferSize - 1);
        }

        byte IAsmEncoding.EncodingSize
        {
            [MethodImpl(Inline)]
            get => EncodingSize;
        }

        public ReadOnlySpan<byte> Encoded
        {
            [MethodImpl(Inline)]
            get => slice(Buffer,0,EncodingSize);
        }

        [MethodImpl(Inline)]
        public AsmHexCode ToAsmHex()
            => Encoded;

        public string Format()
            => ToAsmHex().Format();

        public override string ToString()
            => Format();

        K IAsmEncoding<K,T>.Kind
            => Kind;

        [MethodImpl(Inline)]
        public static implicit operator AsmHexCode(AsmEncoding<K,T> src)
            => src.ToAsmHex();

        public static AsmEncoding<T> Empty => default;
    }
}