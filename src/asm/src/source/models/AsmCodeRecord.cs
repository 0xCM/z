//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct AsmCodeRecord
    {
        public readonly uint Seq;

        public readonly uint DocSeq;

        public readonly EncodingId EncodingId;

        public readonly Hex32 OriginId;

        public readonly SourceText Asm;

        public readonly MemoryAddress IP;

        public readonly MemorySegment Encoded;

        [MethodImpl(Inline)]
        public AsmCodeRecord(EncodingId id, uint seq, uint docseq, Hex32 origin, SourceText asm, MemoryAddress ip, MemorySegment code)
        {
            Seq = seq;
            DocSeq = docseq;
            EncodingId = id;
            OriginId = origin;
            IP = ip;
            Asm = asm;
            Encoded = code;
        }

        public byte EncodingSize
        {
            [MethodImpl(Inline)]
            get => (byte)Encoded.Size;
        }

        public ReadOnlySpan<byte> Encoding
        {
            [MethodImpl(Inline)]
            get => Encoded.View;
        }

        public string Format()
        {
            var dst = text.buffer();
            dst.AppendFormat("{0,-48} # {1,-18} | {2,-12} | {3,-8} | {4,-24}", Asm, EncodingId, IP, EncodingSize, Encoded.Format());
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        public static AsmCodeRecord Empty => default;
    }
}