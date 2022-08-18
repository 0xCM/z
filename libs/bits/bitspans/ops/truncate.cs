//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        /// <summary>
        /// Clamps a specified <see cref='BitSpan'/> to a <see cref='BitSpan'/> of a specified maximum length, discarding any excess
        /// </summary>
        /// <param name="src">The source bitstring</param>
        /// <param name="maxbits">The maximum length of the target bitstring</param>
        [MethodImpl(Inline), Op]
        public static BitSpan truncate(in BitSpan src, uint maxbits)
            => src.Length <= maxbits ? src : load(core.slice(src.Storage, 0, maxbits));
    }
}