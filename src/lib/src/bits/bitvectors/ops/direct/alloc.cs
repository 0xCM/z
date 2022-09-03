//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitVectors
    {
        /// <summary>
        /// Allocates a 4-bit primal bitvector
        /// </summary>
        /// <param name="n">The width discriminator</param>
        [MethodImpl(Inline), Alloc]
        public static BitVector4 alloc(N4 n)
            => default;

        /// <summary>
        /// Allocates an 8-bit primal bitvector
        /// </summary>
        /// <param name="n">The width discriminator</param>
        [MethodImpl(Inline), Alloc]
        public static BitVector8 alloc(N8 n)
            => default;

        /// <summary>
        /// Allocates a primal 16-bit bitvector
        /// </summary>
        /// <param name="n">The width discriminator</param>
        [MethodImpl(Inline), Alloc]
        public static BitVector16 alloc(N16 n)
            => default;

        /// <summary>
        /// Allocates a primal 32-bit bitvector
        /// </summary>
        /// <param name="n">The width discriminator</param>
        [MethodImpl(Inline), Alloc]
        public static BitVector32 alloc(N32 n)
            => default;

        /// <summary>
        /// Allocates a primal 64-bit bitvector
        /// </summary>
        /// <param name="n">The width discriminator</param>
        [MethodImpl(Inline), Alloc]
        public static BitVector64 alloc(N64 n)
            => default;
    }
}