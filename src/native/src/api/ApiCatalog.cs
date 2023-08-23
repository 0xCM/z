//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    public class ApiCatalog : AppService<ApiCatalog>
    {
        public static Assembly[] components()        
            => ApiAssemblies.Components;

        public static ReadOnlySeq<ApiCatalogEntry> entries(ApiMembers src)
        {
            var dst = sys.alloc<ApiCatalogEntry>(src.Count);
            if(src.IsNonEmpty)
            {
                var @base = src.BaseAddress;
                var rebase = src[0].BaseAddress;
                for(var i=0u; i<src.Count; i++)
                {
                    ref readonly var member = ref src[i];
                    ref var record = ref seek(dst,i);
                    record.Sequence = i;
                    record.ProcessBase = @base;
                    record.MemberBase = member.BaseAddress;
                    record.MemberOffset = AsmRel.disp32(@base, member.BaseAddress);
                    record.MemberRebase = (uint)(member.BaseAddress - rebase);
                    record.HostName = member.Host.HostName;
                    record.PartName = member.Host.Part.Format();
                    record.OpUri = member.OpUri;
                }
            }
            return dst;
        }        

        public static Index<ApiCatalogEntry> entries(IWfChannel channel, FilePath src)
        {
            var rows = list<ApiCatalogEntry>();
            using var reader = src.Utf8Reader();
            reader.ReadLine();
            var line = reader.ReadLine();
            while(line != null)
            {
                var outcome = parse(line, out ApiCatalogEntry row);
                if(outcome)
                    rows.Add(row);
                else
                {
                    channel.Error(outcome.Message);
                    return empty<ApiCatalogEntry>();
                }
                line = reader.ReadLine();
            }
            return rows.ToArray();
        }

        public static IApiCatalog catalog(Assembly[] src)
        {
            var count = src.Length;
            var parts = list<IPart>();
            for(var i=0; i<count; i++)
            {
                if(part(skip(src,i), out var p))
                    parts.Add(p);
            }

            return catalog(parts.Array());
        }

        public static IApiCatalog catalog()
            => catalog(components());

        public static ApiPartCatalog catalog(Assembly src)
            => new (src.PartName(), src, complete(src), hosts(src), SvcHostTypes(src));

        public static ApiMemberIndex index(ApiHostCatalog src)
        {
            var ix = index(src.Members.Select(h => (h.Id, h)));
            return new ApiMemberIndex(ix.HashTable, ix.Duplicates);
        }

        [Op]
        public static ResolvedMethod resolve(MethodInfo src)
        {
            var diviner = MultiDiviner.Service;
            var host = ApiIdentity.host(src.DeclaringType);
            var uri = ApiIdentity.define(ApiUriScheme.Located, host, src.Name, diviner.Identify(src));
            var resolved = new ResolvedMethod(src, uri, ClrJit.jit(src));
            return resolved;
        }

        [Op]
        public static ApiMember member(in ResolvedMethod src)
            => new (src.Uri, src.Method, src.EntryPoint, CilDynamic.member(src.EntryPoint, src.Uri, src.Method));

        [Op, Closures(UInt64k)]
        public static ApiOpIndex<ApiMember> index(IEnumerable<(OpIdentity,ApiMember)> src)
        {
            var items = src.ToArray();
            var identities = items.Select(x => x.Item1).ToArray();
            var duplicates = (from g in identities.GroupBy(i => i.IdentityText)
                             where g.Count() > 1
                             select g.Key).ToHashSet();

            var dst = new Dictionary<OpIdentity,ApiMember>();
            if(duplicates.Count() != 0)
                dst = items.Where(i => !duplicates.Contains(i.Item1.IdentityText)).ToDictionary();
            else
                dst = src.ToDictionary();

            return new ApiOpIndex<ApiMember>(dst, duplicates.Select(d => ApiIdentity.opid(d)).Array());
        }

        [Op]
        public static Index<IApiHost> hosts(Assembly src)
        {
            var id = src.PartName();
            return ApiHostTypes(src).Select(h => host(id, h));
        }
        
        public static ReadOnlySeq<ServiceSpec> services(Assembly[] src)
        {
            var dst = list<ServiceSpec>();
            var types = src.Types().Tagged<ServiceCacheAttribute>().Concrete().ToSeq();
            for(var i=0; i<types.Count; i++)
            {
                ref readonly var type = ref types[i];
                var factories = type.PublicInstanceMethods().Concrete().Where(m => m.ReturnType.Reifies<IAppService>());
                if(factories.Length != 0)
                    dst.Add(new AppServiceSpec(type,factories));
            }

            return dst.Array();
        }

        public static bool part(Assembly src, out IPart dst)
        {
            var attempt = src.GetTypes().Where(t => t.Reifies<IPart>() && !t.IsAbstract).Map(t => (IPart)Activator.CreateInstance(t));
            if(attempt.Length != 0)
            {
                dst = sys.first(attempt);
                return true;
            }
            else
            {
                 dst = default;
                 return false;
            }
        }    

        static IApiCatalog catalog(IPart[] src)
        {
            var catalogs = src.Select(x => catalog(x.Owner)).Where(c => c.IsIdentified);
            var dst = new ApiRuntimeCatalog(
                src,
                src.Select(p => p.Owner),
                new ApiPartCatalogs(catalogs),
                catalogs.SelectMany(c => c.ApiHosts.Storage).Where(h => nonempty(h.HostUri.HostName)),
                catalogs.SelectMany(x => x.Methods)
                );
            return dst;
        }

        static Outcome parse(string src, out ApiCatalogEntry dst)
        {
            const char Delimiter = FieldDelimiter;
            const byte FieldCount = ApiCatalogEntry.FieldCount;
            var fields = text.split(src, Delimiter);
            if(fields.Length != FieldCount)
            {
                dst = default;
                return (false, AppMsgs.FieldCountMismatch.Format(fields.Length, FieldCount));
            }

            var i = 0;
            DataParser.parse(skip(fields, i++), out dst.Sequence);
            DataParser.parse(skip(fields, i++), out dst.ProcessBase);
            DataParser.parse(skip(fields, i++), out dst.MemberBase);
            Disp.parse(skip(fields, i++), out dst.MemberOffset);
            AddressParser.parse(skip(fields, i++), out dst.MemberRebase);
            DataParser.parse(skip(fields, i++), out dst.PartName);
            DataParser.parse(skip(fields, i++), out dst.HostName);
            ApiIdentity.parse(skip(fields, i++), out dst.OpUri);
            return true;
        }

        static Type[] SvcHostTypes(Assembly src)
            => src.GetTypes().Where(t => t.Tagged<FunctionalServiceAttribute>());

        [Op]
        static Index<Type> ApiHostTypes(Assembly src)
            => src.GetTypes().Where(IsApiHost);

        [Op]
        static bool IsApiHost(Type src)
            => src.Tagged<ApiHostAttribute>();

        [Op]
        static Dictionary<string,MethodInfo> index(Index<MethodInfo> src)
        {
            var index = new Dictionary<string, MethodInfo>();
            iter(src, m => index.TryAdd(ApiIdentity.identify(m).IdentityText, m));
            return index;
        }

        [Op]
        static IApiHost host(PartName part, Type type)
        {
            var uri = ApiIdentity.host(type);
            var declared = type.DeclaredMethods();
            return new ApiHost(type, uri.HostName, part, uri, declared, index(declared));
        }

        [Op]
        static Index<ApiCompleteType> complete(Assembly src)
        {
            var part = src.PartName();
            var types = span(src.GetTypes().Where(t => t.Tagged<ApiCompleteAttribute>()));
            var count = types.Length;
            var buffer = sys.alloc<ApiCompleteType>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var type = ref skip(types,i);
                var attrib = type.Tag<ApiCompleteAttribute>();
                var name = text.ifempty(attrib.MapValueOrDefault(a => a.Name, type.Name), type.Name).ToLower();
                var declared = type.DeclaredMethods();
                seek(buffer, i) = new ApiCompleteType(type, part, new ApiHostUri(part, name), declared, index(declared));
            }
            return buffer;
        }
    }
}