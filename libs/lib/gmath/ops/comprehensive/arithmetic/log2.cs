//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class gmath
    {
        [MethodImpl(Inline), Closures(UnsignedInts)]
        public static T log2<T>(T a)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(math.log2(uint8(a)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(math.log2(uint16(a)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(math.log2(uint32(a)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(math.log2(uint64(a)));
            else
                throw no<T>();
        }
    }
}