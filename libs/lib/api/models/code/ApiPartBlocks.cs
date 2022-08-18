//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiPartBlocks : IIndex<ApiHostBlocks>
    {
        public readonly PartId PartId;

        public readonly Index<ApiHostBlocks> Blocks;

        [MethodImpl(Inline)]
        public ApiPartBlocks(PartId part, Index<ApiHostBlocks> blocks)
        {
            PartId = part;
            Blocks = blocks;
        }

        public ApiHostBlocks[] Storage
        {
            [MethodImpl(Inline)]
            get => Blocks.Storage;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Blocks.Count;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Blocks.Length;
        }

        public ReadOnlySpan<ApiHostBlocks> View
        {
            [MethodImpl(Inline)]
            get => Blocks.View;
        }
    }
}