//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiTypes
    {
        public static Index<ApiTypeInfo> describe(ReadOnlySeq<DataType> types)
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

        public static ReadOnlySeq<DataType> discover(Assembly[] src)
        {
            var types = src.Types().Where(t => (t.IsStruct() || t.IsClass)  && t.Reifies<IDataType>()).Ignore().Index();
            var count = types.Count;
            var dst = sys.alloc<DataType>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = new DataType(types[i], Sizes.measure(types[i]));
            return dst.Sort();
        }
    }
}