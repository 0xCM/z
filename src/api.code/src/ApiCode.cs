//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using System.Linq;

    [ApiHost("api")]
    public class ApiCode
    {
        const byte MaxZeroCount = 8;

        public static IApiCatalog catalog(CmdArgs args)
        {
            var assemblies = list<Assembly>();
            var parts = hashset<PartName>();
            var catalog = default(IApiCatalog);
            if(args.Count != 0)
            {
                iter(args, arg => {
                    if(PartNames.parse(arg.Value, out var name))
                        parts.Add(name);
                });

                catalog = ApiCatalog.catalog(ApiAssemblies.Components.Where(c => parts.Contains(c.PartName())));
            }
            else
            {
                foreach(var a in ApiCatalog.components())
                {
                    if(ApiCatalog.part(a, out IPart part))
                    {
                        parts.Add(part.Name);
                        assemblies.Add(a);
                    }
                }
                catalog = ApiCatalog.catalog(assemblies.ToArray());
            }
            return catalog;
        }

        [Op]
        public static void gather(IWfChannel channel, IApiPartCatalog src, ICompositeDispenser dispenser, ConcurrentBag<CollectedHost> dst, bool pll)
            => iter(jit(channel, src), member => dst.Add(gather(channel, member, dispenser)), pll);

        [Op]
        public static ReadOnlySeq<ApiEncoded> gather(IWfChannel channel, ReadOnlySpan<MethodEntryPoint> src, ICompositeDispenser dispenser)
            => extract(channel, raw(channel, dispenser, src)).Values.Array().Sort();

        [Op]
        public static IEnumerable<ApiHostMembers> jit(IWfChannel channel, IApiPartCatalog src)
        {
            var members = bag<ApiHostMembers>();
            iter(src.ApiHosts, host => ClrJit.jit(host, members, channel));
            iter(src.ApiTypes, type => ClrJit.jit(type, members, channel));      
            return members;          
        }     

        public static ParallelQuery<MethodEntryPoint> entries(IWfChannel channel, IApiCatalog catalog)
            => from part in catalog.PartCatalogs.AsParallel()
                from host in jit(channel, part)
                from member in host.Members
                select entry(member);

        [Op]
        public static MethodEntryPoint entries(MethodInfo src)
            => new (ClrJit.jit(src), src.Uri(), src.DisplaySig().Format());

        [Op]
        public static MethodEntryPoint entry(ApiMember src)
            => new (src.BaseAddress, src.Method.Uri(), src.Method.DisplaySig().Format());

        [Op]
        public static Index<MethodEntryPoint> entries(ApiMembers src)
        {
            var count = src.Length;
            var buffer = alloc<MethodEntryPoint>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = entry(src[i]);
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
        public static ReadOnlySeq<ApiEncoded> collect(IWfChannel channel, Assembly src, ICompositeDispenser symbols)
            => gather(channel, entries(ClrJit.jit(ApiCatalog.catalog(src), channel)), symbols);

        // [Op]
        // public static ReadOnlySeq<ApiEncoded> collect(IWfChannel channel, IPart src, ICompositeDispenser symbols)
        //     => collect(channel, src.Owner, symbols);

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

        [MethodImpl(Inline), Op]
        public static ApiCodeParser parser(byte[] buffer)
            => new (EncodingPatterns.Default, buffer);

        const byte ZeroLimit = 10;

        static ConcurrentDictionary<ApiToken,ApiEncoded> parse(Dictionary<ApiHostUri,CollectedCodeExtracts> src, IWfChannel log)
        {
            var flow = log.Running(Msg.ParsingHosts.Format(src.Count));
            var buffer = sys.alloc<byte>(Pow2.T14);
            var parser = ApiCode.parser(buffer);
            var dst = new ConcurrentDictionary<ApiToken,ApiEncoded>();
            var counter = 0u;
            foreach(var host in src.Keys)
            {
                var running = log.Running(Msg.ParsingHostMembers.Format(host));
                var extracts = src[host];
                foreach(var extract in extracts)
                {
                    parser.Parse(extract.TargetExtract);
                    if(!dst.TryAdd(extract.Token,new ApiEncoded(extract.Token, parser.Parsed)))
                        log.Warn($"Duplicate:{extract.Token}");
                    else
                        counter++;
                }
                log.Ran(running, Msg.ParsedHostMembers.Format(extracts.Count, host));
            }

            log.Ran(flow, Msg.ParsedHosts.Format(counter, src.Keys.Count));
            return dst;
        }

        [Op]
        static CollectedHost gather(IWfChannel channel, ApiHostMembers src, ICompositeDispenser dst)
            => new (src, gather(channel, entries(src.Members), dst));

        static ConcurrentDictionary<ApiToken,ApiEncoded> extract(IWfChannel channel, ReadOnlySpan<RawMemberCode> src)
        {
            var count = src.Length;
            var buffer = span<byte>(Pow2.T16);
            var host = ApiHostUri.Empty;
            var dst = dict<ApiHostUri,CollectedCodeExtracts>();
            var max = ByteSize.Zero;
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                var extracted = CollectedCodeExtract.Empty;
                var extracts = CollectedCodeExtracts.Empty;
                ref readonly var raw = ref skip(src,i);
                var result = extract(raw, buffer, out extracted);
                if(result.Fail)
                {
                    Errors.Throw($"StubCodeMismatch:{result.Message}");
                }
                else
                {
                    ref readonly var uri = ref raw.Uri;
                    if(uri.Host != host)
                        host = uri.Host;

                    if(dst.TryGetValue(host, out extracts))
                        extracts.Include(extracted);
                    else
                        dst[host] = new CollectedCodeExtracts(extracted);
                }
            }

            return parse(dst, channel);
        }

        [Op]
        static unsafe Outcome extract(in RawMemberCode raw, Span<byte> buffer, out CollectedCodeExtract dst)
        {
            var pStart = (raw.Entry - 8u).Pointer<byte>();
            Bytes.read16(pStart, ref first(buffer), 0);
            var code = slice(buffer,0,16);
            dst = new CollectedCodeExtract(raw, code.ToArray());
            return true;
        }

        [Op]
        static Index<RawMemberCode> raw(IWfChannel channel, ICompositeDispenser dispenser, ReadOnlySpan<MethodEntryPoint> src)
        {
            var code = sys.alloc<RawMemberCode>(src.Length);
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var entry = ref skip(src,i);
                var buffer = sys.bytes(Cells.alloc(w64));
                ByteReader.read5(entry.Location.Ref<byte>(), buffer);
                seek(code, i) = raw(channel, entry, dispenser);
            }
            return code;
        }

        [Op]
        static RawMemberCode raw(IWfChannel channel, MethodEntryPoint src, ICompositeDispenser dispenser)
        {
            var dst = new RawMemberCode();
            dst.Entry = src.Location;
            dst.Uri = src.Uri;
            var target = AsmBytes.stub(src.Location, out dst.StubCode);
            dst.Target = target;
            if(target != src.Location)
            {
                dst.Disp = AsmRel.disp32(dst.StubCode.Bytes);
                dst.Stub = AsmRel.stub32(src.Location, target);
                dst.Token = token(dispenser, src, target);
            }
            else
                dst.Token = token(dispenser, src);
            return dst;
        }        
    }
}