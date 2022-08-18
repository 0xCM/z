//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct DataLayouts
    {
        public const string PartitionFormat = "[{0}..{1})";

        [Op, MethodImpl(Inline)]
        public static string format(in LayoutPart src)
            => string.Format(PartitionFormat, src.Left, src.Right);

        [Op, MethodImpl(Inline)]
        public static string format<T>(in LayoutPart<T> src)
            where T : unmanaged
                => string.Format(PartitionFormat, src.Left, src.Right);

        [Op, MethodImpl(Inline)]
        public static string format<T,R>(in LayoutPart<T,R> src)
            where T : unmanaged
            where R : unmanaged
                => string.Format(PartitionFormat, src.Left, src.Right);

        [Op, Closures(Closure)]
        public static string format<T>(in LayoutIdentity<T> src)
            where T : unmanaged
                => string.Format("{0}:{1}", src.Index, src.Kind);

        [Op, Closures(Closure)]
        public static string format(in LayoutIdentity src)
            => string.Format("{0}:{1}", src.Index, src.Kind);

        [Op]
        public static string format(in DataLayout src)
        {
            var dst = text.buffer();
            render(src,dst);
            return dst.Emit();
        }

        [Op, Closures(Closure)]
        public static string format<T>(in DataLayout<T> src)
            where T : unmanaged
        {
            var buffer = text.buffer();
            buffer.Append(src.Id.Format());
            iter(src.Storage, part => buffer.Append(string.Format(" | {0}", part.Format())));
            return buffer.Emit();
        }

        [MethodImpl(Inline), Op]
        public static void render(in LayoutPart src, ITextBuffer dst)
            => dst.Append(DataLayouts.format(src));

        [Op]
        public static void render(in DataLayout src, ITextBuffer dst)
        {
            var count = src.PartitionCount;
            if(count != 0)
            {
                ref readonly var section = ref src.FirstPartition;
                dst.AppendLine(string.Format("{0} ", src.Index));
                dst.AppendLine(RpOps.PageBreak40);

                for(var i=0; i<count; i++)
                {
                    ref readonly var current = ref skip(section,i);
                    render(skip(section,i), dst);
                }

                dst.AppendLine(RpOps.PageBreak40);
            }
        }
    }
}