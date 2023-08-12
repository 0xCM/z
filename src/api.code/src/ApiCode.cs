//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost("api")]
    public partial class ApiCode
    {
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

        // [Op]
        // public static unsafe ApiMemberExtract extract(in ResolvedMethod src, Span<byte> buffer)
        // {
        //     var size = Bytes.readz(MaxZeroCount, src.EntryPoint, buffer);
        //     var block = new ApiExtractBlock(src.EntryPoint, src.Uri.Format(), slice(buffer,0, size).ToArray());
        //     return new ApiMemberExtract(member(src), block);
        // }

        [Op]
        public static MethodEntryPoint entries(MethodInfo src)
            => new (ClrJit.jit(src), src.Uri(), src.DisplaySig().Format());

        [Op]
        public static MethodEntryPoint entries(ApiMember src)
            => new (src.BaseAddress, src.Method.Uri(), src.Method.DisplaySig().Format());

        [Op]
        public static Index<MethodEntryPoint> entries(ApiMembers src)
        {
            var count = src.Length;
            var buffer = alloc<MethodEntryPoint>(count);
            ref var dst = ref first(buffer);
            var view = src.View;
            for(var i=0; i<count; i++)
                seek(dst,i) = entries(skip(view,i));
            return buffer;
        }

         [Op]
         public static ApiToken token(ISymbolDispenser symbols, in MethodEntryPoint entry, MemoryAddress target)
            => new ApiToken(
                symbols.Symbol(entry.Location, entry.Uri?.Format() ?? EmptyString),
                symbols.Symbol(target, entry.Sig.Format()));

        [Op]
        public static ApiToken token(ISymbolDispenser symbols, in MethodEntryPoint entry)
            => new ApiToken(
                symbols.Symbol(entry.Location, text.ifempty(entry.Uri.Format(), EmptyString)),
                symbols.Symbol(entry.Location, entry.Sig.Format())
                );
        [Op]
        public static ApiMember member(in ResolvedMethod src)
            => new (src.Uri, src.Method, src.EntryPoint, ClrDynamic.msil(src.EntryPoint, src.Uri, src.Method));


        [Op]
        public static ReadOnlySeq<ApiEncoded> collect(IWfChannel channel, Assembly src, ICompositeDispenser symbols)
            => gather(channel, entries(ClrJit.jit(ApiCatalog.catalog(src), channel)), symbols);

        [Op]
        public static ReadOnlySeq<ApiEncoded> collect(IWfChannel channel, IPart src, ICompositeDispenser symbols)
            => collect(channel, src.Owner, symbols);

        [Op]
        public static ApiHostRes hostres(ApiHostBlocks src)
        {
            var count = src.Length;
            var buffer = alloc<BinaryResSpec>(count);
            var dst = span(buffer);
            var blocks = src.Blocks.View;
            for(var i=0u; i<count; i++)
            {
                ref readonly var code = ref skip(blocks,i);
                seek(dst,i) = new BinaryResSpec(LegalIdentityBuilder.code(code.Id), code.Encoded);
            }
            return new ApiHostRes(src.Host, buffer);
        }        

        static bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.get().PllExec();
        }

        [MethodImpl(Inline), Op]
        public static ApiCodeParser parser(byte[] buffer)
            => new (EncodingPatterns.Default, buffer);        

        // [Op]
        // public static ReadOnlySeq<ApiHostBlocks> apiblocks(FolderPath src, ReadOnlySpan<ApiHostUri> hosts)
        // {
        //     var dst = bag<ApiHostBlocks>();
        //     iter(hosts, host => dst.Add(apiblocks(host, src + FS.hostfile(host,FileKind.Csv))), AppData.get().PllExec());
        //     return dst.ToIndex();
        // }

        // [Op]
        // public static ApiHostBlocks apiblocks(ApiHostUri host, FilePath src)
        //     => new (host, apiblocks(src));


        // [Op]
        // public static Index<ApiCodeBlock> apiblocks(FilePath src)
        // {
        //     var rows = apirows(src);
        //     var count = rows.Count;
        //     var dst = sys.alloc<ApiCodeBlock>(count);
        //     for(var j=0; j<count; j++)
        //         seek(dst,j) = apiblock(rows[j]);
        //     return dst;
        // }            
    }
}