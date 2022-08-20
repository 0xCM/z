//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Arrays;

    public class ApiRuntime
    {
        public static IWfRuntime create(string[] args)
            => create(match(ExecutingPart.Assembly, args));

        public static IWfRuntime create(bool catalog, params string[] args)
        {            
            if(catalog)
                return create(args);
            else
                return create(ApiRuntimeCatalog.Empty);
        }

        public static IWfRuntime create(IApiCatalog src)
        {
            var ts = now();
            term.inform(InitializingRuntime.Format(ts));
            var clock = Time.counter(true);
            var control = ExecutingPart.Assembly;
            var id = control.Id();
            var dst = new WfInit();
            dst.Tokens = TokenDispenser.create();
            term.babble(Step.Format(now(), "Created token dispenser"));
            dst.LogConfig = Loggers.configure();
            term.babble(Step.Format(now(), "Configured status log output"));
            dst.ApiCatalog = src;
            dst.EventBroker = Events.broker(dst.LogConfig);
            term.babble(Step.Format(now(), "Created event broker"));
            dst.Host = new WfHost(typeof(WfRuntime));
            term.babble(Step.Format(now(), "Created host"));
            dst.EmissionLog = Loggers.emission(control, timestamp());
            term.babble(Step.Format(now(), "Configured emission logs"));
            var wf = new WfRuntime(dst);
            term.inform(AppMsg.status(InitializedRuntime.Format(now(), clock.Elapsed())));
            return wf;
        }

        [Op]
        public static Index<IApiHost> hosts(Assembly src)
        {
            var id = src.Id();
            return ApiHostTypes(src).Select(h => host(id, h));
        }

        public static bool load(Assembly src, out IPart dst)
        {
            var attempt = src.GetTypes().Where(t => t.Reifies<IPart>() && !t.IsAbstract).Map(t => (IPart)Activator.CreateInstance(t)).ToArray();
            if(attempt.Length != 0)
            {
                dst = attempt.First();
                return true;
            }
            else
            {
                 dst = default;
                 return false;
            }
        }

        public static Assembly[] assemblies(FS.FolderPath src)
        {
            var dst = list<Assembly>();
            var candidates = libs(src);
            foreach(var path in candidates)
            {
                var assembly = Assembly.LoadFrom(path.Name);
                if(assembly.Id() != 0)
                    dst.Add(assembly);
            }

            return dst.ToArray();
        }

        public static IApiCatalog catalog(Assembly[] src)
        {
            var count = src.Length;
            var parts = list<IPart>();
            for(var i=0; i<count; i++)
            {
                if(ApiRuntime.load(skip(src,i), out var part))
                    parts.Add(part);
            }

            return catalog(parts.Array());
        }

        public static ApiPartCatalog catalog(Assembly src)
            => new ApiPartCatalog(src.Id(), src, complete(src), hosts(src), SvcHostTypes(src));

        static IApiCatalog match(Assembly control, string[] args)
        {
            var dir = FS.path(control.Location).FolderPath;
            if(args.Length == 0)
                return catalog(dir, assemblies(dir).Select(x => x.Id()));
            else
            {
                var ids = parts(args);
                return ids.Length == 0 ? catalog(dir, sys.array<PartId>(control.Id())) : catalog(dir,ids);
            }
        }

        static Index<PartId> parts(ReadOnlySpan<string> src)
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

        static IApiCatalog catalog(IPart[] src)
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

        static Type[] SvcHostTypes(Assembly src)
            => src.GetTypes().Where(t => t.Tagged<FunctionalServiceAttribute>());

        static IApiCatalog catalog(FS.FolderPath src, PartId[] parts)
            => catalog(ApiRuntime.parts(src, parts));

        [Op]
        static Index<ApiCompleteType> complete(Assembly src)
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
        static Index<Type> ApiHostTypes(Assembly src)
            => src.GetTypes().Where(IsApiHost);

        [Op]
        static bool IsApiHost(Type src)
            => src.Tagged<ApiHostAttribute>();

        /// <summary>
        /// Describes an api host
        /// </summary>
        /// <param name="part">The defining part</param>
        /// <param name="t">The reifying type</param>
        [Op]
        static IApiHost host(PartId part, Type type)
        {
            var uri = ApiIdentity.host(type);
            var declared = type.DeclaredMethods();
            return new ApiHost(type, uri.HostName, part, uri, declared, index(declared));
        }

        [Op]
        static Dictionary<string,MethodInfo> index(Index<MethodInfo> src)
        {
            var index = new Dictionary<string, MethodInfo>();
            iter(src, m => index.TryAdd(ApiIdentity.identify(m).IdentityText, m));
            return index;
        }

        static FolderFiles libs(FS.FolderPath src)
        {            
            var candidates = src.Files(FileKind.Dll);
            var dst = list<FS.FilePath>();
            foreach(var file in candidates)
            {
                if(file.FileName.Contains("System.Private.CoreLib"))
                    continue;

                if(FS.managed(file))
                    dst.Add(file);
            }

            return new FolderFiles(src, dst.Array());
        }

        static IPart[] parts(FS.FolderPath src, ReadOnlySpan<PartId> ids)
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

        static ReadOnlySpan<Paired<PartId,FS.FilePath>> PartPaths(FS.FolderPath dir)
        {
            var dst = list<Paired<PartId,FS.FilePath>>();
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
        static Option<IPart> load(FS.FilePath src)
            => from c in assembly(src)
            from t in resolve(c)
            from p in resolve(t)
            from part in resolve(p)
            select part;

        [Op]
        static Option<Assembly> assembly(FS.FilePath src)
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
        static Option<Type> resolve(Assembly src)
            => src.GetTypes().Where(t => t.Reifies<IPart>() && !t.IsAbstract).FirstOrDefault();

        /// <summary>
        /// Attempts to resolve a part resolution property
        /// </summary>
        static Option<PropertyInfo> resolve(Type src)
            => src.StaticProperties().Where(p => p.Name == "Resolved").FirstOrDefault();

        /// <summary>
        /// Attempts to resolve a part from a resolution property
        /// </summary>
        [Op]
        static Option<IPart> resolve(PropertyInfo src)
            => Option.Try(src, x => (IPart)x.GetValue(null));

        static MsgPattern<Timestamp,string> Step => "{0}: {1}";

        static MsgPattern<Timestamp> InitializingRuntime => "Initializing runtime at {0}";

        static MsgPattern<Timestamp,Duration> InitializedRuntime => "Initialized runtime at {0} in {1}";
    }
}