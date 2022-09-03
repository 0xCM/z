//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RpOps
    {
        [MethodImpl(Inline), Op]
        public static string pad(int pad)
            => pad == 0 ? "{0}" : "{0," + pad.ToString() + "}";

        /// <summary>
        /// Defines the format pattern '{n,pad}'
        /// </summary>
        /// <param name="n">The zero-based slot index</param>
        /// <param name="pad">The pad width specifier</param>
        [MethodImpl(Inline), Op]
        public static string pad(uint n, int pad)
            => "{0" + n.ToString() + "," + pad.ToString() + "}";
    }
}