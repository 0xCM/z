//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static core;

    public class ApiCatalogs : WfSvc<ApiCatalogs>
    {
        // public static ReadOnlySeq<ApiRuntimeMember> members(IApiCatalog catalog, IWfEventTarget log, bool pll)
        // {
        //     var dst = bag<ApiRuntimeMember>();
        //     var hosts = bag<ApiHostCatalog>();
        //     catalogs(catalog, log, hosts, pll);
        //     iter(hosts, catalog => {
        //         var members = catalog.Members;
        //         for(var i=0; i<members.Count; i++)
        //         {
        //             var row = ApiRuntimeMember.Empy;
        //             ref readonly var member = ref members[i];
        //             row.Part = member.Host.Part;
        //             row.Token = member.Msil.Token;
        //             row.Address = member.BaseAddress;
        //             row.DisplaySig = Clr.display(member.Method.Artifact());
        //             row.Uri = member.OpUri;
        //             dst.Add(row);
        //         }
        //     }, pll);
        //     return dst.Array().Sort().Resequence();
        // }

        // public static void catalogs(IApiPartCatalog src, IWfEventTarget log, ConcurrentBag<ApiHostCatalog> dst, bool pll)
        //     => iter(src.ApiHosts, host => catalog(host, log, dst), pll);

        // public static void catalog(IApiHost src, IWfEventTarget log, ConcurrentBag<ApiHostCatalog> dst)
        //     => dst.Add(new ApiHostCatalog(src, ClrJit.members(src, log)));

        // public static ApiHostCatalog catalog(IApiHost src, IWfEventTarget log)
        //     => new ApiHostCatalog(src, ClrJit.members(src, log));

        // public static void catalogs(IApiCatalog src, IWfEventTarget log, ConcurrentBag<ApiHostCatalog> dst, bool pll)
        //     => iter(src.PartCatalogs(),  part => catalogs(part, log, dst, pll), pll);

        public void Emit(ApiMembers src, IApiPack dst)
        {
            Emit(src, dst.Table<ApiCatalogEntry>());
        }

        public Index<ApiCatalogEntry> Emit(ApiMembers src, FilePath dst)
        {
            var records = rebase(src.BaseAddress, src.View);
            TableEmit(records, dst);
            return records;
        }

        public static Index<ApiCatalogEntry> rebase(MemoryAddress @base, ReadOnlySpan<ApiMember> src)
        {
            var dst = alloc<ApiCatalogEntry>(src.Length);
            rebase(@base, src, dst);
            return dst;
        }

        public static uint rebase(MemoryAddress @base, ReadOnlySpan<ApiMember> members, Span<ApiCatalogEntry> dst)
        {
            var count = members.Length;
            var rebase = first(members).BaseAddress;
            for(uint seq=0; seq<count; seq++)
            {
                ref var record = ref seek(dst,seq);
                ref readonly var member = ref skip(members, seq);
                record.Sequence = seq;
                record.ProcessBase = @base;
                record.MemberBase = member.BaseAddress;
                record.MemberOffset = AsmRel.disp32(@base, member.BaseAddress);
                record.MemberRebase = (uint)(member.BaseAddress - rebase);
                record.HostName = member.Host.HostName;
                record.PartName = member.Host.Part.Format();
                record.OpUri = member.OpUri;
            }
            return (uint)count;
        }

        // public Index<MemberCodeBlock> Correlate()
        //     => Correlate(ApiRuntimeCatalog.PartCatalogs());

        // public Index<MemberCodeBlock> Correlate(FilePath dst)
        //     => Correlate(ApiRuntimeCatalog.PartCatalogs(), dst);

        // public Index<MemberCodeBlock> Correlate(ReadOnlySpan<IApiPartCatalog> src)
        //     => Correlate(src, FilePath.Empty);

        // public Index<MemberCodeBlock> Correlate(ReadOnlySpan<IApiPartCatalog> src, FilePath path)
        // {
        //     var flow = Running(Msg.CorrelatingParts.Format(src.Length));
        //     var count = src.Length;
        //     var code = list<MemberCodeBlock>();
        //     var records = list<ApiCorrelationEntry>();
        //     var catalogs = bag<ApiHostCatalog>();
        //     for(var i=0; i<count; i++)
        //     {
        //         var part = skip(src,i);
        //         var inner = Running(Msg.CorrelatingOperations.Format(part.PartId.Format()));
        //         var hosts = part.ApiHosts.View;
        //         for(var j=0; j<hosts.Length; j++)
        //         {
        //             ref readonly var srcHost = ref skip(hosts,j);
        //             var hexpath = FilePath.Empty;
        //             if(hexpath.Exists)
        //             {
        //                 Require.invariant(ApiRuntimeCatalog.FindHost(srcHost.HostUri, out var host));
        //                 var catalog = ApiCatalogs.catalog(host, EventLog);
        //                 Correlate(catalog, ApiCode.apiblocks(hexpath), code, records);
        //                 catalogs.Add(catalog);
        //             }
        //         }
        //         Ran(inner);
        //     }

        //     TableEmit(records.OrderBy(x => x.RuntimeAddress).Array(), path);

        //     Ran(flow);
        //     return code.ToArray();
        // }

        // int Correlate(ApiHostCatalog src, Index<ApiCodeBlock> blocks, List<MemberCodeBlock> dst, List<ApiCorrelationEntry> entries)
        // {
        //     var part = src.Host.PartId;
        //     var members = src.Members.OrderBy(x => x.Id).Array();
        //     var targets = blocks.Where(x => x.IsNonEmpty && x.OpId.IsNonEmpty).OrderBy(x => x.OpId).Array();
        //     var correlated = (
        //         from m in members
        //         join t in targets on m.Id equals t.OpId orderby m.Id
        //         select paired(m, t)).Array();

        //     var count = correlated.Length;
        //     if(count > 0)
        //     {
        //         var view = @readonly(correlated);
        //         var seq = Seq16x2.create(0, (byte)(part));
        //         for(var i=0u; i<count; i++)
        //         {
        //             ref readonly var pair = ref skip(view,i);
        //             ref readonly var right = ref pair.Right;
        //             ref readonly var left = ref pair.Left;
        //             var entry = new ApiCorrelationEntry();
        //             entry.Key = seq++;
        //             entry.CaptureAddress = right.BaseAddress;
        //             entry.RuntimeAddress = left.BaseAddress;
        //             entry.Id = right.OpUri;
        //             entries.Add(entry);
        //             dst.Add(new MemberCodeBlock(left, right, i));
        //         }
        //     }
        //     return count;
        // }
    }
}