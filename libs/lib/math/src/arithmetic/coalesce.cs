//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Returns the first nonzero argument, if any
        /// </summary>
        /// <param name="a0">The first test value</param>
        /// <param name="a1">The second test value</param>
        [MethodImpl(Inline), Op]
        public static uint coalesce(uint a0, uint a1)
            => a0 != 0 ? a0 : a1;

        /// <summary>
        /// Returns the first nonzero argument, if any
        /// </summary>
        /// <param name="a0">The first test value</param>
        /// <param name="a1">The second test value</param>
        /// <param name="a2">The third test value</param>
        [MethodImpl(Inline), Op]
        public static uint coalesce(uint a0, uint a1, uint a2)
            => a0 != 0 ? a0 : coalesce(a1, a2);

        /// <summary>
        /// Returns the first nonzero argument, if any
        /// </summary>
        /// <param name="a0">The first test value</param>
        /// <param name="a1">The second test value</param>
        /// <param name="a2">The third test value</param>
        /// <param name="a3">The fourth test value</param>
        [MethodImpl(Inline), Op]
        public static uint coalesce(uint a0, uint a1, uint a2, uint a3)
            => a0 != 0 ? a0 : coalesce(a1, a2, a3);

        /// <summary>
        /// Returns the first nonzero argument, if any
        /// </summary>
        /// <param name="a0">The first test value</param>
        /// <param name="a1">The second test value</param>
        /// <param name="a2">The third test value</param>
        /// <param name="a3">The fourth test value</param>
        /// <param name="a4">The fifth test value</param>
        [MethodImpl(Inline), Op]
        public static uint coalesce(uint a0, uint a1, uint a2, uint a3, uint a4)
            => a0 != 0 ? a0 : coalesce(a1, a2, a3, a4);

        /// <summary>
        /// Returns the first nonzero argument, if any
        /// </summary>
        /// <param name="a0">The first test value</param>
        /// <param name="a1">The second test value</param>
        /// <param name="a2">The third test value</param>
        /// <param name="a3">The fourth test value</param>
        /// <param name="a4">The fifth test value</param>
        /// <param name="a5">The sixth test value</param>
        [MethodImpl(Inline), Op]
        public static uint coalesce(uint a0, uint a1, uint a2, uint a3, uint a4, uint a5)
            => a0 != 0 ? a0 : coalesce(a1, a2, a3, a4, a5);
    }
}