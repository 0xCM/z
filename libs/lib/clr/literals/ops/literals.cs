//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct ClrLiterals
    {
        [MethodImpl(Inline), Op]
        public static FieldInfo[] literals(FieldInfo[] src)
            => src.Where(x => x.IsLiteral);

        [Op, Closures(Closure)]
        public static LiteralFields literals(Type type)
        {
            var fields = type.Fields().Literals();
            var count = (uint)fields.Length;
            var nameBuffer = alloc<string>(count);
            var valueBuffer = alloc<object>(count);
            ref var names = ref first(span(nameBuffer));
            ref var values = ref first(span(valueBuffer));
            var src = span(fields);
            for(var i=0u; i<count; i++)
            {
                ref readonly var field = ref skip(src,i);
                seek(names,i) = field.Name;
                seek(values, i) = field.GetRawConstantValue();
            }
            return new LiteralFields(fields, nameBuffer, valueBuffer);
        }

        [Op]
        public static Index<NumericLiteral> literals(Type src, Base2 b)
        {
            var fields = span(src.LiteralFields());
            var dst = list<NumericLiteral>();
            for(var i=0u; i<fields.Length; i++)
            {
                ref readonly var field = ref skip(fields,i);
                var tc = Type.GetTypeCode(field.FieldType);
                var vRaw = field.GetRawConstantValue();
                dst.Add(ClrLiterals.numeric(b,field.Name, vRaw, BitRender.format(vRaw, tc)));
            }
            return dst.ToArray();
        }

        [Op]
        public static Span<ClrFieldAdapter> literals(ReadOnlySpan<ClrFieldAdapter> src, Span<ClrFieldAdapter> dst)
        {
            var k = 0u;
            var count = src.Length;
            for(var i=0u; i<count; i++)
                if(skip(src,i).IsLiteral)
                    seek(dst, k++) = skip(src,i);
            return slice(dst,k);
        }

        [Op]
        public static Span<ClrFieldAdapter> literals(Type src, Span<ClrFieldAdapter> dst)
            => literals(Clr.adapt(src.GetFields(BF)), dst);
    }
}