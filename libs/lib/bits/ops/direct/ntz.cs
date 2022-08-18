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
        /// int _mm_tzcnt_32 (unsigned int a) TZCNT reg, reg/m32
        /// Counts the number of trailing zero bits in the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Ntz]
        public static byte ntz(byte src)
           => tzcnt(src);

        /// <summary>
        /// int _mm_tzcnt_32 (unsigned int a) TZCNT reg, reg/m32
        /// Counts the number of trailing zero bits in the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Ntz]
        public static ushort ntz(ushort src)
           => tzcnt(src);

        /// <summary>
        /// int _mm_tzcnt_32 (unsigned int a) TZCNT reg, reg/m32
        /// Counts the number of trailing zero bits in the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Ntz]
        public static uint ntz(uint src)
           => tzcnt(src);

        /// <summary>
        /// __int64 _mm_tzcnt_64 (unsigned __int64 a) TZCNT reg, reg/m64
        /// Counts the number of trailing zero bits in the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Ntz]
        public static ulong ntz(ulong src)
           => tzcnt(src);
    }
}