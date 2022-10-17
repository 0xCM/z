//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PartCodeIndexEntry
    {
        public ApiHostUri Host {get;}

        public ApiHostBlocks Code {get;}

        [MethodImpl(Inline)]
        public PartCodeIndexEntry(ApiHostUri host, in ApiHostBlocks code)
        {
            Host = host;
            Code = code;
        }
    }
}