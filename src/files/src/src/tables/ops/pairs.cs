//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Tables
    {
        [Op, Closures(Closure)]
        public static string pairs<T>(in RowFormatSpec spec, in RowAdapter<T> src)
        {
            var dst = text.buffer();
            pairs(spec, src, dst);
            return dst.Emit();
        }

        [Op, Closures(Closure)]
        public static void pairs<T>(in RowFormatSpec spec, in RowAdapter<T> src, ITextBuffer dst)
        {
            var pattern = KvpPattern(spec);
            var fields = src.Fields.View;
            for(var i=0; i<src.CellCount; i++)
                dst.AppendLineFormat(pattern, skip(fields,i).MemberName, src[i]);
            dst.AppendLine();
        }
    }
}