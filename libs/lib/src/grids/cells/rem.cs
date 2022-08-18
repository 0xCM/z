//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct CellCalcs
    {
        /// <summary>
        /// Computes, in terms of bytes,the modulus src % w
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The bit-width selector</param>
        [MethodImpl(Inline), Op]
        public static ByteSize rem(ByteSize src, W16 w)
            => src % 2;

        /// <summary>
        /// Computes, in terms of bytes,the modulus src % w
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The bit-width selector</param>
        [MethodImpl(Inline), Op]
        public static ByteSize rem(ByteSize src, W32 w)
            => src % 4;

        /// <summary>
        /// Computes, in terms of bytes,the modulus src % w
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The bit-width selector</param>
        [MethodImpl(Inline), Op]
        public static ByteSize rem(ByteSize src, W64 w)
            => src % 8;

        /// <summary>
        /// Computes, in terms of bytes,the modulus src % w
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The bit-width selector</param>
        [MethodImpl(Inline), Op]
        public static ByteSize rem(ByteSize src, W128 w)
            => src % 16;

        /// <summary>
        /// Computes, in terms of bytes,the modulus src % w
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The bit-width selector</param>
        [MethodImpl(Inline), Op]
        public static ByteSize rem(ByteSize src, W256 w)
            => src % 32;

        /// <summary>
        /// Computes, in terms of bytes,the modulus src % w
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="w">The bit-width selector</param>
        [MethodImpl(Inline), Op]
        public static ByteSize rem(ByteSize src, W512 w)
            => src % 64;
    }
}