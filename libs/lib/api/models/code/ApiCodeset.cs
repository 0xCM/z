//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiCodeset
    {
        [MethodImpl(Inline)]
        public static ApiCodeset create(FS.FilePath location, Index<ApiCodeBlock> blocks)
            => new ApiCodeset(location, blocks);

        public FS.FilePath Location {get;}

        public Index<ApiCodeBlock> Blocks {get;}

        [MethodImpl(Inline)]
        public ApiCodeset(FS.FilePath location, Index<ApiCodeBlock> rows)
        {
            Location = location;
            Blocks = rows;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Location.IsEmpty || Blocks.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public static ApiCodeset Empty
        {
            [MethodImpl(Inline)]
            get => new ApiCodeset(FS.FilePath.Empty, sys.empty<ApiCodeBlock>());
        }
    }
}