//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics.X86;

    partial class bits
    {
        /// <summary>
        /// Counts the number of leading zero bits in the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Nlz]
        public static byte nlz(byte src)
            => (byte)(Lzcnt.LeadingZeroCount((uint)src) - 24);

        /// <summary>
        /// Counts the number of leading zero bits in the source
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Nlz]
        public static byte nlz(ushort src)
            => (byte)(Lzcnt.LeadingZeroCount((uint)src) - 16);

        /// <summary>
        /// _lzcnt_u32
        /// Counts the number of 0 bits prior to the first most significant 1 bit
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Nlz]
        public static byte nlz(uint src)
            => (byte)Lzcnt.LeadingZeroCount(src);

        /// <summary>
        /// _lzcnt_u64:
        /// Counts the number of 0 bits prior to the first most significant 1 bit
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Nlz]
        public static byte nlz(ulong src)
            => (byte)Lzcnt.X64.LeadingZeroCount(src);
    }
}