//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class Cmd 
    {   
        public static ReadOnlySeq<IToolExecutor> executors(params Assembly[] src)
            => src.Types().Tagged<CmdExecutorAttribute>().Concrete().Map(x => (IToolExecutor)Activator.CreateInstance(x));

        public static void emit(IWfChannel channel, ToolCatalog src, IDbArchive dst)
        {
            var emitter = text.emitter();
            foreach(var tool in src)
            {               
                var info = string.Format("{0:D5} | {1,-48} | {2}", tool.Seq, tool.Name, tool.Path); 
                emitter.AppendLine(info);
                channel.Row(info);
            }

            channel.FileEmit(emitter.Emit(), dst.Path(FS.file("tools", FileKind.Csv)));
        }

        [Op, Closures(UInt64k)]
        public static ToolCmd tool<T>(Tool tool, in T src)
            where T : struct
        {
            var t = typeof(T);
            var fields = Clr.fields(t);
            var count = fields.Length;
            var reflected = sys.alloc<ClrFieldValue>(count);
            ClrFields.values(src, fields, reflected);
            var buffer = sys.alloc<CmdArg>(count);
            var target = span(buffer);
            var values = @readonly(reflected);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref skip(values,i);
                seek(target,i) = new CmdArg(fv.Field.Name, fv.Value?.ToString() ?? EmptyString);
            }
            return new ToolCmd(tool, Cmd.identify(t), buffer);
        }        

        [Op, Closures(UInt64k)]
        public static Tool tool(CmdArgs args, byte index = 0)
            => new (CmdArgs.arg(args,index).Value);

        [MethodImpl(Inline), Op]
        public static ToolScript script(FilePath src, CmdVars vars)
            => new ToolScript(src, vars);

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(FilePath tool, params string[] src)
            => new ToolCmdLine(tool, src);

        [Op]
        internal static EventOrigin origin(string name, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => new EventOrigin(name, new CallingMember(caller, file, line ?? 0));

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

        public static CmdUri uri(string name, object host)
            => new(CmdKind.App, host.GetType().Assembly.PartName().Format(), host.GetType().DisplayName(), name);

        public static CmdLine cmdline(FilePath src)
        {
            if(src.Is(FileKind.Cmd))
                return cmd(src);
            else if(src.Is(FileKind.Ps1))
                return pwsh(src);
            else
                return sys.@throw<CmdLine>();
        }

        public static CmdArg arg(FieldInfo src)
        {
            var attrib = src.Tag<CmdArgAttribute>();
            var name = attrib.MapValueOrDefault(a => a.Name, src.Name);
            var desc = attrib.MapValueOrDefault(a => a.Description, EmptyString);
            return new (name,desc);
        }

        public static CmdField field(ushort i, FieldInfo src)
        {
            var attrib = src.Tag<CmdArgAttribute>();
            var name = attrib.MapValueOrDefault(a => a.Name, src.Name);
            var desc = attrib.MapValueOrDefault(a => a.Description, EmptyString);
            return new CmdField(i, src, name, src.FieldType.DisplayName(), desc);
        }

        [Op]
        public static CmdUri uri(MethodInfo src)
        {
            var host = src.DeclaringType;
            var name = src.Tag<CmdOpAttribute>().MapValueOrElse(a => a.Name, () => src.DisplayName());
            return Cmd.uri(CmdKind.App, host.Assembly.PartName().Format(), host.DisplayName(), name);        
        }
        
        public static CmdDefs defs(Assembly[] src)
            => new (tagged(src).Concrete().Select(def).Sort());

        public static CmdDef def(Type src)
            => new CmdDef(route(src), src, fields(src));

        public static ReadOnlySeq<CmdField> fields(Type src)
            => src.PublicInstanceFields().Mapi((i,x) =>  field((ushort)i,x));

        static Type[] tagged(Assembly[] src)
            =>  src.Types().Tagged<CmdAttribute>();

        public static string format(IToolCmd src)
        {
            var count = src.Args.Count;
            var buffer = text.buffer();
            buffer.AppendFormat("{0}{1}", src.Tool, Chars.LParen);
            for(var i=0; i<count; i++)
            {
                var arg = src.Args[i];
                buffer.AppendFormat(RP.Assign, arg.Name, arg.Value);
                if(i != count - 1)
                    buffer.Append(", ");
            }

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }

        public static string format<T>(T src)
            where T : ICmd, new()
        {
            var buffer = text.emitter();
            buffer.AppendFormat("{0}{1}", src.CmdId, Chars.LParen);

            var fields = ClrFields.instance(typeof(T));
            if(fields.Length != 0)
                render(src, fields, buffer);

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }

        public static void render(object src, ReadOnlySpan<ClrFieldAdapter> fields, ITextEmitter dst)
        {
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                dst.AppendFormat(RP.Assign, field.Name, field.GetValue(src));
                if(i != count - 1)
                    dst.Append(", ");
            }
        }                            

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

        [Op]
        public static CmdRoute route(Type src)
        {
            var dst = CmdRoute.Empty;
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

        [Op]
        public static @string identify(Type spec)
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

        public static CmdArgs args<T>(T src)
            where T : ICmd
                => typeof(T).DeclaredInstanceFields().Select(f => new CmdArg(f.Name, f.GetValue(src)?.ToString() ?? EmptyString));

        public static ICmd reify(Type src)
            => (ICmd)Activator.CreateInstance(src);

        public static CmdResult<C,P> result<C,P>(C spec, ExecToken token, bool suceeded, P payload = default)
            where C : ICmd, new()
            where P : INullity, new()
                => new CmdResult<C, P>(spec,token,suceeded,payload);

        public static string format(CmdField src)
            => string.Format($"{src.Name}:{src.Description}");

        [Op]
        public static CmdLine cmd<T>(T src)
            => $"cmd.exe /c {src}";

        public static CmdArgs args<T>(params T[] src)
            where T : new()
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg<T>(skip(src,i));
            return new (dst);
        }

        [Op]
        public static string format(CmdDef src)
        {
            var buffer = text.buffer();
            render(src, buffer);
            return buffer.Emit();
        }

        [Op]
        static void render(CmdDef src, ITextBuffer dst)
        {
            dst.Append(src.Source.Name);
            var fields = src.Fields.View;;
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,count);
                dst.Append(string.Format(" | {0}:{1}", field.Name, field.Description));
            }
        }

        [MethodImpl(Inline)]
        public static FileFlow flow(in CmdFlow src)
            => new FileFlow(flow(src.Tool, src.SourcePath, src.TargetPath));

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

        public static CmdLine cmdline(params CmdArg[] args)
            => new CmdLine(args);

        public static CmdLine cmdline(params object[] args)
            => new CmdLine(args.Select(x => x?.ToString() ?? EmptyString));
            
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

        public static CmdArg arg(object src)
        {            
            var data = src?.ToString() ?? EmptyString;
            var i = text.index(data, '=');
            var name = EmptyString;
            var value = data;
            if(i > 0)
            {
                name = text.left(data,i).RemoveAny('-');
                value = text.right(data,i);
            }
            return new (name,value);
        }

        public static CmdArgs args(params object[] src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = arg(skip(src,i));
            return new (dst);
        }

        public static CmdArgs args(params CmdArg[] src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = skip(src,i);
            return new (dst);
        }   

        static ReadOnlySeq<CmdFieldRow> fields(ReadOnlySpan<CmdDef> src)
        {
            var count = src.Select(x => x.FieldCount).Sum();
            var dst = alloc<CmdFieldRow>(count);
            var k=0u;
            for(var i=0; i<src.Length; i++)
            {
                var type = Require.notnull(skip(src,i));
                var instance = Require.notnull(Activator.CreateInstance(type.Source));
                for(var j=0; j<type.FieldCount; j++,k++)
                {
                    ref var row = ref seek(dst,k);
                    ref readonly var field = ref type.Fields[j];
                    row.Route = type.Route;
                    row.Index = field.Index;
                    row.CmdType = type.Source.DisplayName();
                    row.Name = field.Name;
                    row.Expression = field.Description;
                    row.DataType = field.DataType;
                }
            }
            return dst;
        }

        public static ExecToken emit(IWfChannel channel, CmdDefs src, IDbArchive dst)
            => channel.TableEmit(fields(src.View), dst.Table<CmdFieldRow>());
                
        public static BoundCmd<T> bind<T>(CmdDefs defs, CmdArgs args)
            where T : IApiCmd<T>,new()
        {
            var cmd = new T();
            var def = CmdDef.Empty;
            defs.Find(cmd.Route, out def);
            iteri(args.View, (i,arg) => {
                var field = CmdField.Empty;
                if(arg.IsNamed)
                    def.Field(arg.Name, out field);
                else
                    def.Field((ushort)i, out field);                
                if(field.IsNonEmpty)
                {

                }
            });


            return (cmd,args);            
        }

   }
}