//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiTableDefs
    {
        [Op]
        public static ApiTableDef def(Type src)
        {
            var fields = src.DeclaredInstanceFields();
            var count = fields.Length;
            if(count == 0)
                return new ApiTableDef(TableId.identify(src), src.Name, sys.empty<TableFieldDef>());
            var specs = sys.alloc<TableFieldDef>(count);
            for(var i=z16; i<count; i++)
            {
                var field = skip(fields,i);
                seek(specs,i) = new TableFieldDef(i, Tables.name(field), field.FieldType.CodeName());
            }

            return new ApiTableDef(TableId.identify(src), src.Name, specs);
        }

        public static ApiTableDef def<T>()
            where T : struct
                => def(typeof(T));        
        [Op]
        public static Index<ApiTableDef> defs(ReadOnlySpan<Type> src)
        {
            var count = src.Length;
            var dst = alloc<ApiTableDef>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = def(skip(src,i));
            return dst;
        }

        [Op]
        public static Index<ApiTableDef> defs(params Assembly[] src)
            => defs(src.Types().Tagged<RecordAttribute>());
    }
}