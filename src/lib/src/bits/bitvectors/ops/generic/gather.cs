//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class BitVectors
    {
        /// <summary>
        /// Populates a target vector with specified source bits
        /// </summary>
        /// <param name="spec">Identifies the source bits of interest</param>
        /// <param name="dst">Receives the identified bits</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ScalarBits<T> gather<T>(ScalarBits<T> src, ScalarBits<T> spec)
            where T : unmanaged
                => gbits.gather(src.State, spec.State);

        /// <summary>
        /// Populates a target vector with specified source bits
        /// </summary>
        /// <param name="spec">Identifies the source bits of interest</param>
        /// <param name="dst">Receives the identified bits</param>
        [MethodImpl(Inline)]
        public static ScalarBits<N,T> gather<N,T>(ScalarBits<N,T> src, ScalarBits<N,T> spec)
            where T : unmanaged
            where N : unmanaged, ITypeNat
                => gbits.gather(src.State, spec.State);
    }
}