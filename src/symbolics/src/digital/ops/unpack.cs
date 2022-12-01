//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct Digital
    {
        /// <summary>
        /// Extracts eight digits from corresponding source bytes
        /// </summary>
        /// <param name="src">The digit source</param>
        /// <param name="count">The digit count selector</param>
        /// <param name="dst">The digit receiver</param>
        [MethodImpl(Inline), Op]
        public static void unpack(Base10 @base, ulong src, N8 count, ref byte dst)
        {
            add(dst, 7) = (byte)digit(@base, src, 7);
            add(dst, 6) = (byte)digit(@base, src, 6);
            add(dst, 5) = (byte)digit(@base, src, 5);
            add(dst, 4) = (byte)digit(@base, src, 4);
            add(dst, 3) = (byte)digit(@base, src, 3);
            add(dst, 2) = (byte)digit(@base, src, 2);
            add(dst, 1) = (byte)digit(@base, src, 1);
            add(dst, 0) = (byte)digit(@base, src, 0);
        }
    }
}