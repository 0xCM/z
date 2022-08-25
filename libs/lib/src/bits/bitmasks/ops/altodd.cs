//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitMasks
    {
        /// <summary>
        /// Defines an alternating bit pattern 01 01...01
        /// </summary>
        /// <typeparam name="T">The primal unsigned type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T altodd<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(U8_AltOdd);
            else if(typeof(T) == typeof(ushort))
                return generic<T>(U16_AltOdd);
            else if(typeof(T) == typeof(uint))
                return generic<T>(U32_AltOdd);
            else if(typeof(T) == typeof(ulong))
                return generic<T>(U64_AltOdd);
            else
                throw no<T>();
        }

        const byte U8_AltOdd = 0x55;

        const ushort U16_AltOdd = 0x5555;

        const uint U32_AltOdd = 0x55555555;

        const ulong U64_AltOdd = 0x5555555555555555;
    }
}