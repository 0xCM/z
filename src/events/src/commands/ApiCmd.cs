//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    public class ApiCmd
    {
        [MethodImpl(Inline), Op]
        public static CmdUri uri(CmdKind kind, string? part, string? host, string? name)
            => new CmdUri(kind, part, host, name);

        public static CmdUri uri(ApiCmdRoute route, object host)
            => new(CmdKind.App, host.GetType().Assembly.PartName().Format(), host.GetType().DisplayName(), route.Format());

        [Op]
        public static CmdUri uri(MethodInfo src)
        {
            var host = src.DeclaringType;
            var name = src.Tag<CmdOpAttribute>().MapValueOrElse(a => a.Name, () => src.DisplayName());
            return uri(CmdKind.App, host.Assembly.PartName().Format(), host.DisplayName(), name);        
        }

        internal static IApiCmdRunner runner(IWfRuntime wf, Assembly[] parts)
        {
            var _parts = parts.Length == 0 ? ApiAssemblies.Components : parts;
            var runner = (IApiCmdRunner)new ApiCmdRunner(wf.Channel, ApiCmd.methods(wf, _parts), ApiCmd.handlers(wf, _parts));
            AppService.AppData.Value(nameof(IApiCmdRunner), runner);
            return runner;
        }
        
        internal static CmdHandlers handlers(IWfRuntime wf, Assembly[] src)
        {
            var dst = src.Types().Concrete().Tagged<CmdHandlerAttribute>().Select(x => handler(wf,x)).Map(x => (x.Route,x)).ToDictionary();
            dst.TryAdd(Z0.Handlers.DevNul.Route, handler(wf, typeof(Handlers.DevNul)));
            return new (dst);
        }        

        static ICmdHandler handler(IWfRuntime wf, Type tHandler)
        {
            var handler = (ICmdHandler)Activator.CreateInstance(tHandler, new object[]{});
            handler.Initialize(wf);
            return handler;
        }

        internal static ApiCmdCatalog catalog(ApiCmdMethods methods)
        {
            var defs = methods.Defs;
            var count = defs.Count;
            var dst = sys.alloc<ApiCmdInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var uri = ref defs[i].Uri;
                ref var entry = ref seek(dst,i);
                entry.Uri = uri;
                entry.Hash = uri.Hash;
                entry.Name = uri.Name;
            }

            return new ApiCmdCatalog(dst);
        }

        internal static ApiCmdMethods methods(IWfRuntime wf, Assembly[] parts)
        {
            var types = parts.Types().Concrete().Tagged<CmdProviderAttribute>();
            var dst = dict<string,ApiCmdMethod>();
            iter(types.Tagged<CmdProviderAttribute>().Concrete(), t => {
                var method = t.StaticMethods().Public().Where(m => m.Name == "create").First();
                var service = (IApiService)method.Invoke(null, new object[]{wf});
                iter(methods(service).Defs, m => dst.TryAdd(m.Route.Format(), m));
            });
            return new ApiCmdMethods(dst);
        }

        static ApiCmdMethods methods(IApiService host)
        {
            var src = host.GetType().DeclaredInstanceMethods().Tagged<CmdOpAttribute>();
            var dst = dict<string,ApiCmdMethod>();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var mi = ref skip(src,i);
                var tag = mi.Tag<CmdOpAttribute>().Require();
                dst.TryAdd(tag.Name, new ApiCmdMethod(tag.Name, classify(mi),  mi, host));                
            }
            return new ApiCmdMethods(dst);
        }

        static ApiActorKind classify(MethodInfo src)
        {
            var dst = ApiActorKind.None;
            var arity = src.ArityValue();
            var @void = src.HasVoidReturn();
            switch(arity)
            {
                case 0:
                    switch(@void)
                    {
                        case false:
                            dst = ApiActorKind.Pure;
                        break;
                        case true:
                            dst = ApiActorKind.Emitter;
                        break;
                    }
                break;
                case 1:
                    switch(@void)
                    {
                        case true:
                            dst = ApiActorKind.Receiver;
                        break;
                        case false:
                            dst = ApiActorKind.Func;
                        break;
                    }
                break;
                case 2:
                {
                    switch(@void)
                    {
                        case false:
                            dst = ApiActorKind.ContextReceiver;
                        break;
                        case true:
                            dst = ApiActorKind.ContextFunc;
                        break;
                    }

                    break;
                }
            }
            return dst;
        }
 
        public static string format(ApiCmdSpec src)
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

        public static ApiCmdSpec spec(string[] input)
        {
            var dst = ApiCmdSpec.Empty;
            var parts = input.ToSeq();
            if(parts.IsNonEmpty)
            {
                var name = parts[0];
                var args = sys.alloc<CmdArg>(parts.Count - 1);
                for(var i=0; i<parts.Count - 1; i++)
                    seek(args,i) = parts[i+1];
                dst = new ApiCmdSpec(name,args);
            }
            return dst;
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

        public static ProjectContext context(IProject src)
            => new ProjectContext(src, CmdFlows.flows(src));

        public static ApiCmdScript script(FilePath src)
        {
            var dst = ApiCmdScript.Empty;
            var specs = list<ApiCmdSpec>();
            using var reader = src.Utf8LineReader();
            var line = TextLine.Empty;

            while(reader.Next(out line))
            {
                var content = line.Content.Trim();
                if(text.nonempty(content))  
                    specs.Add(spec(content));
            }

            dst = new (src, specs.ToArray());
            return dst;
        }

        public static ApiCmdSpec spec(ReadOnlySpan<char> src)
        {
            var dst = ApiCmdSpec.Empty;
            var i = SQ.index(src, Chars.Space);
            if(i < 0)
                dst = new ApiCmdSpec(@string(src), CmdArgs.Empty);
            else
            {
                var name = @string(SQ.left(src,i));
                var _args = @string(SQ.right(src,i)).Split(Chars.Space);
                dst = new ApiCmdSpec(name, args(_args));
            }
            return dst;  
        }

        public static ICmd reify(Type src)
            => (ICmd)Activator.CreateInstance(src);

        public static CmdResult<C,P> result<C,P>(C spec, ExecToken token, bool suceeded, P payload = default)
            where C : ICmd, new()
            where P : INullity, new()
                => new CmdResult<C, P>(spec,token,suceeded,payload);

        static CmdArg arg(object src)
            => new CmdArg(src?.ToString() ?? EmptyString);

        static CmdArgs args(params object[] src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = arg(skip(src,i));
            return new (dst);
        }
    }
}