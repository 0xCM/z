//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class Cmd : AppService<Cmd>
    {   
        public static CmdArgs args<T>(T src)
            where T : ICmd
                => typeof(T).DeclaredInstanceFields().Select(f => new CmdArg(f.Name, f.GetValue(src)?.ToString() ?? EmptyString));

        public static ICmdDispatcher Dispatcher 
            => AppData.Value<ICmdDispatcher>(nameof(ICmdDispatcher));

        public void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

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
                    if(Cmd.parse(content, out ApiCmdSpec spec))
                        RunCmd(spec);
                    else
                    {
                        Channel.Error($"ParseFailure:'{content}'");
                        break;
                    }
                }
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

        public static ApiCmdCatalog catalog()
            => catalog(Dispatcher);

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

        [Op]
        public static ICmd[] reify(Assembly src)
            => tagged(src).Select(reify);

        public static ICmd reify(Type src)
            => (ICmd)Activator.CreateInstance(src);

        [Op]
        static void render(CmdTypeInfo src, ITextBuffer dst)
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


        public static ReadOnlySeq<CmdFieldRow> fields(ReadOnlySpan<CmdTypeInfo> src)
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

        [Op]
        internal static @string identify(Type spec)
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

        public static ReadOnlySeq<CmdTypeInfo> discover(Assembly[] src)
            => tagged(src).Concrete().Select(describe).Sort();

        static Type[] tagged(Assembly src)
            => src.Types().Tagged<CmdAttribute>();

        static Type[] tagged(Assembly[] src)
            =>  src.Types().Tagged<CmdAttribute>();

        static CmdTypeInfo describe(Type src)
            => new CmdTypeInfo(identify(src), src, fields(src));

        static string expr(FieldInfo src)
            => src.Tag<CmdArgAttribute>().MapValueOrDefault(x => text.ifempty(x.Expression,src.Name), src.Name);

        static Index<CmdField> fields(Type src)
            => src.PublicInstanceFields().Mapi((i,x) => new CmdField((byte)i, x, expr(x)));

        public static CmdResult<C,P> result<C,P>(C spec, ExecToken token, bool suceeded, P payload = default)
            where C : ICmd, new()
            where P : INullity, new()
                => new CmdResult<C, P>(spec,token,suceeded,payload);

        public static ReadOnlySeq<ICmdExecutor> executors(params Assembly[] src)
            => src.Types().Tagged<CmdExecutorAttribute>().Concrete().Map(x => (ICmdExecutor)Activator.CreateInstance(x));


        [Op, Closures(UInt64k)]
        public static Tool tool(CmdArgs args, byte index = 0)
            => CmdArgs.arg(args,index).Value;


        [Op]
        public static bool parse(ReadOnlySpan<char> src, out ApiCmdSpec dst)
        {
            var i = SQ.index(src, Chars.Space);
            if(i < 0)
                dst = new ApiCmdSpec(@string(src), CmdArgs.Empty);
            else
            {
                var name = @string(SQ.left(src,i));
                var _args = @string(SQ.right(src,i)).Split(Chars.Space);
                dst = new ApiCmdSpec(name, Cmd.args(_args));
            }
            return true;
        }        

        public static string format(CmdField src)
            => string.Format($"{src.FieldName}:{src.Expr}");

        public static string format(ApiCmdSpec src)
        {
            if(src.IsEmpty)
                return EmptyString;

            var dst = text.buffer();
            dst.Append(src.Name);
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

        public static ReadOnlySeq<CmdFlagSpec> flags(FilePath src)
        {
            var k = z16;
            var dst = list<CmdFlagSpec>();
            using var reader = src.AsciLineReader();
            while(reader.Next(out var line))
            {
                var content = line.Codes;
                var i = SQ.index(content, AsciCode.Colon);
                if(i == NotFound)
                    i = SQ.index(content, AsciCode.Eq);
                if(i == NotFound)
                    continue;

                var name = text.trim(Asci.format(SQ.left(content,i)));
                var desc = text.trim(Asci.format(SQ.right(content,i)));
                dst.Add(flag(name, desc));
            }
            return dst.ToArray();
        }

        public static string format(IToolCmd src)
        {
            var count = src.Args.Count;
            var buffer = text.buffer();
            buffer.AppendFormat("{0}{1}", src.Tool, Chars.LParen);
            for(var i=0; i<count; i++)
            {
                ref readonly var arg = ref src.Args[i];
                buffer.AppendFormat(RP.Assign, arg.Name, arg.Value);
                if(i != count - 1)
                    buffer.Append(", ");
            }

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }

        [MethodImpl(Inline), Op]
        public static CmdFlag disable(CmdFlagSpec flag)
            => new CmdFlag(flag.Name, bit.Off);

        [MethodImpl(Inline), Op]
        public static CmdFlag enable(CmdFlagSpec flag)
            => new CmdFlag(flag.Name, bit.On);

        [MethodImpl(Inline), Op]
        public static CmdFlagSpec flag(string name, string desc)
            => new CmdFlagSpec(name, desc);

        [Op]
        public static CmdLine cmd<T>(T src)
            => $"cmd.exe /c {src}";

        public static CmdArgs args<T>(params T[] src)
            where T : IEquatable<T>, IComparable<T>
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg<T>(skip(src,i));
            return new (dst);
        }

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(Tool tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool, modifier, new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(Tool tool, params string[] src)
            => new ToolCmdLine(tool, new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static ToolScript script(FilePath src, CmdVars vars)
            => new ToolScript(src, vars);

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath.ToUri(), src.TargetPath.ToUri()));

        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Tool tool, S src, T dst)
            => new DataFlow<Actor,S,T>(FlowId.identify(tool,src,dst), tool,src,dst);        

        [MethodImpl(Inline), Op]
        public static CmdUri uri(CmdKind kind, string? part, string? host, string? name)
            => new CmdUri(kind, part, host, name);

        [Op]
        public static CmdLine pwsh(string spec)
            => $"pwsh.exe {spec}";

        public static CmdLine pwsh(FilePath src, string args)
            => string.Format("pwsh.exe {0} {1}", src.Format(PathSeparator.BS), args);

        public static CmdLine pwsh(FilePath src)
            => string.Format("pwsh.exe {0}", src.Format(PathSeparator.BS));        

        [Op]
        public static CmdLine cmd(string spec)
            => string.Format("cmd.exe /c {0}", spec);

        [Op]
        public static CmdLine cmd(FilePath src, string args)
            => string.Format("cmd.exe /c {0} {1}", src.Format(PathSeparator.BS), args);

        [Op]
        public static CmdLine cmd(FilePath src)
            => string.Format("cmd.exe /c {0}", src.Format(PathSeparator.BS));

        [Op]
        public static CmdLine cmd(FilePath path, CmdKind kind)
        {
            return kind switch{
                CmdKind.Cmd => cmd(path),
                CmdKind.Tool => cmd(path),
                CmdKind.Pwsh => pwsh(path),
                _ => Z0.CmdLine.Empty
            };
        }

        [Op]
        public static CmdLine cmd(FilePath path, CmdKind kind, string args)
        {
            return kind switch{
                CmdKind.Cmd => cmd(path, args),
                CmdKind.Tool => cmd(path, args),
                CmdKind.Pwsh => pwsh(path, args),
                _ => Z0.CmdLine.Empty
            };
        }

        public static string join(CmdArgs args)
        {
            var dst = text.emitter();
            for(var i=0; i<args.Count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);
                dst.Append(args[i].Value);
            }

            return dst.Emit();
        }

        public static CmdArgs args(params object[] src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg($"{skip(src,i)}");
            return new (dst);
        }
   }
}