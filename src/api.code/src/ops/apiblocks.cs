//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCode
    {
        [MethodImpl(Inline), Op]
        public static ApiCodeBlock apiblock(ApiCodeRow src)
            => new ApiCodeBlock(src.Address, src.Uri, src.Data);
            
        [Op]
        public static ReadOnlySeq<ApiHostBlocks> apiblocks(FolderPath src, ReadOnlySpan<_ApiHostUri> hosts)
        {
            var dst = bag<ApiHostBlocks>();
            iter(hosts, host => dst.Add(apiblocks(host, src + host.FileName(FileKind.Csv))), AppData.get().PllExec());
            return dst.ToIndex();
        }

        [Op]
        public static ApiHostBlocks apiblocks(_ApiHostUri host, FilePath src)
            => new ApiHostBlocks(host, apiblocks(src));

        [Op]
        public static SortedIndex<ApiCodeBlock> apiblocks(IApiPack src, bool pll = true)
            => apicode(src.HexExtracts(), pll);

        [Op]
        public static Index<ApiCodeBlock> apiblocks(FilePath src)
        {
            var rows = apirows(src);
            var count = rows.Count;
            var dst = sys.alloc<ApiCodeBlock>(count);
            for(var j=0; j<count; j++)
                seek(dst,j) = apiblock(rows[j]);
            return dst;
        }
    }
}