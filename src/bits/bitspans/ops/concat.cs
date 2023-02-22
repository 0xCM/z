//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitSpans
    {
        /// <summary>
        /// Forms the bitspan z := [head,tail] via concatentation
        /// </summary>
        /// <param name="head">The leading bits</param>
        /// <param name="tail">The trailing bits</param>
        [Op]
        public static BitSpan concat(BitSpan head, BitSpan tail)
        {
            Span<bit> dst = sys.alloc<bit>(head.Length + tail.Length);
            head.Storage.CopyTo(dst);
            tail.Storage.CopyTo(dst, head.Length);
            return load(dst);
        }
    }
}