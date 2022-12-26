
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public partial class ApiCmd : AppService<ApiCmd>, IApiService
    {
        public static ReadOnlySeq<ApiCmdDef> defs(Assembly[] src)
            => tagged(src).Concrete().Select(describe).Sort();

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
            => Channel.TableEmit(fields(defs(src)), dst.Table<CmdFieldRow>());

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

        public static ApiCmdCatalog catalog(ICmdDispatcher src)
        {
            ref readonly var defs = ref src.Commands.Defs;
            var count = defs.Count;
            var dst = alloc<CmdUri>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = defs[i].Uri;
            return new ApiCmdCatalog(entries(dst));
        }

        static Type[] tagged(Assembly[] src)
            =>  src.Types().Tagged<CmdAttribute>();

        static ApiCmdDef describe(Type src)
            => new ApiCmdDef(Cmd.identify(src), src, fields(src));

        static string expr(FieldInfo src)
            => src.Tag<CmdArgAttribute>().MapValueOrDefault(x => text.ifempty(x.Expression,src.Name), src.Name);

        static Index<CmdField> fields(Type src)
            => src.PublicInstanceFields().Mapi((i,x) => new CmdField((byte)i, x, expr(x)));

        public static ApiCmdCatalog catalog()
            => catalog(Dispatcher);

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

        // [Op]
        // public static bool parse(ReadOnlySpan<char> src, out ApiCmdSpec dst)
        // {
        //     var i = SQ.index(src, Chars.Space);
        //     if(i < 0)
        //         dst = new ApiCmdSpec(@string(src), CmdArgs.Empty);
        //     else
        //     {
        //         var name = @string(SQ.left(src,i));
        //         var _args = @string(SQ.right(src,i)).Split(Chars.Space);
        //         dst = new ApiCmdSpec(name, Cmd.args(_args));
        //     }
        //     return true;
        // }        

        public static ReadOnlySeq<CmdFieldRow> fields(ReadOnlySpan<ApiCmdDef> src)
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
                    row.CmdName = type.CmdName;
                    row.Index = field.Index;
                    row.CmdType = type.Source.DisplayName();
                    row.Name = field.Source.Name;
                    row.Expression = field.Expr;
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