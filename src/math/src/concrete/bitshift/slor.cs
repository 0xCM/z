//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class math
    {
        /// <summary>
        /// Computes x := (a << asl) | (b << bsl)
        /// </summary>
        /// <param name="a">The first shift target</param>
        /// <param name="asl">The amount by which the first target is shifted</param>
        /// <param name="b">The second shift target</param>
        /// <param name="bsl">The amount by which the second target is shifted</param>
        [MethodImpl(Inline), Op]
        public static byte slor(byte a, byte asl, byte b, byte bsl)
            => or(sll(a,asl), sll(b, bsl));
    }
}