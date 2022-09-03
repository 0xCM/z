//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly record struct AsmCodeBlock
    {
        public readonly LocatedSymbol Label;

        public readonly Index<AsmCode> Code;

        public readonly ByteSize Size;

        [MethodImpl(Inline)]
        public AsmCodeBlock(LocatedSymbol label, AsmCode[] src)
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

        public ref readonly AsmCode this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Code[i];
        }

        public ref readonly AsmCode this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Code[i];
        }
    }
}