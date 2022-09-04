//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ApiHostExtracts : IIndex<ApiMemberExtract>
    {
        public _ApiHostUri Host {get;}

        readonly Index<ApiMemberExtract> Blocks;

        [MethodImpl(Inline)]
        public ApiHostExtracts(_ApiHostUri host, Index<ApiMemberExtract> blocks)
        {
            Host = host;
            Blocks = blocks;
        }

        public ReadOnlySpan<ApiMemberExtract> View
        {
            [MethodImpl(Inline)]
            get => Blocks.View;
        }

        public ApiMemberExtract[] Storage
        {
            [MethodImpl(Inline)]
            get => Blocks.Storage;
        }

        public uint BlockCount
        {
            [MethodImpl(Inline)]
            get => Blocks.Count;
        }

        public ApiHostExtracts Sort()
        {
            Blocks.Sort();
            return this;
        }
    }
}