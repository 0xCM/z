//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct bit
    {
        /// <summary>
        /// Computes c := ~a = !a
        /// </summary>
        /// <param name="a">The source bit</param>
        [MethodImpl(Inline), Not]
        public static bit not(bit a)
            => new bit(!a.State);
    }
}