//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Digital
    {
        /// <summary>
        /// Extracts the four hi digits
        /// </summary>
        /// <param name="src">The encoded digit source</param>
        /// <param name="d7">The target for the eighth and most-significant digit</param>
        /// <param name="d6"></param>
        /// <param name="d5"></param>
        /// <param name="d4"></param>
        [MethodImpl(Inline), Op]
        public static void hi(ulong src, out byte d7, out byte d6, out byte d5, out byte d4)
        {
            d7 = (byte)digit(src,7);
            d6 = (byte)digit(src,6);
            d5 = (byte)digit(src,5);
            d4 = (byte)digit(src,4);
        }
    }
}