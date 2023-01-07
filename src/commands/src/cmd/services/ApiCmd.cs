
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static CmdActorKind;

    public class ApiCmd : AppService<ApiCmd>, IApiService
    {        
        internal static ICmdHandler handler(IExecutionContext context, Type tHandler)
        {
            var handler = (ICmdHandler)Activator.CreateInstance(tHandler, new object[]{});
            handler.Initialize(context);
            return handler;
        }

        public static EnvVars vars(params Pair<string>[] src)
            => src.Map(x => new EnvVar(x.Left,x.Right));

        // public static IApiCmdRunner runner(IWfRuntime wf)
        //     => new ApiCmdRunner(wf);

        public static IApiCmdRunner runner(IWfRuntime wf, params Assembly[] components)        
        {
            var context = new ExecutionContext(wf, wf.Channel);
            return new ApiCmdRunner(context, handlers(context, components));
        }

        static Type[] HandlerTypes(params Assembly[] src)
            => src.Types().Concrete().Tagged<CmdHandlerAttribute>();

        public static CmdHandlers handlers(IExecutionContext context, params Assembly[] components)
        {
            var data = HandlerTypes(components).Select(x => handler(context,x)).Map(x => (x.Route,x)).ToDictionary();
            data.TryAdd(Handlers.DevNul.Route, handler(context, typeof(Handlers.DevNul)));
            return new (data);
        }
        
        // public static CmdHandlers handlers(IExecutionContext context)
        // {
        //     var types = Assembly.GetExecutingAssembly().Types().Concrete().Tagged<CmdHandlerAttribute>();
        //     return new (types.Select(x => handler(context,x)).Map(x => (x.Route,x)).ToDictionary());
        // }

        public static Outcome exec(IWfChannel channel, CmdMethod effector, CmdArgs args)
        {
            var output = default(object);
            var result = Outcome.Success;
            try
            {
                switch(effector.Kind)
                {
                    case Pure:
                        effector.Definition.Invoke(effector.Host, new object[]{});
                        result = Outcome.Success;
                    break;
                    case Receiver:
                        effector.Definition.Invoke(effector.Host, new object[1]{args});
                        result = Outcome.Success;
                    break;
                    case CmdActorKind.Emitter:
                        output = effector.Definition.Invoke(effector.Host, new object[]{});
                    break;
                    case Func:
                        output = effector.Definition.Invoke(effector.Host, new object[1]{args});
                    break;
                    default:
                        result = new Outcome(false, $"Unsupported {effector.Definition}");
                    break;
                }

                if(output != null)
                {
                    if(output is bool x)
                        result = Outcome.define(x, output, x ? "Win" : "Fail");
                    else if(output is Outcome y)
                    {
                        result = Outcome.success(y.Data, y.Message);
                        if(sys.nonempty(y.Message))
                        {
                            if(y.Fail)
                                channel.Error(y.Message);
                            else
                                channel.Babble(y.Message);
                        }
                    }
                    else
                        result = Outcome.success(output);
                }
            }
            catch(Exception e)
            {
                var msg = AppMsg.format($"{effector.Uri} invocation error", e);
                var origin = AppMsg.orginate(effector.HostType.DisplayName(), effector.Definition.DisplayName(), 12);
                var error = Events.error(msg, origin, effector.HostType);
                channel.Error(error);
                result = (e,msg);
            }

           return result;
        }
         
        public static ICmdDispatcher Dispatcher 
            => AppData.Value<ICmdDispatcher>(nameof(ICmdDispatcher));

        public void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        public void RunCmd(string name)
        {
            var result = Dispatcher.Dispatch(name);
            if(result.Fail)
                Channel.Error(result.Message);
        }

        public void EmitCmdDefs(Assembly[] src, IDbArchive dst)
            => Channel.TableEmit(fields(Cmd.defs(src)), dst.Table<CmdFieldRow>());

        public void RunCmd(IWfChannel channel, ApiCmdSpec cmd)
        {
            try
            {
                Dispatcher.Dispatch(cmd.Name, cmd.Args);
            }
            catch(Exception e)
            {
                channel.Error(e);
            }
        }

        public static CmdCatalog catalog(ICmdDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i].Uri;
            return new CmdCatalog(entries(dst));
        }

        public static CmdCatalog catalog()
            => catalog(Dispatcher);

        public void EmitApiCatalog()
            => EmitApiCatalog(Env.ShellData);
        
        public void EmitApiCatalog(CmdCatalog src, IDbArchive dst)
            => emit(Channel, src, dst.Path(ExecutingPart.Name.Format() + ".commands", FileKind.Csv));

        public void EmitApiCatalog(IDbArchive dst)
            => EmitApiCatalog(catalog(), dst);

        static void emit(IWfChannel channel, CmdCatalog src, FilePath dst)
        {
            var data = src.Values;
            iter(data, x => channel.Row(x.Uri.Name));
            TableFlows.emit(channel, data, dst);
        }

        public void RunApiScript(IWfChannel channel, FilePath src)
        {
            if(src.Missing)
            {
                channel.Error(AppMsg.FileMissing.Format(src));
            }
            else
            {
                var lines = src.ReadNumberedLines(true);
                var count = lines.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var content = ref lines[i].Content;
                    if(Cmd.parse(content, out ApiCmdSpec spec))
                        RunCmd(channel,spec);
                    else
                    {
                        channel.Error($"ParseFailure:'{content}'");
                        break;
                    }
                }
            }
        }

        public static Task<ExecToken> start(IWfChannel channel, CmdArgs args)
        {
            ExecToken exec()
            {
                var src = FS.path(args[0]);
                var flow = channel.Running($"Executing api scripts from {src}");
                var lines = src.ReadNumberedLines(true);
                var count = lines.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var content = ref lines[i].Content;
                    if(Cmd.parse(content, out ApiCmdSpec spec))
                    {
                        Dispatcher.Dispatch(spec.Name, spec.Args);
                    }
                    else
                    {
                        channel.Error($"ParseFailure:'{content}'");
                        break;
                    }
                }
                return channel.Ran(flow);
            }
            return sys.start(exec);
        }   

        public static ReadOnlySeq<ICmdExecutor> executors(params Assembly[] src)
            => src.Types().Tagged<CmdExecutorAttribute>().Concrete().Map(x => (ICmdExecutor)Activator.CreateInstance(x));

        public static ReadOnlySeq<CmdFieldRow> fields(ReadOnlySpan<CmdDef> src)
        {
            var count = src.Select(x => x.FieldCount).Sum();
            var dst = alloc<CmdFieldRow>(count);
            var k=0u;
            for(var i=0; i<src.Length; i++)
            {
                var type = Require.notnull(skip(src,i));
                var instance = Require.notnull(Activator.CreateInstance(type.Source));
                var values = ClrFields.values(instance, type.Fields.Select(x => x.Source).Storage);
                for(var j=0; j<type.FieldCount; j++,k++)
                {
                    ref var row = ref seek(dst,k);
                    ref readonly var field = ref type.Fields[j];
                    row.Route = type.Route;
                    row.Index = field.Index;
                    row.CmdType = type.Source.DisplayName();
                    row.Name = field.Source.Name;
                    row.Expression = field.Description;
                    row.DataType = field.Source.FieldType.DisplayName();
                    row.DefaultValue = values[field.Source.Name].Value?.ToString() ?? EmptyString;
                }
            }
            return dst;
        }

        static ReadOnlySeq<ApiCmdInfo> entries(CmdUriSeq src)    
        {
            var entries = alloc<ApiCmdInfo>(src.Count);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var uri = ref src[i];
                ref var entry = ref seek(entries,i);
                entry.Uri = uri;
                entry.Hash = uri.Hash;
                entry.Name = uri.Name;
            }
            return entries.Sort().Resequence();        
        }        
    }
}