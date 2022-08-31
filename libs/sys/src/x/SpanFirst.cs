//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Outcome<T> First<T>(this ReadOnlySpan<T> src, Func<T,bool> predicate)
        {
            var count = src.Length;
            if(count == 0)
                return null;

            ref readonly var start = ref first(src);
            for(var i=0u; i<count; i++)
            {
                ref readonly var candidate = ref skip(start,i);
                if(predicate(candidate))
                    return candidate;
            }
            return false;
        }

        /// <summary>
        /// Returns a reference to the first element of a nonempty span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T First<T>(this Span<T> src)
            => ref first(src);

        /// <summary>
        /// Returns a reference to the last element of a nonempty span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T Last<T>(this Span<T> src)
        {
            return ref seek(src, (uint)(src.Length - 1));
        }
    }
}