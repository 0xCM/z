//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AsmCodeBlock
    {
        public readonly LocatedSymbol Label;

        public readonly Index<AsmCodeRecord> Code;

        public readonly ByteSize Size;

        [MethodImpl(Inline)]
        public AsmCodeBlock(LocatedSymbol label, AsmCodeRecord[] src)
        {
            Label = label;
            Code = src;
            Size = src.Select(x => (uint)x.EncodingSize).Sum();
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Code.Count;
        }

        public ref readonly AsmCodeRecord this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Code[i];
        }

        public ref readonly AsmCodeRecord this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Code[i];
        }
    }
}