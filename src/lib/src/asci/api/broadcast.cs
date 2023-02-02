//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;

    partial struct Asci
    {
        /// <summary>
        /// Populates the 16 components of an 128x8u vector with a specified character code
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector128<byte> broadcast(W128 w, char src)
            => vcpu.vbroadcast(w,(byte)src);

        /// <summary>
        /// Populates the 32 components of an 256x8u vector with a specified character code
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector256<byte> broadcast(W256 w, char src)
            => vcpu.vbroadcast(w,(byte)src);

        /// <summary>
        /// Populates the 16 components of an 128x8u vector with a specified character code
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector128<byte> broadcast(W128 w, C src)
            => vcpu.vbroadcast(w,(byte)src);

        /// <summary>
        /// Populates the 32 components of an 256x8u vector with a specified character code
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector256<byte> broadcast(W256 w, C src)
            => vcpu.vbroadcast(w,(byte)src);

        /// <summary>
        /// Populates the 8 components of a 128x16u vector with a specified character symbol
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector128<ushort> broadcast(W128 w, AsciCharSym src)
            => vcpu.vbroadcast(w,(ushort)src);

        /// <summary>
        /// Populates the 16 components of a 256x16u vector with a specified character symbol
        /// </summary>
        /// <param name="w">The vector target width</param>
        /// <param name="src">The code to broadcast</param>
        [MethodImpl(Inline), Op]
        public Vector256<ushort> broadcast(W256 w, AsciCharSym src)
            => vcpu.vbroadcast(w,(ushort)src);
    }
}