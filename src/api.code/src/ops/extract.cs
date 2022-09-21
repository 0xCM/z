//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCode
    {
        const int MaxZeroCount = 10;

        [Op]
        public static unsafe Index<ApiMemberExtract> extract(ReadOnlySpan<ApiMember> src, Span<byte> buffer)
        {
            var count = src.Length;
            var dst = alloc<ApiMemberExtract>(count);
            ref var target = ref first(dst);
            for(var i=0u; i<count; i++)
                seek(target, i) = extract(skip(src, i), sys.clear(buffer));
            return dst;
        }

        [Op]
        public static unsafe ApiMemberExtract extract(ApiMember src, Span<byte> buffer)
        {
            var @base = src.BaseAddress;
            var size = Bytes.readz(MaxZeroCount, @base, buffer);
            var extracted = sys.array(slice(buffer,0,size));
            return new ApiMemberExtract(src, new ApiExtractBlock(@base, src.OpUri.Format(), extracted));
        }

        [Op]
        public static unsafe ApiMemberExtract extract(in ResolvedMethod src, Span<byte> buffer)
        {
            var size = Bytes.readz(MaxZeroCount, src.EntryPoint, buffer);
            var block = new ApiExtractBlock(src.EntryPoint, src.Uri.Format(), slice(buffer,0, size).ToArray());
            return new ApiMemberExtract(member(src), block);
        }
    }
}