//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class BitGrid
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit readbit<T>(in T src, int bitpos)
            where T : unmanaged
                => gbits.test(readcell(in src, bitpos), (byte)(bitpos % width<T>()));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit readbit<T>(in T src, uint bitpos)
            where T : unmanaged
                => gbits.test(readcell(in src, (int)bitpos), (byte)(bitpos % width<T>()));

        /// <summary>
        /// Reads a cell determined by a linear bit position
        /// </summary>
        /// <param name="bitpos">The linear bit position</param>
        /// <param name="src">A reference to grid storage</param>
        /// <typeparam name="T">The storage segment type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        static ref readonly T readcell<T>(in T src, int bitpos)
            where T : unmanaged
                => ref skip(in src, bitpos / width<T>());

        /// <summary>
        /// Reads a bit from a grid
        /// </summary>
        [MethodImpl(Inline)]
        public static bit readbit<N,T>(N width, in T src, int row, int col)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => readbit(in src, nat32i<N>()*row + col);

        /// <summary>
        /// Reads a bit from a grid
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bit readbit<T>(int width, in T src, int row, int col)
            where T : unmanaged
                => readbit(in src, width*row + col);
    }
}