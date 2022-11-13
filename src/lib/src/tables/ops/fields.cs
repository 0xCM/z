//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Tables
    {
        /// <summary>
        /// Discerns a <see cref='ReflectedFields'/> for a parametrically-identified record type
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static ReflectedField[] fields<T>()
            where T : struct
                => fields(typeof(T));

        /// <summary>
        /// Discerns a <see cref='ReflectedFields'/> for a specified record type
        /// </summary>
        /// <param name="src">The record type</typeparam>
        [Op]
        public static ReflectedField[] fields(Type src)
        {
            var fields = src.DeclaredPublicInstanceFields().Ignore().Index();
            var count = fields.Count;
            var dst = sys.alloc<ReflectedField>(count);
            for(var i=z32; i<count; i++)
            {
                ref readonly var field = ref fields[i];
                var tag = field.Tag<RenderAttribute>();
                if(tag)
                {
                    var tv = tag.Value;
                    seek(dst,i) = new ReflectedField(new CellRenderSpec(i, tv.Width, TextFormat.formatter(field.FieldType, (ushort)tv.Style)), field);
                }
                else
                {
                    seek(dst,i) = new ReflectedField(new CellRenderSpec(i, 16, TextFormat.formatter(field.FieldType)), field);
                }

            }
            return dst;
        }
    }
}