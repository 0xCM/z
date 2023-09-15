//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static sys;

public sealed class ApiServer : AppService<ApiServer>
{
    public static ApiCmdCatalog catalog()
        => ApiCmdRunner.Service().CmdCatalog;

    public static Task loop(IWfChannel channel, IApiCmdRunner runner)
        => ApiCmdLoop.start(channel, runner);

    public static A app<A>(string[] args)
        where A : IApiShell, new()
    {
        var dst = new A();
        var wf = runtime();
        dst.Init(wf, args, runner(wf, empty<Assembly>()));
        return dst;
    }

    public static ApiCommand command(string[] input)
    {
        var dst = ApiCommand.Empty;
        var parts = input.ToSeq();
        if(parts.IsNonEmpty)
        {
            var name = parts[0];
            var args = alloc<CmdArg>(parts.Count - 1);
            for(var i=0; i<parts.Count - 1; i++)
                seek(args,i) = parts[i+1];
            dst = new ApiCommand(name,args);
        }
        return dst;
    }

    public static ApiCommand command(ReadOnlySpan<char> src)
    {
        static CmdArg arg(object src)
            => new (src?.ToString() ?? EmptyString);

        static CmdArgs args(params object[] src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = arg(skip(src,i));
            return new (dst);
        }

        var dst = ApiCommand.Empty;
        var i = SQ.index(src, Chars.Space);
        if(i < 0)
            dst = new ApiCommand(@string(src), CmdArgs.Empty);
        else
        {
            var name = @string(SQ.left(src,i));
            var _args = @string(SQ.right(src,i)).Split(Chars.Space);
            dst = new ApiCommand(name, args(_args));
        }
        return dst;  
    }

    [Op, Closures(UInt64k)]
    public static CmdArgs args<T>(in T src)
    {
        var t = typeof(T);
        var fields = t.PublicInstanceFields();
        var count = fields.Length;
        var reflected = sys.alloc<ClrFieldValue>(count);
        ClrFields.values(src, fields, reflected);
        var dst = sys.alloc<CmdArg>(count);
        for(var i=0u; i<count; i++)
        {
            ref readonly var fv = ref skip(reflected,i);
            seek(dst,i) = new CmdArg(fv.Field.Name, fv.Value?.ToString() ?? EmptyString);
        }
        return dst;
    }        

    public static IWfChannel channel()
        => WfChannel.create(initializer());

    public static IApiShell shell(IWfRuntime wf, string[] args, params Assembly[] parts)
    {
        var shell = new ApiShell();
        shell.Init(wf, args, runner(wf, parts));
        return shell;
    }

    public static IApiShell shell(string[] args, params Assembly[] parts)
    {
        var wf = runtime(false);
        var shell = new ApiShell();
        shell.Init(wf, args, runner(wf, parts));
        return shell;
    }

    public static A shell<A>(string[] args, params Assembly[] parts)
        where A : IApiShell, new()
    {
        var wf = runtime();
        var shell = new A();
        shell.Init(wf, args, runner(wf, parts));
        return shell;
    }

    public static EventBroker broker(LogSettings config)
        => new (Z0.EventLog.open(config), true);

    public static EventBroker broker(IEventSink target)
        => new (target,false);

    public static WfInit initializer()
    {
        var dst = new WfInit();
        var control = ExecutingPart.Assembly;
        dst.Verbosity = LogLevel.Status;
        dst.LogConfig = LogSettings.configure(control.PartName(), AppSettings.Default.Logs());
        dst.LogConfig.ErrorPath.CreateParentIfMissing();
        dst.LogConfig.StatusPath.CreateParentIfMissing();
        dst.EventBroker = broker(dst.LogConfig);                
        dst.Host = typeof(WfRuntime);
        dst.EmissionLog = EmissionLog.open(control, timestamp());
        return dst;
    }

    public static IWfRuntime runtime(bool verbose = true)
    {
        var factory = typeof(ApiServer);
        try
        {
            var ts = now();
            var clock = Time.counter(true);
            if(verbose)
                term.emit(Events.running(factory, InitializingRuntime));
            var control = ExecutingPart.Assembly;
            var id = control.Id();
            var dst = initializer();

            if(verbose)
                term.emit(Events.babble(factory, ConfiguredAppLogs.Format(dst.LogConfig)));

            if(verbose)
                term.emit(Events.babble(factory, "Created event broker"));

            if(verbose)
                term.emit(Events.babble(factory, "Created host"));

            if(verbose)
                term.emit(Events.babble(factory, ConfiguredEmissionLogs.Format(dst.EmissionLog)));

            var wf = new WfRuntime(dst);
            term.announce($"ClrVersion: {FileVersionInfo.GetVersionInfo(typeof(object).Assembly.Location).ProductVersion}");

            if(verbose)
                term.emit(Events.ran(factory, AppMsg.status(InitializedRuntime.Format(clock.Elapsed()))));
            return wf;
        }
        catch(Exception e)
        {
            term.emit(Events.error(factory, e));
            throw;
        }
    }

    public static CmdEffectors effectors(IWfRuntime wf, Assembly[] parts)
    {
        var m = methods(wf, parts);
        return new (m, handlers(wf, parts), catalog(m));
    }

    public static CmdUri uri(CmdKind kind, string? part, string? host, string? name)
        => new (kind, part, host, name);

    public static CmdUri uri(ApiCmdRoute route, object host)
        => new(CmdKind.App, host.GetType().Assembly.PartName().Format(), host.GetType().DisplayName(), route.Format());

    public static string format(ApiCommand src)
    {
        if(src.IsEmpty)
            return EmptyString;

        var dst = text.buffer();
        dst.Append(src.Route);
        var count = src.Args.Count;
        for(ushort i=0; i<count; i++)
        {
            var arg = src.Args[i];
            if(nonempty(arg.Name))
            {
                dst.Append(Chars.Space);
                dst.Append(arg.Name);
            }

            if(nonempty(arg.Value))
            {
                dst.Append(Chars.Space);
                dst.Append(arg.Value);
            }
        }
        return dst.Emit();
    }

    [Op]
    public static ApiCmdRoute route(Type src)
    {
        var dst = ApiCmdRoute.Empty;
        var t0 = src.Tag<CmdRouteAttribute>();
        if(t0)
        {
            dst = t0.Value.Route;
        }
        else
        {
            var t1 = src.Tag<CmdAttribute>();
            if(t1)
            {
                var name = t1.Value.Name;
                if(nonempty(name))
                    dst = name;
            }
        }
        if(dst.IsEmpty)
        {
            dst = src.DisplayName();
        }

        return dst;
    }

    public static ApiScript script(FilePath src)
    {
        var dst = ApiScript.Empty;
        var specs = list<ApiCommand>();
        using var reader = src.Utf8LineReader();
        var line = TextLine.Empty;

        while(reader.Next(out line))
        {
            var content = line.Content.Trim();
            if(text.nonempty(content))  
                specs.Add(command(content));
        }

        dst = new (src, specs.ToArray());
        return dst;
    }

    public static ICmd reify(Type src)
        => (ICmd)Activator.CreateInstance(src);

    public static CmdResult<C,P> result<C,P>(C spec, ExecToken token, bool suceeded, P payload = default)
        where C : ICmd, new()
        where P : INullity, new()
            => new (spec,token,suceeded,payload);

    static IApiCmdRunner runner(IWfRuntime wf, Assembly[] parts)
    {
        var _parts = parts.Length == 0 ?  ApiAssemblies.Components.WithEntryAssembly().Array() : parts;
        var runner = (IApiCmdRunner)new ApiCmdRunner(wf.Channel, effectors(wf,_parts));
        AppService.AppData.Value(nameof(IApiCmdRunner), runner);
        return runner;
    }
    
    static CmdHandlers handlers(IWfRuntime wf, Assembly[] src)
    {
        var dst = src.Types().Concrete().Tagged<CmdHandlerAttribute>().Select(x => handler(wf,x)).Map(x => (x.Route,x)).ToDictionary();
        dst.TryAdd(Handlers.DevNul.Route, handler(wf, typeof(Handlers.DevNul)));
        return new (dst);
    }        

    static ApiCmdCatalog catalog(ApiCmdMethods methods)
    {
        var defs = methods.Defs;
        var count = defs.Count;
        var dst = alloc<ApiCmdInfo>(count);
        for(var i=0; i<count; i++)
        {
            ref readonly var method = ref defs[i];
            ref var entry = ref seek(dst,i);
            entry.Uri = method.Uri;
            entry.MethodType = method.MethodType;
            entry.Hash = method.Uri.Hash;
            entry.Name = method.Uri.Name;
        }

        return new ApiCmdCatalog(dst);
    }

    static IEnumerable<IApiService> services(IWfRuntime wf, Assembly[] parts)
    {
        var types = parts.Types().Concrete().Tagged<CmdProviderAttribute>();
        return from t in types.Tagged<CmdProviderAttribute>().Concrete()
                let method = t.StaticMethods().Public().Where(m => m.Name == "create").First()
                select (IApiService)method.Invoke(null, new object[]{wf});
    }

    static ApiCmdMethods methods(IWfRuntime wf, Assembly[] parts)
    {
        var types = parts.Types().Concrete().Tagged<CmdProviderAttribute>();
        var dst = dict<ApiCmdRoute,ApiCmdMethod>();
        var services = ApiServer.services(wf,parts).Array();
        
        iter(services,service => {
            iter(methods(service), m => dst.TryAdd(m.Route, m));
        });

        return new ApiCmdMethods(services,dst);
    }

    static ICmdHandler handler(IWfRuntime wf, Type tHandler)
    {
        var handler = (ICmdHandler)Activator.CreateInstance(tHandler, sys.empty<object>());
        handler.Initialize(wf);
        return handler;
    }

    static ApiCmdMethod method(IApiService host, MethodInfo def, ApiCmdRoute route, CmdMethodType @class)
        => new (route, @class, def, host);

    static IEnumerable<ApiCmdMethod> methods(IApiService host)
    {
        var src = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
        return from def in src
                let tag = def.Tag<CmdOpAttribute>().Require()
                let route = (ApiCmdRoute)tag.Name
                let @class = classify(route, def)
                select method(host, def, route, @class);
    }

    static CmdMethodType classify(ApiCmdRoute route, MethodInfo method)
    {
        var dst = CmdMethodType.None;
        var arity = method.ArityValue();
        var @void = method.HasVoidReturn();
        switch(arity)
        {
            case 0:
                switch(@void)
                {
                    case false:
                        dst = CmdMethodType.Pure;
                    break;
                    case true:
                        dst = CmdMethodType.Emitter;
                    break;
                }
            break;
            case 1:
                switch(@void)
                {
                    case true:
                        dst = CmdMethodType.Receiver;
                    break;
                    case false:
                        dst = CmdMethodType.Func;
                    break;
                }
            break;
            case 2:
            {
                if(route.IsPartial)
                {
                    switch(@void)
                    {
                        case true:
                            dst = CmdMethodType.DiscriminatedReceiver;
                        break;
                        case false:
                            dst = CmdMethodType.DiscriminatedFunc;
                        break;
                    }
                }

                break;
            }
        }
        return dst;
    }


    const string InitializingRuntime = "Initializing runtime";
    
    static RenderPattern<Duration> InitializedRuntime => "Initialized runtime:{0}";

    static RenderPattern<LogSettings> ConfiguredAppLogs => "Configured app logs:{0}";

    static RenderPattern<IEmissionLog> ConfiguredEmissionLogs => "Configured emisson logs:{0}";
}
