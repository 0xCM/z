// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial struct core
    {
        [Op, Closures(Closure)]
        public static void iter<T>(Seq<T> src, Action<T> action, bool pll = false)
            => iter(src.View, action, pll);

        [Op, Closures(Closure)]
        public static void iter<T>(ReadOnlySeq<T> src, Action<T> action, bool pll = false)
            => iter(src.View, action, pll);

        [Op, Closures(Closure)]
        public static void iter<T>(SortedSpan<T> src, Action<T> action)
            => iter(src.View, action);

        [Op, Closures(Closure)]
        public static void iter<T>(Index<T> src, Action<T> action, bool pll = false)
            => iter(src.View, action, pll);

        public static void iter<S,T>(ReadOnlySpan<S> src, Func<S,T> f, ConcurrentBag<T> dst, bool pll = true)
            => iter(src, item => dst.Add(f(item)), pll);

        [Op, Closures(Closure)]
        public static void iter<T>(Span<T> src, Action<T> action, bool pll = false)
            => iter(src.ReadOnly(), action, pll);

        [Op, Closures(Closure)]
        public static void iter<T>(T[] src, Action<T> action, bool pll = false)
            => iter(@readonly(src), action, pll);

        [Op, Closures(Closure)]
        public static void iter<S,T>(ReadOnlySpan<S> src, Func<S,T> f, List<T> dst, bool pll = false)
            => iter(src, item => dst.Add(f(item)), pll);

        [Op, Closures(Closure)]
        public static void iter<T>(ReadOnlySpan<T> src, Action<T> action, bool pll = false)
        {
            if(pll)
                src.ToArray().AsParallel().ForAll(action);
            else
            {
                for(var i=0u; i<src.Length; i++)
                    action(skip(src,i));
            }
        }

        [Op, Closures(Closure)]
        public static void iter<T>(IEnumerable<T> items, Action<T> action, bool pll = false)
        {
            if (pll)
                items.AsParallel().ForAll(item => action(item));
            else
                foreach (var item in items)
                    action(item);
        }
    }
}