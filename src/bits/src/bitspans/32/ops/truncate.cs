//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class BitSpans32
    {
        /// <summary>
        /// Clamps a specified <see cref='BitSpan32'/> to a <see cref='BitSpan32'/> of a specified maximum length, discarding any excess
        /// </summary>
        /// <param name="src">The source bitstring</param>
        /// <param name="maxbits">The maximum length of the target bitstring</param>
        [MethodImpl(Inline), Op]
        public static BitSpan32 truncate(in BitSpan32 src, int maxbits)
            => src.Length <= maxbits ? src : new BitSpan32(src.Data.Slice(0, maxbits));
    }
}