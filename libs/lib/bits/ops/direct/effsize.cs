//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class bits
    {
        /// <summary>
        /// Computes the minimum number of bytes required to represent the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), EffSize]
        public static byte effsize(ulong src)
            => math.log2((byte)msb(src));
    }
}