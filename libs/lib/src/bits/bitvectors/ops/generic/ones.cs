
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Returns a generic vector with all bits enabled
        /// </summary>
        /// <typeparam name="T">The primal type upon which the vector is predicated</typeparam>
        [MethodImpl(Inline)]
        public static ScalarBits<T> ones<T>()
            where T : unmanaged
                => core.ones<T>();

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static BitVector128<T> ones<T>(W128 w)
            where T : unmanaged
                => gcpu.vones<T>(w);

        [MethodImpl(Inline), Nor, Closures(Closure)]
        public static BitVector256<T> ones<T>(W256 w)
            where T : unmanaged
                => gcpu.vones<T>(w);
    }
}