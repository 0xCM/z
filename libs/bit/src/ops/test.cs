//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static sys;

    partial struct bit
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit test<T>(in T src, uint i)
            where  T : unmanaged
                => test(skip(bytes(src),i/8), (byte)(i % 8));

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(sbyte src, byte pos)
            => new bit((src & (1 << pos)) != 0);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(byte src, byte pos)
            => new bit(((uint)src >> pos) & 1);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(short src, byte pos)
            => new bit((src & (1 << pos)) != 0);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(ushort src, byte pos)
            => new bit(((uint)src >> pos) & 1);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(int src, byte pos)
            => new bit((src & (1 << pos)) != 0);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(long src, byte pos)
            => new bit((src & (1L << pos)) != 0);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(uint src, byte pos)
            => new bit((src >> pos) & 1u);

        /// <summary>
        /// Tests the state of an index-identified source bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), TestBit]
        public static bit test(ulong src, byte pos)
            => new bit((uint)((src >> pos) & 1ul));

        /// <summary>
        /// Determines the state of an index-identified bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), TestBit]
        public static unsafe bit test(float src, byte pos)
            => test(As<float,uint>(ref AsRef<float>(&src)),pos);

        /// <summary>
        /// Determines the state of an index-identified bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), TestBit]
        public static unsafe bit test(double src, byte pos)
            => test(As<double,ulong>(ref AsRef<double>(&src)),pos);

        /// <summary>
        /// Determines the state of an index-identified bit
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="pos">The 0-based index of the bit to test</param>
        [MethodImpl(Inline), TestBit]
        public static unsafe bit test(decimal src, byte pos)
        {
            ref var lo = ref As<decimal,ulong>(ref Unsafe.AsRef<decimal>(&src));
            ref var hi = ref Add(ref lo, 1);
            return pos < 64 ? test(lo,pos) : test(hi,pos);
        }

        /// <summary>
        /// Returns 1 if an index-identified bit is enabled, false otherwise
        /// </summary>
        /// <param name="src">The value to test</param>
        /// <param name="pos">The bit index to check</param>
        [MethodImpl(Inline), TestBit, Closures(NumericKind.Integers)]
        public static bit gtest<T>(T src, byte pos)
            where T : unmanaged
        {
            if(size<T>() == 1)
                 return bit.test(sys.u8(src), pos);
            else if(size<T>() == 2)
                 return bit.test(sys.u16(src), pos);
            else if(size<T>() == 4)
                 return bit.test(sys.u32(src), pos);
            else
                return bit.test(sys.u64(src), pos);
        }

        [MethodImpl(Inline)]
        public static bit gtest<T,I>(T src, I index)
            where T : unmanaged
            where I : unmanaged
                => gtest<T>(src, sys.u8(index));
    }
}