//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct InstructionId : IEquatable<InstructionId>
    {
        public static bool parse(ReadOnlySpan<char> src, out InstructionId dst)
        {
            var input = text.trim(src);
            dst = InstructionId.Empty;
            if(input.Length != 24)
                return false;
            var x0 = slice(input,0,8);
            var result = HexParser.parse(x0, out Hex32 docid);
            if(!result)
                return result;

            var x1 = slice(input,8,16);
            result = HexParser.parse(x1, out Hex64 encid);
            if(!result)
                return result;

            dst = new InstructionId(docid, encid);
            return true;
        }

        [MethodImpl(Inline), Op]
        public static InstructionId define(Hex32 docid, MemoryAddress ip, ReadOnlySpan<byte> encoding)
            => new InstructionId(docid, EncodingId.from(ip, encoding));

        public readonly Hex32 DocId;

        public readonly EncodingId EncodingId;

        [MethodImpl(Inline)]
        public InstructionId(Hex32 doc, EncodingId encoding)
        {
            DocId = doc;
            EncodingId = encoding;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => EncodingId.Hash | (Hash32)DocId;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(InstructionId src)
            => DocId == src.DocId && EncodingId == src.EncodingId;

        public string Format()
            => string.Format("{0:x8}{1:x16}", (uint)DocId, (ulong)EncodingId);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator InstructionId((Hex32 docid, EncodingId enc) src)
            => new InstructionId(src.docid, src.enc);

        public static InstructionId Empty => default;
    }
}