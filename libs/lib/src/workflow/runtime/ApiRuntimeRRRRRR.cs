//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public interface IApiRuntime
    {

    }

    public interface IApiRuntime<R> : IApiRuntime
        where R: IApiRuntime<R>
    {

    }

    public abstract class ApiRuntime<R> : IApiRuntime<R>
        where R: ApiRuntime<R>
    {
        [Op]
        public static Index<IApiHost> hosts(Assembly src)
        {
            var id = src.Id();
            return ApiHostTypes(src).Select(h => host(id, h));
        }

        public static ApiPartCatalog catalog(Assembly src)
            => new ApiPartCatalog(src.Id(), src, complete(src), hosts(src), SvcHostTypes(src));

        protected static IApiCatalog catalog(FolderPath home, PartId[] src)
            => catalog(parts(home, src));

        protected static IApiCatalog catalog(IPart[] src)
        {
            var catalogs = src.Select(x => catalog(x.Owner)).Where(c => c.IsIdentified);
            var dst = new ApiRuntimeCatalog(
                src,
                src.Select(p => p.Owner),
                new ApiPartCatalogs(catalogs),
                catalogs.SelectMany(c => c.ApiHosts.Storage).Where(h => nonempty(h.HostUri.HostName)),
                src.Select(p => p.Id),
                catalogs.SelectMany(x => x.Methods)
                );
            return dst;
        }

        protected static FolderFiles libs(FolderPath src)
        {            
            var candidates = src.Files(FileKind.Dll);
            var dst = list<FilePath>();
            foreach(var file in candidates)
            {
                if(file.FileName.Contains("System.Private.CoreLib"))
                    continue;

                if(FS.managed(file))
                    dst.Add(file);
            }

            return new FolderFiles(src, dst.Array());
        }

        protected static IPart[] parts(FolderPath src, ReadOnlySpan<PartId> ids)
        {
            var count = ids.Length;
            var dst = list<IPart>();
            var set = hashset<PartId>();
            iter(ids, p => set.Add(p));
            var candidates = PartPaths(src);
            foreach(var (id,path) in candidates)
            {
                if(set.Contains(id) && path.Exists)
                    ApiRuntime.load(path).OnSome(part => dst.Add(part));
            }
            return dst.ToArray();
        }

 
        protected static ReadOnlySpan<Paired<PartId,FilePath>> PartPaths(FolderPath dir)
        {
            var dst = list<Paired<PartId,FilePath>>();
            var symbols = Symbols.index<PartId>().View;
            var count = symbols.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(symbols,i);
                dst.Add((symbol.Kind, dir + FS.file("z0." + symbol.Expr.Format(), FS.Dll)));
            }
            return dst.ViewDeposited();
        }

        /// <summary>
        /// Attempts to resolve a part from an assembly file path
        /// </summary>
        [Op]
        protected static Option<IPart> load(FilePath src)
            => from c in assembly(src)
            from t in resolve(c)
            from p in resolve(t)
            from part in resolve(p)
            select part;

        [Op]
        protected static Option<Assembly> assembly(FilePath src)
        {
            try
            {
                return Assembly.LoadFrom(src.Name);
            }
            catch(Exception e)
            {
                term.warn($"Unable to load {src.ToUri()}: {e.Message}");
                return default;
            }
        }

        /// <summary>
        /// Attempts to resolve a part resolution type
        /// </summary>
        protected static Option<Type> resolve(Assembly src)
            => src.GetTypes().Where(t => t.Reifies<IPart>() && !t.IsAbstract).FirstOrDefault();

        /// <summary>
        /// Attempts to resolve a part resolution property
        /// </summary>
        protected static Option<PropertyInfo> resolve(Type src)
            => src.StaticProperties().Where(p => p.Name == "Resolved").FirstOrDefault();

        /// <summary>
        /// Attempts to resolve a part from a resolution property
        /// </summary>
        [Op]
        protected static Option<IPart> resolve(PropertyInfo src)
            => Option.Try(src, x => (IPart)x.GetValue(null));

        protected static Index<PartId> parts(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            if(count == 0)
                return sys.empty<PartId>();

            var symbols = Symbols.index<PartId>();
            var dst = span<PartId>(count);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref skip(src,i);
                if(symbols.Lookup(name, out var sym))
                    seek(dst, counter++) = sym.Kind;
            }
            return slice(dst, 0, counter).ToArray();
        }

        protected static Type[] SvcHostTypes(Assembly src)
            => src.GetTypes().Where(t => t.Tagged<FunctionalServiceAttribute>());

        [Op]
        protected static Index<ApiCompleteType> complete(Assembly src)
        {
            var part = src.Id();
            var types = span(src.GetTypes().Where(t => t.Tagged<ApiCompleteAttribute>()));
            var count = types.Length;
            var buffer = sys.alloc<ApiCompleteType>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var type = ref skip(types,i);
                var attrib = type.Tag<ApiCompleteAttribute>();
                var name = text.ifempty(attrib.MapValueOrDefault(a => a.Name, type.Name),type.Name).ToLower();
                var uri = new ApiHostUri(part, name);
                var declared = type.DeclaredMethods();
                seek(buffer, i) = new ApiCompleteType(type, name, part, uri, declared, index(declared));
            }
            return buffer;
        }

        /// <summary>
        /// Searches an assembly for types tagged with the <see cref="ApiHostAttribute"/>
        /// </summary>
        /// <param name="src">The assembly to search</param>
        [Op]
        protected static Index<Type> ApiHostTypes(Assembly src)
            => src.GetTypes().Where(IsApiHost);

        [Op]
        protected static bool IsApiHost(Type src)
            => src.Tagged<ApiHostAttribute>();

        /// <summary>
        /// Describes an api host
        /// </summary>
        /// <param name="part">The defining part</param>
        /// <param name="t">The reifying type</param>
        [Op]
        protected static IApiHost host(PartId part, Type type)
        {
            var uri = ApiIdentity.host(type);
            var declared = type.DeclaredMethods();
            return new ApiHost(type, uri.HostName, part, uri, declared, index(declared));
        }

        [Op]
        protected static Dictionary<string,MethodInfo> index(Index<MethodInfo> src)
        {
            var index = new Dictionary<string, MethodInfo>();
            iter(src, m => index.TryAdd(ApiIdentity.identify(m).IdentityText, m));
            return index;
        }

        protected static MsgPattern InitializingRuntime => "Initializing runtime";
        
        protected static RenderPattern<Duration> InitializedRuntime => "Initialized runtime:{1}";

        protected static RenderPattern<LogSettings> ConfiguredAppLogs => "Configured app logs:{0}";

        protected static RenderPattern<IWfEmissionLog> ConfiguredEmissionLogs => "Configured emisson logs:{0}";
    }
}