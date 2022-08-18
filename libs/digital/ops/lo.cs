//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Digital
    {
        /// <summary>
        /// Extracts the four lo digits
        /// </summary>
        /// <param name="src">The encoded digit source</param>
        /// <param name="d3">The target for the fourth and most-significant digit</param>
        /// <param name="d2">The target for the third digit</param>
        /// <param name="d1">The target for the second digit</param>
        /// <param name="d0">The target for the first and least-significant digit</param>
        [MethodImpl(Inline), Op]
        public static void lo(ulong src, out byte d3, out byte d2, out byte d1, out byte d0)
        {
            d3 = (byte)digit(src,3);
            d2 = (byte)digit(src,2);
            d1 = (byte)digit(src,1);
            d0 = (byte)digit(src,0);
        }
    }
}