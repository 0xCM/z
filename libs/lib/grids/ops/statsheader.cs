//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct grids
    {
        /// <summary>
        /// Defines a standard header for a grid map summary line
        /// </summary>
        /// <param name="colpad">The amount by which to pad each column</param>
        /// <param name="delimiter">The column separator</param>
        [Op]
        public static string statsheader(int? colpad = null, char? delimiter = null)
        {
            var pad = colpad ?? 10;
            var sep = delimiter ?? Chars.Pipe;
            var dst = text.buffer();
            dst.Append($"name".PadRight(pad));
            dst.Append($" {sep} rows".PadRight(pad));
            dst.Append($" {sep} cols".PadRight(pad));
            dst.Append($" {sep} segsize".PadRight(pad));
            dst.Append($" {sep} points".PadRight(pad));
            dst.Append($" {sep} segs".PadRight(pad));
            dst.Append($" {sep} bits".PadRight(pad));
            dst.Append($" {sep} bytes".PadRight(pad));
            dst.Append($" {sep} v128".PadRight(pad));
            dst.Append($" {sep} v128/r".PadRight(pad));
            dst.Append($" {sep} v256".PadRight(pad));
            dst.Append($" {sep} v256/r".PadRight(pad));
            return dst.Emit();
        }
    }
}