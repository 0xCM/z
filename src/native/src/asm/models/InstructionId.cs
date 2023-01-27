//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly record struct InstructionId : IEquatable<InstructionId>
    {
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