//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitBlocks
    {
        /// <summary>
        /// Creates a block over a single cell
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="n">The bitblock width representative</param>
        /// <typeparam name="N">The bitwidth type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static BitBlock<N,T> single<N,T>(T src, N n = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => new BitBlock<N,T>(src);

        /// <summary>
        /// Creates a bitblock over a single cell
        /// </summary>
        /// <param name="src">The source segment</param>
        [MethodImpl(Inline)]
        public static BitBlock<T> single<T>(T src, uint bitcount)
            where T : unmanaged
                => new BitBlock<T>(src, bitcount);
    }
}