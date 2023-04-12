//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiCmd
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

 
        public static CmdArg arg(FieldInfo src)
        {
            var attrib = src.Tag<CmdArgAttribute>();
            var name = attrib.MapValueOrDefault(a => a.Name, src.Name);
            var desc = attrib.MapValueOrDefault(a => a.Description, EmptyString);
            return new (name,desc);
        }

        public static ApiCmdDefs defs(Assembly[] src)
            => new (tagged(src).Concrete().Select(def).Sort());

        public static ApiCmdDef def(Type src)
            => new ApiCmdDef(route(src), src, fields(src));

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

        static void render(object src, ReadOnlySpan<ClrFieldAdapter> fields, ITextEmitter dst)
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

        public static void parse(FileUri src, out ApiCmdScript dst)
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
                dst = new ApiCmdSpec(name, args(_args));
            }
            return true;
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

        public static BoundCmd<T> bind<T>(ApiCmdDefs defs, CmdArgs args)
            where T : IApiCmd<T>,new()
        {
            var cmd = new T();
            var def = ApiCmdDef.Empty;
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
   
        static CmdArg arg(object src)
            => new CmdArg(src?.ToString() ?? EmptyString);

        static CmdArgs args(params object[] src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = arg(skip(src,i));
            return new (dst);
        }

        static CmdField field(ushort i, FieldInfo src)
        {
            var attrib = src.Tag<CmdArgAttribute>();
            var name = attrib.MapValueOrDefault(a => a.Name, src.Name);
            var desc = attrib.MapValueOrDefault(a => a.Description, EmptyString);
            return new CmdField(i, src, name, src.FieldType.DisplayName(), desc);
        }        
    }
}