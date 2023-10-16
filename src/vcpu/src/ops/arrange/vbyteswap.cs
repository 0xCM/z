//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CpuBytes;

    partial class vcpu
    {
        /// <summary>
        /// Retrieves the shuffle pattern that, when applied, swaps the byte-level representation
        /// of each  unsigned 16,32, or 64-bit integer component value
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="n">The integer width representative where n = 16 | 32 | 64</param>
        /// <typeparam name="N">The integer width type</typeparam>
        [MethodImpl(Inline)]
        public static Vector128<byte> vbyteswap<N>(N128 w, N n = default)
            where N : unmanaged, ITypeNat
        {
            if(typeof(N) == typeof(N16))
                return vload<byte>(w, ByteSwap128x16u);
            else if(typeof(N) == typeof(N32))
                return vload<byte>(w, ByteSwap128x32u);
            else if(typeof(N) == typeof(N64))
                return vload<byte>(w, ByteSwap128x64u);
            else
                throw no<N>();
        }

        /// <summary>
        /// Retrieves the shuffle pattern that, when applied, swaps the byte-level representation
        /// of each unsigned 16,32, or 64-bit integer component value
        /// </summary>
        /// <param name="w">The vector width selector</param>
        /// <param name="n">The integer width representative where n = 16 | 32 | 64</param>
        /// <typeparam name="N">The integer width type</typeparam>
        [MethodImpl(Inline)]
        public static Vector256<byte> vbyteswap<N>(N256 w, N n = default)
            where N : unmanaged, ITypeNat
        {
            if(typeof(N) == typeof(N16))
                return vload<byte>(w, ByteSwap256x16u);
            else if(typeof(N) == typeof(N32))
                return vload<byte>(w, ByteSwap256x32u);
            else if(typeof(N) == typeof(N64))
                return vload<byte>(w, ByteSwap256x64u);
            else
                throw no<N>();
        }

        /// <summary>
        /// Effects the reversal of the byte-level representation of each component in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vbyteswap(Vector128<ushort> x)
            => v16u(vshuffle(v8u(x), vbyteswap(w128,n16)));

        /// <summary>
        /// Effects the reversal of the byte-level representation of each component in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vbyteswap(Vector128<uint> x)
            => v32u(vshuffle(v8u(x), vbyteswap(w128,n32)));

        /// <summary>
        /// Effects the reversal of the byte-level representation of each component in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vbyteswap(Vector128<ulong> x)
            => v64u(vshuffle(v8u(x), vbyteswap(w128,n64)));

        /// <summary>
        /// Effects the reversal of the byte-level representation of each component in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vbyteswap(Vector256<ushort> x)
            => v16u(vshuffle(v8u(x), vbyteswap(w256,n16)));

        /// <summary>
        /// Effects the reversal of the byte-level representation of each component in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vbyteswap(Vector256<uint> x)
            => v32u(vshuffle(v8u(x), vbyteswap(w256,n32)));

        /// <summary>
        /// Effects the reversal of the byte-level representation of each component in the source vector
        /// </summary>
        /// <param name="x">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vbyteswap(Vector256<ulong> x)
            => v64u(vshuffle(v8u(x), vbyteswap(w256,n64)));
    }
}