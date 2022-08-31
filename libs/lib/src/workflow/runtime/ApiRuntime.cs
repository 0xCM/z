//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiRuntime : ApiRuntime<ApiRuntime>
    {        
        public static IApiCatalog catalog()
            => catalog(colocated(ExecutingPart.Assembly));

        static IApiCatalog match(Assembly control, string[] args)
        {
            var candidates = colocated(control);
            if(args.Length == 0)
                return catalog(candidates);
            else
            {
                var match = args.ToHashSet();
                var matched = list<Assembly>();
                foreach(var a in candidates)
                {
                    var name = a.PartName();
                    if(match.Contains(name.Format()))
                        matched.Add(a);
                }
                return catalog(matched.ToArray());
            }
        }

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
                term.emit(Events.running(factory, InitializingRuntime));
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
                term.emit(Events.ran(factory, AppMsg.status(InitializedRuntime.Format(clock.Elapsed()))));
                return wf;
            }
            catch(Exception e)
            {
                term.emit(Events.error(factory, e));
                throw;
            }
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

        public static Assembly[] colocated(Assembly src)
            => assemblies(FS.path(src.Location).FolderPath);

        public static Assembly[] assemblies(FolderPath src)
        {
            var dst = list<Assembly>();
            var candidates = libs(src);
            foreach(var path in candidates)
            {
                var assembly = Assembly.LoadFrom(path.Name);
                if(assembly.PartName().IsNonEmpty)
                    dst.Add(assembly);
            }

            return dst.ToArray();
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
    }
}