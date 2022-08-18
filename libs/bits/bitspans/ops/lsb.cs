//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        /// <summary>
        /// Computes the index of the least enabled bit
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static int lsb(in BitSpan src)
        {
            var count = src.Length;
            for(var i = 0; i<count;  i++)
                if(src[i])
                    return i;
            return -1;
        }
    }
}