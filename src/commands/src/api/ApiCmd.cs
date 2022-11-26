
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class ApiCmd : AppService<ApiCmd>, IApiService
    {
        public static A shell<A>(bool catalog, params string[] args)
            where A : IAppShell, new()
        {
            var wf = ApiRuntime.create(catalog, args);
            var app = new A();
            app.Init(wf);
            return app;
        }

        public static IApiDispatcher Dispatcher 
            => AppData.Value<IApiDispatcher>(nameof(IApiDispatcher));

        public static string format(CmdField src)
            => string.Format($"{src.FieldName}:{src.Expr}");

        [Op]
        public static void render(CmdTypeInfo src, ITextBuffer dst)
        {
            dst.Append(src.Source.Name);
            var fields = src.Fields.View;;
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,count);
                dst.Append(string.Format(" | {0}:{1}", field.FieldName, field.Expr));
            }
        }

        [Op]
        public static string format(CmdTypeInfo src)
        {
            var buffer = text.buffer();
            render(src, buffer);
            return buffer.Emit();
        }

        public static ICmd reify(Type src)
            => (ICmd)Activator.CreateInstance(src);

        public static Name identify<T>()
            => identify(typeof(T));

        [Op]
        public static Name identify(Type spec)
        {
            var tag = spec.Tag<CmdAttribute>();
            if(tag)
            {
                var name = tag.Value.Name;
                if(empty(name))
                    return spec.Name;
                else
                    return name;
            }
            else
                return spec.Name;
        }

        [Op]
        public static ICmd[] reify(Assembly src)
            => tagged(src).Select(reify);

        public void RunCmd(string name, CmdArgs args)
            => ApiCmd.Dispatcher.Dispatch(name, args);

        string Prompt()
            => string.Format("{0}> ", "cmd");

        ApiCmdSpec Next()
        {
            var input = term.prompt(Prompt());
            if(ApiCmd.parse(input, out ApiCmdSpec cmd))
            {
                return cmd;
            }
            else
            {
                Channel.Error($"ParseFailure:{input}");
                return ApiCmdSpec.Empty;
            }
        }

        public void RunApiScript(FilePath src)
        {
            if(src.Missing)
            {
                Channel.Error(AppMsg.FileMissing.Format(src));
            }
            else
            {
                var lines = src.ReadNumberedLines(true);
                var count = lines.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var content = ref lines[i].Content;
                    if(ApiCmd.parse(content, out ApiCmdSpec spec))
                        RunCmd(spec);
                    else
                    {
                        Channel.Error($"ParseFailure:'{content}'");
                        break;
                    }
                }
            }
        }

        public void RunCmd(string name)
        {
            var result = Dispatcher.Dispatch(name);
            if(result.Fail)
                Channel.Error(result.Message);
        }

        public void RunCmd(ApiCmdSpec cmd)
        {
            try
            {
                Dispatcher.Dispatch(cmd.Name, cmd.Args);
            }
            catch(Exception e)
            {
                Channel.Error(e);
            }
        }
    }
}