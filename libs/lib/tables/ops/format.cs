//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Tables
    {
        // [Op, Closures(Closure)]
        // public static string format<T>(in RowFormatSpec rowspec, in DynamicRow<T> src)
        //     where T : struct
        // {
        //     var content = string.Format(rowspec.Pattern, src.Cells);
        //     var pad = rowspec.RowPad;
        //     if(pad == 0)
        //         return content;
        //     else
        //         return content.PadRight(pad);
        // }


        /// <summary>
        /// Formats a <see cref='RowHeader'/>
        /// </summary>
        /// <param name="src">The source header</param>
        public static string format(RowHeader src)
        {
            var dst = text.buffer();
            for(var i=0; i<src.Count; i++)
            {
                if(i != 0)
                    dst.Append(src.Delimiter);

                dst.Append(src[i].Format());
            }
            return dst.ToString();
        }
   }
}