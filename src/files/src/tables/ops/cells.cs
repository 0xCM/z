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
        /// Discerns a <see cref='ClrTableCells'/> for a parametrically-identified record type
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static ClrTableCell[] cells<T>()
            => cells(typeof(T));

        /// <summary>
        /// Discerns a <see cref='ClrTableCells'/> for a specified record type
        /// </summary>
        /// <param name="src">The record type</typeparam>
        [Op]
        public static ClrTableCell[] cells(Type src)
        {
            var fields = src.DeclaredPublicInstanceFields().Ignore().Index();
            var count = fields.Count;
            var dst = sys.alloc<ClrTableCell>(count);
            for(var i=z32; i<count; i++)
            {
                ref readonly var field = ref fields[i];
                var tag = field.Tag<RenderAttribute>();
                if(tag)
                {
                    var tv = tag.Value;
                    seek(dst,i) = new ClrTableCell(new CellRenderSpec(i, tv.Width, TextFormat.formatter(field.FieldType, (ushort)tv.Style)), field);
                }
                else
                {
                    seek(dst,i) = new ClrTableCell(new CellRenderSpec(i, 16, TextFormat.formatter(field.FieldType)), field);
                }

            }
            return dst;
        }
    }
}