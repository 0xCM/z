//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct CellCalcs
    {
        /// <summary>
        /// Computes the minimum number of cells required to store a specified number of bits
        /// </summary>
        /// <param name="w">The cell width</param>
        /// <param name="n">The bit count/number of matrix columns</param>
        [MethodImpl(Inline), Op]
        public static int mincells(ulong w, ulong n)
        {
            // if a single cell covers a column then there's no need for computation
            if(w >= n)
                return 1;

            var q = n / w;
            var r = n % w;
            return (int)(r == 0 ? q : q + 1);
        }

        /// <summary>
        /// Computes the minimum number of cells required to store data of a given bit width
        /// </summary>
        /// <param name="bc">The number of bits for which storage is required</param>
        /// <typeparam name="T">The storage cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ulong mincells<T>(ulong bc)
            where T : unmanaged
        {
            if(width<T>() >= bc)
                return 1;

            var q = bc / (uint)width<T>();
            var r = bc % (uint)width<T>();
            return q + (r != 0u ? 1u : 0u);
        }

        /// <summary>
        /// Computes the minimum number of T-cells required to store N bits
        /// </summary>
        /// <param name="n">The bit count representative</param>
        /// <param name="t">A cell type representative</param>
        /// <typeparam name="N">The bit count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static int mincells<N,T>(N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => NatCalc.lteqT(n,t) ? 1 : (int)NatCalc.divceilT(n,t);

        /// <summary>
        /// Computes the minimum number of T-cells required to store M*N bits
        /// </summary>
        /// <param name="n">The bit count representative</param>
        /// <param name="t">A cell type representative</param>
        /// <typeparam name="N">The bit count type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static Count mincells<M,N,T>(M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var required = NatCalc.mul(m,n);
            var cellbits = core.width<T>();
            var whole = required/cellbits;
            if(required % cellbits == 0)
                return (uint)whole;
            else
                return (uint)whole + 1;
        }
    }
}