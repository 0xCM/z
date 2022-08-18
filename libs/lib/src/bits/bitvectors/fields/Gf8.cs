//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Gf8
    {
        const byte Reducer = 0b1011;

        [MethodImpl(Inline), Op]
        public static byte clmul(byte a, byte b)
        {
            var p = cpu.clmul(a,b);
            p ^= cpu.clmul((byte)(p >> 3), Reducer);
            p ^= cpu.clmul((byte)(p >> 3), Reducer);
            return (byte)p;
        }

        /// <summary>
        /// Fills caller-allocated memory with a multiplication table
        /// </summary>
        /// <param name="min">The minimum operand value</param>
        /// <param name="max">The maximum operand value</param>
        [MethodImpl(Inline), Op]
        public static void products(byte min, byte max, ref byte dst)
        {
            byte index = 0;
            for(byte i=min; i<= max; i++)
            for(byte j=min; j<= max; j++)
                core.add(dst, index++) = clmul(i,j);
        }

        [MethodImpl(Inline), Op]
        public static void products(ref byte dst)
            => products(1, (byte)0b111, ref dst);

        /// <summary>
        /// Creates a complete multiplication table
        /// </summary>
        /// <param name="min">The minimum operand value</param>
        /// <param name="max">The maximum operand value</param>
        public static Matrix256<N7,byte> products()
        {
            var dst = Matrix.blockalloc<N7,byte>();
            products(1, (byte)0b111, ref dst.Unblocked[0]);
            return dst;
        }

        public static string FormatTable<N,T>(Matrix256<N,T> src)
            where T : unmanaged
            where N: unmanaged, ITypeNat
                => src.Format(render:x => BitStrings.scalar(x).Format());
    }
}