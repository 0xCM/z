//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Arrays
    {
        /// <summary>
        /// Constructs an array filled with a replicated value
        /// </summary>
        /// <param name="value">The value to replicate</param>
        /// <param name="count">The number of replicants</param>
        /// <typeparam name="T">The replicant type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] replicate<T>(T value, int count)
        {
            var dst = new T[count];
            for(var idx = 0U; idx < count; idx ++)
                seek(dst,idx) = value;
            return dst;
        }
    }
}