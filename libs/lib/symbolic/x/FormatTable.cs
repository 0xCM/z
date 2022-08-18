//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Formats a span as a table
        /// </summary>
        /// <param name="src">The source data to be formatted</param>
        /// <param name="rowcount">The number of rows in the output table</param>
        /// <param name="colcount">The number of columns in the output table</param>
        /// <param name="cellsep">The character that intersperses the cells of each row</param>
        /// <param name="rowsep">The character that intersperses the rows </param>
        /// <param name="padlen">The optional padding for each cell; if less than zero the calls are left-padded; if greater than zero, the cells are right-padded</param>
        /// <param name="padchar">The optional pad character; if unspecified and padlen is specified it defaults to a space</param>
        /// <typeparam name="T">The span element type</typeparam>
        [Op, Closures(Closure)]
        public static string FormatTable<T>(this Span<T> src, int rowcount, int colcount,
            int? padlen = null, char? padchar = null, char? rowsep = null, char? cellsep = null)
                where T : unmanaged
        {
            const char lf = '\n';
            const string crlf = "\r\n";
            const char pipe = '|';

            var rowlen = colcount;
            var cells = rowcount * colcount;
            var sb = string.Empty.Build();
            var lastIx = cells - 1;
            var nextrow = rowsep ?? lf;
            var nextcell = cellsep ?? pipe;
            for(var i=0; i< cells; i++)
            {
                var cell = src[i].ToString();
                if(i != 0)
                {
                    if(IsRowHead(i,rowlen))
                        sb.Append($"{nextrow}");
                    else
                        sb.Append($"{nextcell} ");
                }
                if(padlen == null)
                    sb.Append(cell);
                else
                {
                    var pad = Math.Abs(padlen.Value);
                    var fill = padchar ?? ' ';
                    if(padlen < 0)
                        sb.Append(cell.PadLeft(pad, fill));
                    else
                        sb.Append(cell.PadRight(pad, fill));
                }
            }

            return sb.ToString();
        }

        [MethodImpl(Inline), Op]
        static bool IsRowHead(int index, int rowlen)
            => index == 0 || index % rowlen == 0;
    }
}