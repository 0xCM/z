//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Bmi1;
    using static System.Runtime.Intrinsics.X86.Bmi1.X64;

    partial class bits
    {
        /// <summary>
        /// unsigned int _blsr_u32 (unsigned int a) BLSR reg, reg/m32
        /// Logically equivalent to the composite operation (src - 1) & src that disables the least set bit in the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), LsbOff]
        public static byte lsboff(byte src)
            => (byte)ResetLowestSetBit(src);

        /// <summary>
        /// unsigned int _blsr_u32 (unsigned int a) BLSR reg, reg/m32
        /// Logically equivalent to the composite operation (src - 1) & src that disables the least set bit in the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), LsbOff]
        public static ushort lsboff(ushort src)
            => (ushort)ResetLowestSetBit(src);

        /// <summary>
        /// unsigned int _blsr_u32 (unsigned int a) BLSR reg, reg/m32
        /// Logically equivalent to the composite operation (src - 1) & src that disables the least set bit in the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), LsbOff]
        public static uint lsboff(uint src)
            => ResetLowestSetBit(src);

        /// <summary>
        /// unsigned __int64 _blsr_u64 (unsigned __int64 a) BLSR reg, reg/m64
        /// Logically equivalent to the composite operation (src - 1) & src that disables the least set bit in the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), LsbOff]
        public static ulong lsboff(ulong src)
            => ResetLowestSetBit(src);
    }
}