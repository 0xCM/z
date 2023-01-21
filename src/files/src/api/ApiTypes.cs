//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class ApiTypes
    {
        public static TypeList list(FileUri src)
        {
            var lines = src.ReadLines(skipBlank:true);
            var count = lines.Count;
            var dst = sys.alloc<TypeListEntry>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var type = Type.GetType(line) ?? typeof(void);
                seek(dst,i) = type;
            }
            
            return new (src.FileName().WithoutExtension.Name, dst);
        }
    
        static uint CountFields(Index<Type> tables)
        {
            var counter = 0u;
            for(var i=0; i<tables.Count; i++)
                counter += tables[i].DeclaredInstanceFields().Ignore().Index().Count;
            return counter;
        }

        public static ReadOnlySeq<ApiTableField> tablefields(ReadOnlySeq<Assembly> src)
        {
            var tables = src.Storage.Types().Tagged<RecordAttribute>().Index();
            var count = CountFields(tables);
            var buffer = alloc<ApiTableField>(count);
            var k=0u;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var type = ref tables[i];
                var fields = TableDefs.cells(type);
                var total = 0u;
                var id = TableId.identify(type).Format();
                var typename = type.DisplayName();
                for(var j=z16; j<fields.Length; j++, k++)
                {
                    ref readonly var tf = ref skip(fields,j);
                    ref readonly var fd = ref tf.Definition;
                    ref var dst = ref seek(buffer,k);
                    var size = (ushort)(Sizes.bits(fd.FieldType)/8);
                    total += size;
                    dst.Seq = j;
                    dst.TableId = id;
                    dst.TableType = typename;
                    dst.Col = j;
                    dst.FieldSize = size;
                    dst.TableSize = total;
                    dst.RenderWidth = tf.CellWidth;
                    dst.FieldName = fd.Name;
                    dst.FieldType = fd.FieldType.DisplayName();
                }
            }
            return buffer;
        }

        static Index<DataFlow> discover(Assembly[] src)
        {
            var types = src.Types().Concrete().Tagged<DataFlowAttribute>();
            var count = types.Length;
            var buffer = alloc<DataFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(types,i);
                var f = type.Field("Instance");
                seek(buffer,i) = new DataFlow((IDataFlow)f.GetValue(null));
            }
            return buffer;
        }


        [Op]
        public static ReadOnlySeq<DataFlowSpec> flows(Assembly[] src)
        {
            var flows = discover(src);
            var count = flows.Length;
            var buffer = alloc<DataFlowSpec>(count);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var flow = ref flows[i];
                dst.Actor = flow.Actor;
                dst.Source = flow.Source?.ToString() ?? EmptyString;
                dst.Target = flow.Target?.ToString() ?? EmptyString;
                dst.Description = flow.Format();
            }
            return buffer.Sort();
        }

        [Op]
        public static ReadOnlySeq<ApiDataType> data(Assembly[] src)
        {
            var types = src.Types().Where(t => (t.IsStruct() || t.IsClass)  && t.Reifies<IDataType>()).Ignore().Index();
            var count = types.Count;
            var dst = sys.alloc<ApiDataType>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = new ApiDataType(types[i], Sizes.measure(types[i]));
            return dst.Sort();
        }

        [Op]
        public static Index<ApiTypeInfo> describe(ReadOnlySeq<ApiDataType> types)
        {
            var count = types.Count;
            var dst = sys.alloc<ApiTypeInfo>(count);
            for(var i=0; i<count; i++)
            {
                ref var record = ref seek(dst,i);
                ref readonly var type = ref types[i];
                record.Part = type.Part;
                record.Name = type.Name;
                record.Concrete = type.Definition.IsConcrete();
                record.NativeSize = type.Size.Native/8;
                record.NativeWidth = type.Size.Native;
                record.PackedWidth = type.Size.Packed;
            }

            return dst;
        }
    }
}