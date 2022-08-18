//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Enums
    {
        [Op]
        public static ClrEnumRecord[] records(Assembly src)
        {
            var types = src.GetTypes().Where(t => t.IsEnum);
            var dst = list<ClrEnumRecord>();
            for(var i=0; i<types.Length; i++)
                dst.AddRange(records(types[i]));
            return dst.ToArray();
        }

        [Op]
        public static ClrEnumRecord[] records(Type src)
        {
            var ut = src.GetEnumUnderlyingType();
            var nk = ut.NumericKind();

            var fields = span(src.LiteralFields());
            var count = fields.Length;
            var buffer = alloc<ClrEnumRecord>(count);
            var index = span(buffer);
            var assembly = src.Assembly;
            var part = assembly.Id();

            for(var i=0u; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                fill(part, field,i, ref seek(index, i));
            }

            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static ref ClrEnumRecord fill(PartId part, FieldInfo field, uint index, ref ClrEnumRecord dst)
        {
            dst.PartId = part;
            dst.TypeId = field.DeclaringType.MetadataToken;
            dst.TypeName = field.DeclaringType.Name;
            dst.FieldId = field.MetadataToken;
            dst.FieldName = field.Name;
            dst.EnumKind = field.DeclaringType.EnumScalarKind();
            dst.LiteralValue = (ulong)NumericBox.rebox(field.GetRawConstantValue(), UInt64k);
            dst.Position = index;
            return ref dst;
        }
    }
}