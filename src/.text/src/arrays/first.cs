//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Arrays
    {
        /// <summary>
        /// Returns a reference to the location of the first element
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref T first<T>(T[] src)
            => ref seek<T>(src, 0);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool first<T>(T[] src, Func<T,bool> f, out T found)
        {
            var count = src.Length;
            var result = false;
            found = default;
            for(var i=0; i<count; i++)
            {
                ref readonly var candidate = ref skip(src,i);
                if(f(candidate))
                {
                    found = candidate;
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}