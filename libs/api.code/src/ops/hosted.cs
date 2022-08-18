//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCode
    {
        [Op]
        public static ReadOnlySpan<ApiHostBlocks> hosted(ReadOnlySpan<ApiCodeBlock> src)
            => hosted(src.ToArray());

        [Op]
        static ReadOnlySpan<ApiHostBlocks> hosted(Index<ApiCodeBlock> src)
        {
            if(src.IsEmpty)
                return array<ApiHostBlocks>();
            else
            {
                var keyed = src.Storage.Where(x => x.HostUri.IsNonEmpty).Select(x => (x.HostUri, x)).ToReadOnlySpan();
                var count = keyed.Length;
                var dst = dict<ApiHostUri,List<ApiCodeBlock>>();
                for(var i=0; i<count; i++)
                {
                    ref readonly var code = ref skip(keyed,i);
                    if(dst.TryGetValue(code.HostUri, out var blocks))
                        blocks.Add(code.x);
                    else
                    {
                        var target = list<ApiCodeBlock>();
                        target.Add(code.x);
                        dst.Add(code.HostUri, target);
                    }
                }
                return dst.Map(x => new ApiHostBlocks(x.Key, x.Value.ToArray()));
            }
        }
    }
}