//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiRuntime
    {
        public static IWfRuntime create(string[] args)
            => create(match(ExecutingPart.Assembly, args), args);

        public static IWfRuntime create(bool catalog, params string[] args)
        {            
            if(catalog)
                return create(args);
            else
                return create(ApiRuntimeCatalog.Empty, args);
        }

        public static IWfRuntime create(IApiCatalog src, string[] args)
        {
            var factory = typeof(ApiRuntime);
            try
            {
                var ts = now();
                var clock = Time.counter(true);
                term.emit(Events.running(factory,InitializingRuntime.Format(ts)));
                var settings = AppEnv.Default;
                var control = ExecutingPart.Assembly;
                var id = control.Id();
                var dst = new WfInit();
                dst.Args = args;
                dst.ApiCatalog = src;
                dst.LogConfig = Loggers.configure(id, settings.Logs());
                dst.LogConfig.ErrorPath.CreateParentIfMissing();
                dst.LogConfig.StatusPath.CreateParentIfMissing();
                term.emit(Events.babble(factory, ConfiguredAppLogs.Format(dst.LogConfig)));
                dst.Tokens = TokenDispenser.create();
                dst.EventBroker = Events.broker(dst.LogConfig);
                term.emit(Events.babble(factory, "Created event broker"));
                dst.Host = new WfHost(typeof(WfRuntime));
                term.emit(Events.babble(factory, "Created host"));
                dst.EmissionLog = Loggers.emission(control, timestamp());
                term.emit(Events.babble(factory, ConfiguredEmissionLogs.Format(dst.EmissionLog)));
                var wf = new WfRuntime(dst);
                term.emit(Events.ran(factory, AppMsg.status(InitializedRuntime.Format(now(), clock.Elapsed()))));
                return wf;
            }
            catch(Exception e)
            {
                term.emit(Events.error(factory, e));
                throw;
            }
        }
        
        [Op]
        public static Index<IApiHost> hosts(Assembly src)
        {
            var id = src.Id();
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
                {
                    dst.Add(new AppServiceSpec(type,factories));
                }                
            }

            return dst.Array();
        }

        public static Assembly[] colocated(Assembly src)
            => assemblies(FS.path(src.Location).FolderPath);

        public static Assembly[] assemblies(FolderPath src)
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
                if(load(skip(src,i), out var part))
                    parts.Add(part);
            }

            return catalog(parts.Array());
        }

        static bool load(Assembly src, out IPart dst)
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

        static IApiCatalog catalog(FolderPath src, PartId[] parts)
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

        static FolderFiles libs(FolderPath src)
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

        static IPart[] parts(FolderPath src, ReadOnlySpan<PartId> ids)
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

        static ReadOnlySpan<Paired<PartId,FilePath>> PartPaths(FolderPath dir)
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
        static Option<IPart> load(FilePath src)
            => from c in assembly(src)
            from t in resolve(c)
            from p in resolve(t)
            from part in resolve(p)
            select part;

        [Op]
        static Option<Assembly> assembly(FilePath src)
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

        static RenderPattern<Timestamp> InitializingRuntime => "Initializing runtime at {0}";

        static string ServiceSpecifier(Type src) 
        {
            var @base = text.replace(FS.path(src.Assembly.Location).ToUri().Format(), "file:///", "svc://");
            return $"{@base}/{src.DisplayName()}";
        }
        
        static RenderPattern<Timestamp,Duration> InitializedRuntime => "Initialized runtime at {0} in {1}";

        static RenderPattern<LogSettings> ConfiguredAppLogs => "Configured app logs:\n{0}";

        static RenderPattern<IWfEmissionLog> ConfiguredEmissionLogs => "Configured emisson logs:{0}";
    }
}