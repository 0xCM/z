//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Conforms a source value as needed to yield a value of bit-width 16
        /// </summary>
        /// <param name="src">The input value</param>
        /// <typeparam name="T">The input type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static ushort bw16<T>(T src)
            where T : unmanaged
        {
            if(width<T>() == 8)
                return u8(src);
            if(width<T>() == 16)
                return u16(src);
            else if(width<T>() == 32)
                return (ushort)u32(src);
            else
                return (ushort)u64(src);
        }
    }
}