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

    public class t_scatter : t_bits<t_scatter>
    {
        public void sb_scatter_basecase()
        {
            var src1 = 0b00000000_00000000_00000000_10101010u;
            var m1 =   0b00000011_00000011_00000011_00000011u;
            var d1e =  0b00000010_00000010_00000010_00000010u;
            var d1a = bits.scatter(src1, m1);
            PrimalClaims.eq(d1e,d1a);
        }

        public void sb_scatter_8()
            => sb_scatter_check<byte>();

        public void sb_scatter_16()
            => sb_scatter_check<ushort>();

        public void sb_scatter_32()
            => sb_scatter_check<uint>();

        public void s_scatter_64()
            => sb_scatter_check<ulong>();

        /// <summary>
        /// Scatters contiguous low bits from the source across a target according to a mask
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The scatter spec</param>
        /// <typeparam name="T">The mask type</typeparam>
        [MethodImpl(Inline)]
        static T scatter<T>(T src, T mask)
            where T : unmanaged
        {
            if(typeof(T) == typeof(byte))
                return generic<T>(scatter(uint8(src), uint8(mask)));
            else if(typeof(T) == typeof(ushort))
                return generic<T>(scatter(uint16(src), uint16(mask)));
            else if(typeof(T) == typeof(uint))
                return generic<T>(scatter(uint32(src), uint32(mask)));
            else if(typeof(T) == typeof(ulong))
                return generic<T>(scatter(uint64(src), uint64(mask)));
            else
                throw no<T>();
        }

        /// <summary>
        /// Scatters contiguous low bits from the source across a target according to a mask
        /// </summary>
        /// <param name="src"></param>
        /// <param name="mask"></param>
        /// <remark>Algorithm adapted from Arndt, Matters Computational </remark>
        static byte scatter(byte src, byte mask)
        {
            var dst = (byte)0;
            var x = (byte)1;
            while (mask != 0)
            {
                byte i =  (byte)(mask & math.negate(mask));
                mask ^= i;
                dst += (byte)(((x & src) != 0 ? i : 0));
                x <<= 1;
            }
            return dst;
        }

        /// <summary>
        /// Scatters contiguous low bits from the source across a target according to a mask
        /// </summary>
        /// <param name="src"></param>
        /// <param name="mask"></param>
        /// <remark>Algorithm adapted from Arndt, Matters Computational </remark>
        static uint scatter(uint src, uint mask)
        {
            var dst = 0u;
            var x = 1u;
            while (mask != 0)
            {
                var i = mask & math.negate(mask);
                mask ^= i;
                dst += ((x & src) != 0 ? i : 0);
                x <<= 1;
            }
            return dst;
        }

        /// <summary>
        /// Scatters contiguous low bits from the source across a target according to a mask
        /// </summary>
        /// <param name="src"></param>
        /// <param name="mask"></param>
        /// <remark>Algorithm adapted from Arndt, Matters Computational </remark>
        static ushort scatter(ushort src, ushort mask)
        {
            var dst = (ushort)0;
            var x = (ushort)1;
            while (mask != 0)
            {
                ushort i =  (ushort)(mask & math.negate(mask));
                mask ^= i;
                dst += (ushort)(((x & src) != 0 ? i : 0));
                x <<= 1;
            }
            return dst;
        }

        /// <summary>
        /// Scatters contiguous low bits from the source across a target according to a mask
        /// </summary>
        /// <param name="src"></param>
        /// <param name="mask"></param>
        /// <remark>Algorithm adapted from Arndt, Matters Computational </remark>
        static ulong scatter(ulong src, ulong mask)
        {
            var dst = 0ul;
            var x = 1ul;
            while (mask != 0)
            {
                var i = mask & math.negate(mask);
                mask ^= i;
                dst += ((x & src) != 0 ? i : 0);
                x <<= 1;
            }
            return dst;
        }

        /// <summary>
        /// Generic scalar bit scatter check
        /// </summary>
        /// <typeparam name="T">The scalar type</typeparam>
        void sb_scatter_check<T>(T t = default)
            where T : unmanaged
        {
            for(var i=0; i<RepCount; i++)
            {
                var src = Random.Next<T>();
                var mask = Random.Next<T>();
                var a = scatter(src, mask);
                var b = gbits.scatter(src,mask);
                NumericClaims.eq(a,b);
            }
        }
    }
}