
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class ApiCmd : AppService<ApiCmd>, IApiCmdSvc
    {
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

        // public static ApiOps distill(IApiOps[] src)
        // {
        //     var dst = dict<string,IApiCmdMethod>();
        //     foreach(var a in src)
        //         iter(a.Invokers,  a => dst.TryAdd(a.CmdName, a));
        //     return new ApiOps(dst);
        // }

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

        public void Loop()
        {
            var input = Next();
            while(input.Name != ".exit")
            {
                if(input.IsNonEmpty)
                    RunCmd(input);
                input = Next();
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