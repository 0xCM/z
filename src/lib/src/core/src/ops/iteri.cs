//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial struct core
    {
        /// <summary>
        /// Applies an action to the increasing sequence of integers 0,1,2,...,count - 1
        /// </summary>
        /// <param name="count">The number of times the action will be invoked
        /// <param name="f">The action to be applied to each value</param>
        [Op]
        public static void iteri(int count, Action<int> f, bool pll = false)
        {
            if(pll)
                gcalc.stream(0,count-1).AsParallel().ForAll(i => f(i));
            else
                for(var i = 0; i<count; i++)
                    f(i);
        }

        /// <summary>
        /// Appplies an action for each element in the source
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="f">The receiver</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iteri<T>(T[] src, Action<int,T> f, bool pll = false)
            => iteri(src.Length, i =>  f(i,skip(src,i)), pll);

        /// <summary>
        /// Appplies an action for each element in the source
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="f">The receiver</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iteri<T>(Index<T> src, Action<int,T> f, bool pll = false)
            => iteri(src.Length, i =>  f(i,src[i]), pll);

        /// <summary>
        /// Appplies an action for each element in a source span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="f">The receiver</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iteri<T>(ReadOnlySpan<T> src, Action<int,T> f)
        {
            for(var i=0; i<src.Length; i++)
                f(i, skip(src,i));
        }

        /// <summary>
        /// Appplies an action for each element in a source span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="f">The receiver</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iteri<T>(Span<T> src, Action<int,T> f)
        {
            ref readonly var input = ref first(src);
            for(var i=0; i<src.Length; i++)
                f(i, skip(input,i));
        }
        /// <summary>
        /// Applies an action to the increasing sequence of integers 0,1,2,...,count - 1
        /// </summary>
        /// <param name="count">The number of times the action will be invoked
        /// <param name="f">The action to be applied to each value</param>
        [Op]
        public static void iteri(uint count, Action<uint> f, bool pll = false)
        {
            if(pll)
                gcalc.stream(z32,count-1).AsParallel().ForAll(i => f(i));
            else
                for(var i = z32; i<count; i++)
                    f(i);
        }
    }
}