//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static core;

    partial struct Clr
    {
        [Op]
        public static void offsets(Type src, Span<ushort> dst)
        {
            var fields = span(src.DeclaredFields());
            offsets(src,fields,dst);
        }

        [Op]
        public static void offsets(Type src, ReadOnlySpan<FieldInfo> fields, Span<ushort> dst)
        {
            var count = fields.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                seek(dst,i) = offset(src,f);
            }
        }

        [Op]
        public static ushort[] offsets(Type host, Index<FieldInfo> fields)
            => fields.Select(f => offset(host,f));
    }
}