//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using SB = BitSpan32Scalars;

    partial class BitSpans32
    {
        /// <summary>
        /// Creates a bitspan from a primal source
        /// </summary>
        /// <param name="src">The packed source bits</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static BitSpan32 from<T>(T src)
            where T : unmanaged
                => from_u(src);

        /// <summary>
        /// Creates a bitspan from a primal source, or portion thereof
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="maxbits">The maximum number of bits to draw from the source</param>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static BitSpan32 from<T>(T src, int maxbits)
            where T : unmanaged
        {
            var dst = from(src);
            return (dst.Length > maxbits && maxbits != 0) ? load(dst.Data.Slice(0, maxbits)) : dst;
        }

        [MethodImpl(Inline)]
        static BitSpan32 from_u<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return SB.from(uint8(src));
            else if(typeof(T) == typeof(ushort))
                return SB.from(uint16(src));
            else if(typeof(T) == typeof(uint))
                return SB.from(uint32(src));
            else if(typeof(T) == typeof(ulong))
                return SB.from(uint64(src));
            else
                return from_i(src);
        }

        [MethodImpl(Inline)]
        static BitSpan32 from_i<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(sbyte))
                return SB.from(Numeric.force<T,byte>(src));
            else if(typeof(T) == typeof(short))
                return SB.from(Numeric.force<T,ushort>(src));
            else if(typeof(T) == typeof(int))
                return SB.from(Numeric.force<T,uint>(src));
            else if(typeof(T) == typeof(long))
                return SB.from(Numeric.force<T,ulong>(src));
            else
                throw no<T>();
        }
    }
}