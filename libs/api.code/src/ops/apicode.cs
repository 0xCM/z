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
        public static ApiCodeRow apicode(in MemberCodeBlock src, uint seq)
        {
            var dst = ApiCodeRow.Empty;
            dst.Seq = seq;
            dst.SourceSeq = src.Sequence;
            dst.Address = src.Address;
            dst.CodeSize = src.Encoded.Size;
            dst.Uri = src.OpUri;
            dst.Data = src.Encoded;
            return dst;
        }

        [Op]
        public static SortedIndex<ApiCodeBlock> apicode(FS.Files src, bool pll = true)
        {
            var dst = bag<ApiCodeBlock>();
            iter(src, file => iter(apirows(file), row => dst.Add(apiblock(row))), pll);
            return SortedIndex<ApiCodeBlock>.sort(dst.Array());
        }
    }
}