//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Pow2
    {
        /// <summary>
        /// Determines wither a specified value is a power of 2
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bool test(ulong src)
        {
            var x = src & (src-1);
            var a = x != 0 ? true : false;
            var b = src != 0 ? true : false;
            return b && !a;
        }
    }
}