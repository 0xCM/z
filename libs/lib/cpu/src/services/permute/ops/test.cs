//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Perm
    {
        /// <summary>
        /// Determines whether a permutation literal is a symbol
        /// </summary>
        /// <param name="src">The value to inspect</param>
        [MethodImpl(Inline), Op]
        public static bool test(Perm4L src)
            => (byte)src <= 3;

        /// <summary>
        /// Determines whether a permutation literal is a symbol
        /// </summary>
        /// <param name="src">The value to inspect</param>
        [MethodImpl(Inline), Op]
        public static bool test(Perm8L src)
            => (uint)src <= 7;

        /// <summary>
        /// Determines whether a permutation literal is a symbol
        /// </summary>
        /// <param name="src">The value to inspect</param>
        [MethodImpl(Inline), Op]
        public static bool test(Perm16L src)
            => (ulong)src <= 15;
    }
}