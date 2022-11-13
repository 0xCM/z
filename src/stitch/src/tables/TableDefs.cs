//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class TableDefs
    {
        [Op]
        public static TableDef def(Type src)
        {
            var fields = src.DeclaredInstanceFields();
            var count = fields.Length;
            if(count == 0)
                return new TableDef(TableId.identify(src), src.Name, sys.empty<TableField>());
            var specs = sys.alloc<TableField>(count);
            for(var i=z16; i<count; i++)
            {
                var field = skip(fields,i);
                seek(specs,i) = new TableField(i, ReflectedField.name(field), field.FieldType.CodeName());
            }

            return new TableDef(TableId.identify(src), src.Name, specs);
        }

        public static TableDef def<T>()
            where T : struct
                => def(typeof(T));        
        [Op]
        public static Index<TableDef> defs(ReadOnlySpan<Type> src)
        {
            var count = src.Length;
            var dst = alloc<TableDef>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = def(skip(src,i));
            return dst;
        }

        [Op]
        public static Index<TableDef> defs(params Assembly[] src)
            => defs(src.Types().Tagged<RecordAttribute>());
    }
}