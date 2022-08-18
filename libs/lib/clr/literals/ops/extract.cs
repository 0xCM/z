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
        public static void extract(ReadOnlySpan<FieldInfo> fields, Span<object> dst)
        {
            var count = fields.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = skip(fields,i).GetRawConstantValue();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void extract<T>(ReadOnlySpan<FieldInfo> fields, Span<T> dst)
            where T : unmanaged
        {
            var count = fields.Length;
            for(var i=0u; i<count; i++)
                seek(dst,i) = (T)skip(fields,i).GetRawConstantValue();
        }

        [MethodImpl(Inline), Op]
        public static void extract(Type src, Span<string> dst)
        {
            var fields = span(src.DeclaredFields());
            var match = typeof(string);
            ref readonly var lead = ref first(fields);
            var count = fields.Length;

            var j=0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var field = ref skip(lead,i);
                if(field.IsLiteral && field.FieldType == match)
                    seek(dst,j++) = (string)field.GetRawConstantValue();
            }
        }
    }
}