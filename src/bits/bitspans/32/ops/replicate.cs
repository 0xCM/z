//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class BitSpans32
    {
        /// <summary>
        /// Replicates the content of a source bitspan into a new bitspan
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="count">The number of source copies to produce</param>
        [Op]
        public static BitSpan32 replicate(in BitSpan32 src, int count = 1)
        {
            Span<Bit32> data = new Bit32[src.Length * count];
            for(var i=0; i<count; i++)
                src.Data.CopyTo(data, i*src.Length);
            return load(data);
        }

        /// <summary>
        /// Replicates the content of a source bitspan into a target bitspan, repeatedly
        /// or partially depending on the available space in the target
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="count">The number of source copies to produce</param>
        [Op]
        public static ref readonly BitSpan32 replicate(in BitSpan32 src, in BitSpan32 dst)
        {
            if(src.Length == dst.Length)
                src.Data.CopyTo(dst.Data);
            else if (src.Length < dst.Length)
            {
                var q = dst.Length / src.Length;
                var r = dst.Length % src.Length;
                for(var i=0; i<q; i++)
                    src.Data.CopyTo(dst.Data, i*src.Length);
                src.Data.Slice(0,r).CopyTo(dst.Data, q*src.Length);
            }
            else
            {
                dst.Data.Clear();
                src.Data.Slice(0,dst.Length).CopyTo(dst.Data);
            }
            return ref dst;
        }
    }
}