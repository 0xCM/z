//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Determines whether an index-identified bit is enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="index">The 0-based position to test</param>
        [MethodImpl(Inline), TestBit, Closures(Closure)]
        public static bit testbit<T>(ScalarBits<T> src, byte index)
            where T : unmanaged
                => gbits.test(src.State, index);

        /// <summary>
        /// Determines whether an index-identified bit is enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="index">The 0-based position to test</param>
        [MethodImpl(Inline)]
        public static bit testbit<N,T>(ScalarBits<N,T> src, byte index)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.test(src.State, index);

        /// <summary>
        /// Determines whether an index-identified bit is enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="index">The 0-based position to test</param>
        [MethodImpl(Inline), TestBit, Closures(Closure)]
        public static bit testbit<T>(BitVector128<T> src, byte index)
            where T : unmanaged
                => index < 64 ? bit.test(src.Lo, index) : bit.test(src.Hi, (byte)(index - 64));

        /// <summary>
        /// Determines whether an index-identified bit is enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="index">The 0-based position to test</param>
        [MethodImpl(Inline), TestBit, Closures(Closure)]
        public static bit testbit<T>(BitVector256<T> src, byte index)
            where T : unmanaged
        {
            const byte SegWidth = 64;
            var pos = (ushort)index;
            if(pos < SegWidth)
                return bit.test(seg64(src,n0), (byte)(pos - 0*SegWidth));
            if(pos < 2*SegWidth)
                return bit.test(seg64(src,n1), (byte)(pos - 1*SegWidth));
            if(pos < 3*SegWidth)
                return bit.test(seg64(src,n2), (byte)(pos - 2*SegWidth));
            else
                return bit.test(seg64(src,n3), (byte)(pos - 3*SegWidth));
        }
    }
}