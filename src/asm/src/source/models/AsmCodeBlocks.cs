//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AsmCodeBlocks : IIndex<AsmCodeBlock>
    {
        readonly Index<AsmCodeBlock> Data;

        public readonly Hex32 OriginId;

        public readonly Label OriginName;

        public readonly uint LineCount;

        public AsmCodeBlocks(Label name, Hex32 id, AsmCodeBlock[] data)
        {
            Data = data;
            OriginName = name;
            OriginId = id;
            LineCount = data.Select(x => x.Count).Sum();
        }

        public AsmCodeBlock[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Span<AsmCodeBlock> Edit
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ReadOnlySpan<AsmCodeBlock> View
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref AsmCodeBlock this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref AsmCodeBlock this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmCodeBlock[](AsmCodeBlocks src)
            => src.Data;

        public static AsmCodeBlocks Empty => new AsmCodeBlocks(Label.Empty, 0, sys.empty<AsmCodeBlock>());
    }
}