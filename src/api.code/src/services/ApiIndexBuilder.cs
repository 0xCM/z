//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    public class ApiIndexBuilder : AppService<ApiIndexBuilder>
    {
        public ApiBlockIndex Product;

        public ApiIndexStatus IndexStatus;

        Dictionary<MemoryAddress,ApiCodeBlock> CodeAddress;

        Dictionary<MemoryAddress,_OpUri> AddressUri;

        ApiCodeLookup UriCode;

        public static ReadOnlySpan<ApiCodeRow> ReadRows(FilePath src)
        {
            var data = src.ReadLines().Storage.ToReadOnlySpan();
            var count = data.Length - 1;
            var dst = alloc<ApiCodeRow>(count);
            for(var i=0; i<count; i++)
            {
                var result = ApiCode.parse(skip(data, i + 1), out seek(dst,i));
                if(result.Fail)
                    Errors.Throw(string.Format("{0}:{1}", src.ToUri(), result.Message));
            }
            return dst;
        }

        public ApiIndexBuilder()
        {
            CodeAddress = core.dict<MemoryAddress,ApiCodeBlock>();
            AddressUri = core.dict<MemoryAddress,_OpUri>();
            UriCode = new ApiCodeLookup();
            Product = ApiBlockIndex.Empty;
        }

        public ApiMemberIndex CreateMemberIndex(ApiHostCatalog src)
            => ApiIndex.create(src);

        public ApiBlockIndex IndexApiBlocks()
        {
            var src = Z0.Files.Empty;
            var count = src.Length;
            var flow = Running(Msg.IndexingPartFiles.Format(count));

            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref src[i];
                var inner = Running(Msg.IndexingCodeBlocks.Format(path));
                var blocks = ReadRows(path);
                if(blocks.Length != 0)
                {
                    Include(blocks);
                    Ran(inner, Msg.AbsorbedCodeBlocks.Format(blocks.Length, path));
                }
                else
                    Error(Msg.Unparsed(path));
            }

            IndexStatus = Status();
            Product = Freeze();

            Wf.Ran(flow, Product.CalcMetrics());
            return Product;
        }

        void Include(in ApiCodeRow src)
        {
            if(src.Address.IsEmpty)
            {
                Wf.Warn(Msg.Unbased.Format(src.Uri));
                return;
            }

            var inclusion = Include(new ApiCodeBlock(src.Address, src.Uri, src.Data));
            if(inclusion.Any(x => x == false))
                Wf.Warn(Msg.DuplicateUri.Format(src.Uri));
        }

        Triple<bool> Include(in ApiCodeBlock src)
        {
            var a = CodeAddress.TryAdd(src.BaseAddress, src);
            var b = AddressUri.TryAdd(src.BaseAddress, src.OpUri);
            var c = UriCode.TryAdd(src.OpUri, src);
            return Tuples.triple(a,b,c);
        }

        void Include(ReadOnlySpan<ApiCodeRow> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                Include(skip(src, i));
        }

        ApiIndexStatus Status()
        {
            var dst = default(ApiIndexStatus);
            dst.Parts = UriCode.Keys.Select(x => x.Host.Part).Distinct().Array();
            dst.Hosts = UriCode.Keys.Select(x => x.Host).Distinct().Array();
            dst.Addresses = CodeAddress.Keys.Array();
            dst.MemberCount = (uint)CodeAddress.Keys.Count;
            dst.Encoded = new PartCodeAddresses(CodeAddress.ToKVPairs());
            return dst;
        }

        ApiBlockIndex Freeze()
        {
            var memories = CodeAddress.ToKVPairs();
            var parts = UriCode.Keys.Select(x => x.Host.Part).Distinct().Array();
            var code = CodeAddress.Values.Select(x => (x.OpUri.Host, Code: x))
                .Array()
                .GroupBy(g => g.Host)
                .Select(x => (new ApiHostBlocks(x.Key, x.Select(y => y.Code).ToArray()))).Array();

            return new ApiBlockIndex(
                   new PartCodeAddresses(memories),
                   new PartUriAddresses(AddressUri),
                   new PartCodeIndex(code.Select(x => (x.Host, x)).ToDictionary()),
                   UriCode
                   );
        }
    }
}