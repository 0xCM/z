//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class BitSpans32
    {
        /// <summary>
        /// Forms the bitspan z := [head,tail] via concatentation
        /// </summary>
        /// <param name="head">The leading bits</param>
        /// <param name="tail">The trailing bits</param>
        [Op]
        public static BitSpan32 concat(in BitSpan32 head, in BitSpan32 tail)
        {
            Span<Bit32> dst = new Bit32[head.Length + tail.Length];
            head.Data.CopyTo(dst);
            tail.Data.CopyTo(dst, head.Length);
            return BitSpans32.load(dst);
        }
    }
}