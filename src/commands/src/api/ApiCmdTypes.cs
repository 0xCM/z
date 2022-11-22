//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static ApiDb;

    [ApiHost, Free]
    public class ApiCmdTypes
    {
        public static ICmd reify(Type src)
            => (ICmd)Activator.CreateInstance(src);

        public static ReadOnlySeq<ApiCmdRow> records(Assembly[] src)
            => ApiDb.rows(discover(src));

        [Op]
        public static ICmd[] reify(Assembly src)
            => ApiCmdTypes.tagged(src).Select(reify);

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

        public static string format(CmdField src)
            => string.Format($"{src.FieldName}:{src.Expr}");

        public static string expr(FieldInfo src)
            => src.Tag<CmdArgAttribute>().MapValueOrDefault(x => text.ifempty(x.Expression,src.Name), src.Name);

        public static Index<CmdField> fields(Type src)
            => src.DeclaredInstanceFields().Mapi((i,x) => new CmdField((byte)i, x, expr(x)));

        public static Type[] tagged(Assembly src)
            =>  src.Structs().Tagged<CmdAttribute>();

        public static Type[] tagged(Assembly[] src)
            =>  src.Structs().Tagged<CmdAttribute>();

        public static CmdTypeInfo describe(Type src)
            => new CmdTypeInfo(identify(src), src, fields(src));

        public static ReadOnlySeq<CmdTypeInfo> discover(Assembly[] src)
            => tagged(src).Select(describe).Sort();
    }
}