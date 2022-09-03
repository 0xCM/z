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
    using static Numeric;

    using SB = BitSpan32Scalars;

    partial class BitSpans32
    {
        /// <summary>
        /// Extracts a scalar value from a bitspan
        /// </summary>
        /// <param name="src">The bitspan source</param>
        /// <param name="offset">The source index to begin extraction</param>
        /// <param name="count">The number of source bits that contribute to the extract</param>
        /// <typeparam name="T">The scalar type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T extract<T>(in BitSpan32 src, int offset = 0)
            where T : unmanaged
                => extract_u<T>(src,offset);

        [MethodImpl(Inline)]
        static T extract_u<T>(in BitSpan32 src, int offset = 0)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(SB.extract8(src, offset));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(SB.extract16(src, offset));
            else if(typeof(T) == typeof(uint))
                return generic<T>(SB.extract32(src, offset));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(SB.extract64(src, offset));
            else
                return extract_i<T>(src,offset);
        }

        [MethodImpl(Inline)]
        static T extract_i<T>(in BitSpan32 src, int offset = 0)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return force<T>(SB.extract8(src, offset));
            else if(typeof(T) == typeof(short))
                return force<T>(SB.extract16(src, offset));
            else if(typeof(T) == typeof(int))
                return force<T>(SB.extract32(src, offset));
            else if(typeof(T) == typeof(long))
                return force<T>(SB.extract64(src, offset));
            else
                throw no<T>();
        }
    }
}