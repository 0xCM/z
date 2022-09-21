//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a sequence of <see cref='MemberCodeBlock'/> records
    /// </summary>
    public readonly struct ApiMemberBlocks : IIndex<MemberCodeBlock>
    {
        readonly Index<MemberCodeBlock> Data;

        [MethodImpl(Inline)]
        public ApiMemberBlocks(MemberCodeBlock[] src)
            => Data = src;

        public ReadOnlySpan<MemberCodeBlock> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public Span<MemberCodeBlock> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ref MemberCodeBlock First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public MemberCodeBlock[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref MemberCodeBlock this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ApiMemberBlocks Filter(ApiClassKind @class)
            => Data.Where(b => b.Member.ApiClass == @class);

        [MethodImpl(Inline)]
        public static implicit operator ApiMemberBlocks(MemberCodeBlock[] src)
            => new ApiMemberBlocks(src);

        [MethodImpl(Inline)]
        public static implicit operator ApiMemberBlocks(Index<MemberCodeBlock> src)
            => new ApiMemberBlocks(src);

        [MethodImpl(Inline)]
        public static implicit operator MemberCodeBlock[](ApiMemberBlocks src)
            => src.Storage;

        public static ApiMemberBlocks Empty
        {
            [MethodImpl(Inline)]
            get => new ApiMemberBlocks(sys.empty<MemberCodeBlock>());
        }
    }
}