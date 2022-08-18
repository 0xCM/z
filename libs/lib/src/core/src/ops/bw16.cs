//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
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
            if(Sized.width<T>() == 8)
                return u8(src);
            if(Sized.width<T>() == 16)
                return u16(src);
            else if(Sized.width<T>() == 32)
                return (ushort)u32(src);
            else
                return (ushort)u64(src);
        }
    }
}