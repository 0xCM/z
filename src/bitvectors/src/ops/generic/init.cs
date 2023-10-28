//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Initializes a 128-bit bitvector
        /// </summary>
        /// <param name="src">The value used to initialize the bitvector</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        static BitVector128<T> init<T>(Vector128<T> src)
            where T : unmanaged
                => new BitVector128<T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector128<T> init<T>(W128 w, T src = default)
            where T : unmanaged
                => init(vgcpu.vbroadcast(w,src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector256<T> init<T>(W256 w, T src)
            where T : unmanaged
                => vgcpu.vbroadcast(w,src);
    }
}