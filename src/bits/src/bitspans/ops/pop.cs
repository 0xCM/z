//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        /// <summary>
        /// Computes the number of enabled source bits
        /// </summary>
        /// <param name="src">The bit source</param>
        [MethodImpl(Inline), Op]
        public static uint pop(in BitSpan src)
        {
            var enabled = 0u;
            var count = src.Length;
            for(var i=0; i< count; i++)
                enabled += (uint)src[i];
            return enabled;
        }
    }
}