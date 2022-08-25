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
        /// Defines an alternating bit pattern 10 10...10
        /// </summary>
        /// <typeparam name="T">The primal unsigned type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T alteven<T>()
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(U8_AltEven);
            else if(typeof(T) == typeof(ushort))
                return generic<T>(U16_AltEven);
            else if(typeof(T) == typeof(uint))
                return generic<T>(U32_AltEven);
            else if(typeof(T) == typeof(ulong))
                return generic<T>(U64_AltEven);
            else
                throw no<T>();
        }

        const byte U8_AltEven = 0xAA;

        const ushort U16_AltEven = 0xAAAA;

        const uint U32_AltEven = 0xAAAAAAAA;

        const ulong U64_AltEven = 0xAAAAAAAAAAAAAAAA;
    }
}