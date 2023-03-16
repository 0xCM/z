//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Covers a sequence of asci-encoded bytes
    /// </summary>
    public readonly struct AsciSeq : IAsciSeq
    {
        [MethodImpl(Inline), Op]
        public static uint render(AsciSeq src, uint length, Span<char> dst)
        {
            var size = min(src.Capacity,length);
            var data = slice(src.Data.View,0,size);
            for(var i=0u; i<size; i++)
                seek(dst, i) = src[i];
            return size;
        }

        public static string format(AsciSeq src)
            => format(src.Storage.ToReadOnlySpan());

        static string format(ReadOnlySpan<byte> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            for(var i=0u; i<src.Length; i++)
                seek(dst, i) = (char)skip(src,i);
            return sys.@string(dst);
        }

        public readonly BinaryCode Data;

        public readonly uint Capacity;

        [MethodImpl(Inline)]
        public AsciSeq(BinaryCode src)
        {
            Data = src;
            Capacity = src.Size;
        }

        public ByteSize ByteCount
        {
            [MethodImpl(Inline)]
            get => Data.Size;
        }

        public BitWidth BitWidth
        {
            [MethodImpl(Inline)]
            get => Data.Width;
        }

        public byte[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public Span<AsciCode> Codes
        {
            [MethodImpl(Inline)]
            get => recover<byte,AsciCode>(Data.Edit);
        }

        public Span<AsciSymbol> Symbols
        {
            [MethodImpl(Inline)]
            get => recover<byte,AsciSymbol>(Data.Edit);
        }

        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ref AsciSymbol this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Symbols,index);
        }

        public ref AsciSymbol this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Symbols,index);
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public TextBlock Text
        {
            [MethodImpl(Inline)]
            get => Format();
        }

        int IByteSeq.Length
            => (int)Capacity;

        int IByteSeq.Capacity
            => (int)Capacity;

        public bool IsBlank
        {
            [MethodImpl(Inline)]
            get => SQ.whitespace(Codes);
        }

        public bool IsNull
        {
            [MethodImpl(Inline)]
            get => SQ.@null(Codes);
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}