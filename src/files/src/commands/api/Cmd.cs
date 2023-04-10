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
        [Op, Closures(UInt64k)]
        public static CmdArgs reflect<T>(in T src)
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
            return buffer;
        }        

        public static CmdArgs args<T>(T src)
            where T : ICmd
                => typeof(T).DeclaredInstanceFields().Select(f => new CmdArg(f.Name, f.GetValue(src)?.ToString() ?? EmptyString));

        public static CmdArgs args<T>(params T[] src)
            where T : new()
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg<T>(skip(src,i));
            return new (dst);
        }

        public static ReadOnlySpan<CmdFlow> flows(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var counter = 0u;
            var dst = span<CmdFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                if(line.IsEmpty)
                    continue;

                var content = line.Content;
                var j = text.index(content, Chars.Colon);
                if(j >= 0)
                {
                    Tool tool = text.left(content, j);
                    var flow = Fenced.unfence(text.right(content,j), Fenced.Bracketed);

                    j = text.index(flow, "--");
                    if(j == NotFound)
                        j = text.index(flow, "->");

                    if(j>=0)
                    {
                        var a = text.left(flow,j).Trim();
                        var b = text.right(flow,j+2).Trim();
                        if(nonempty(a) && nonempty(b))
                            seek(dst,counter++) = new CmdFlow(tool, FS.path(a), FS.path(b));
                    }
                }
            }

            return slice(dst,0,counter);
        }

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

        public static CmdDefs defs(Assembly[] src)
            => new (tagged(src).Concrete().Select(def).Sort());

        public static CmdDef def(Type src)
            => new CmdDef(route(src), src, fields(src));

        public static ReadOnlySeq<CmdField> fields(Type src)
            => src.PublicInstanceFields().Mapi((i,x) =>  field((ushort)i,x));

        static Type[] tagged(Assembly[] src)
            =>  src.Types().Tagged<CmdAttribute>();

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

        public static void parse(FilePath src, out ApiCmdScript dst)
        {
            var specs = list<ApiCmdSpec>();
            var spec = ApiCmdSpec.Empty;
            using var reader = src.Utf8LineReader();
            var line = TextLine.Empty;

            while(reader.Next(out line))
            {
                var content = line.Content.Trim();
                if(text.nonempty(content))                
                if(parse(content, out spec))
                    specs.Add(spec);
            }

            dst = new (src, specs.ToArray());
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

        public static ICmd reify(Type src)
            => (ICmd)Activator.CreateInstance(src);

        public static CmdResult<C,P> result<C,P>(C spec, ExecToken token, bool suceeded, P payload = default)
            where C : ICmd, new()
            where P : INullity, new()
                => new CmdResult<C, P>(spec,token,suceeded,payload);

        [Op]
        public static CmdLine pwsh(string spec)
            => $"pwsh.exe {spec}";

        public static CmdLine pwsh(FilePath src, string args)
            => string.Format("pwsh.exe {0} {1}", src.Format(PathSeparator.BS), args);

        public static CmdLine pwsh(FilePath src)
            => string.Format("pwsh.exe {0}", src.Format(PathSeparator.BS));        

        public static CmdLine cmdline(params CmdArg[] args)
            => new CmdLine(args);

        public static CmdLine cmdline(params object[] args)
            => new CmdLine(args.Select(x => x?.ToString() ?? EmptyString));

        [Op]
        public static CmdLine cmd<T>(T src)
            => $"cmd.exe /c {src}";

        [Op]
        public static CmdLine cmd(string spec)
            => string.Format("cmd.exe /c {0}", spec);

        [Op]
        public static CmdLine cmd(FilePath src, CmdArgs args)
            => string.Format("cmd.exe /c {0} {1}", args.Format());

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
            => new CmdArg(src?.ToString() ?? EmptyString);
        // {            
        //     var data = src?.ToString() ?? EmptyString;
        //     var i = text.index(data, '=');
        //     var name = EmptyString;
        //     var value = data;
        //     if(i > 0)
        //     {
        //         name = text.left(data,i).RemoveAny('-');
        //         value = text.right(data,i);
        //     }
        //     return new (name,value);
        // }

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