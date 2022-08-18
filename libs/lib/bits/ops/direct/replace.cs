//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        /// <summary>
        /// Replaces an index-delimited source segment with a specified value
        /// </summary>
        /// <param name="src"></param>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <param name="value"></param>
        [MethodImpl(Inline), Op]
        public static byte replace(byte src, byte i0, byte i1, byte value)
            => math.or(math.sll(value, (byte)(i1 - i0)), trim(src,i0,i1));

        /// <summary>
        /// Replaces an index-delimited source segment with a specified value
        /// </summary>
        /// <param name="src"></param>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <param name="value"></param>
        [MethodImpl(Inline), Op]
        public static ushort replace(ushort src, byte i0, byte i1, ushort value)
            => math.or(math.sll(value, (byte)(i1 - i0)), trim(src, i0,i1));

        /// <summary>
        /// Replaces an index-delimited source segment with a specified value
        /// </summary>
        /// <param name="src"></param>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <param name="value"></param>
        [MethodImpl(Inline), Op]
        public static uint replace(uint src, byte i0, byte i1, uint value)
            => math.or(math.sll(value, (byte)(i1 - i0)), trim(src,i0,i1));

        /// <summary>
        /// Replaces an index-delimited source segment with a specified value
        /// </summary>
        /// <param name="src"></param>
        /// <param name="i0"></param>
        /// <param name="i1"></param>
        /// <param name="value"></param>
        [MethodImpl(Inline), Op]
        public static ulong replace(ulong src, byte i0, byte i1, ulong value)
            => math.or(math.sll(value, (byte)(i1 - i0)), trim(src,i0,i1));
    }
}