//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;

    partial struct gcpu
    {
        /// <summary>
        /// Computes x ^ ((x << offset) ^ (x >> offset));
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The shift offset</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Xors, Closures(Integers)]
        public static Vector128<T> vxors<T>(Vector128<T> x, [Imm] byte count)
            where T : unmanaged
                => vxor(x,vxor(gcpu.vsll(x, count),vsrl(x,count)));

        /// <summary>
        /// Computes x ^ ((x << offset) ^ (x >> offset));
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The shift offset</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Xors, Closures(Integers)]
        public static Vector256<T> vxors<T>(Vector256<T> x, [Imm] byte count)
            where T : unmanaged
                => vxor(x,vxor(gcpu.vsll(x, count),vsrl(x,count)));
    }
}
