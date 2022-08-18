//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        /// <summary>
        /// Enables a bit in the target if it is enabled in the source
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="srcpos">The source bit position</param>
        /// <param name="dst">The target value</param>
        /// <param name="dstpos">The target bit position</param>
        [MethodImpl(Inline), Op]
        public static byte setif(byte src, byte srcpos, byte dst, byte dstpos)
        {
            if(bit.test(src, srcpos))
                return enable(dst, srcpos);
            return dst;
        }

        /// <summary>
        /// Enables a bit in the target if it is enabled in the source
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="srcpos">The source bit position</param>
        /// <param name="dst">The target value</param>
        /// <param name="dstpos">The target bit position</param>
        [MethodImpl(Inline), Op]
        public static ushort setif(ushort src, byte srcpos, ushort dst, byte dstpos)
        {
            if(bit.test(src, srcpos))
                return enable(dst, dstpos);
            return dst;
        }

        /// <summary>
        /// Enables a specified bit in the target if a specified bit is enabled in the source
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="srcpos">The source bit position</param>
        /// <param name="dst">The target value</param>
        /// <param name="dstpos">The target bit position</param>
        [MethodImpl(Inline), Op]
        public static uint setif(uint src, byte srcpos, uint dst, byte dstpos)
        {
            if(bit.test(src, srcpos))
                return enable(dst, dstpos);
            return dst;
        }

        /// <summary>
        /// Enables a specified bit in the target if a specified bit is enabled in the source
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="srcpos">The source bit position</param>
        /// <param name="dst">The target value</param>
        /// <param name="dstpos">The target bit position</param>
        [MethodImpl(Inline), Op]
        public static ulong setif(ulong src, byte srcpos, ulong dst, byte dstpos)
        {
            if(bit.test(src, srcpos))
                return enable(dst, dstpos);
            return dst;
        }
    }
}