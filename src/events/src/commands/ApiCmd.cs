//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiCmd
    {
        public static ProjectContext context(IProject src)
            => new ProjectContext(src, CmdFlows.flows(src));

        [Op, Closures(UInt64k)]
        public static CmdArgs reflect<T>(in T src)
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

        public static CmdArgs args<T>()
            where T : ICmd
                => typeof(T).DeclaredInstanceFields().Select(arg);

        public static CmdArg arg(FieldInfo src)
        {
            var attrib = src.Tag<CmdArgAttribute>();
            var name = attrib.MapValueOrDefault(a => a.Name, src.Name);
            var desc = attrib.MapValueOrDefault(a => a.Description, EmptyString);
            return new (name,desc);
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
                dst = new ApiCmdSpec(name, args(_args));
            }
            return true;
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