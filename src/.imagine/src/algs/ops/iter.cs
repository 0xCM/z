//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iter<T>(ReadOnlySpan<T> src, Action<T> f)
        {
            for(var i=0u; i<src.Length; i++)
                f(sys.skip(src,i));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iter<T>(T[] src, Action<T> f)
            => iter(@readonly(src),  f);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iter<T>(Span<T> src, Action<T> f)
            => iter(src.ReadOnly(), f);

        [Op, Closures(Closure)]
        public static void iter<T>(ReadOnlySpan<T> src, Action<T> action, bool pll)
        {
            if(pll)
                src.ToArray().AsParallel().ForAll(item => action(item));
            else
                iter(src,action);
        }

        public static void iter<S,T>(ReadOnlySpan<S> src, Func<S,T> f, ConcurrentBag<T> dst, bool pll)
            => iter(src, item => dst.Add(f(item)), pll);

        public static void iter<S,T>(ReadOnlySpan<S> src, Func<S,T> f, List<T> dst, bool pll)
            => iter(src, item => dst.Add(f(item)), pll);
            
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void iter<T>(IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }

        [Op, Closures(Closure)]
        public static void iter<T>(IEnumerable<T> items, Action<T> action, bool pll)
        {
            if (pll)
                items.AsParallel().ForAll(item => action(item));
            else
                foreach (var item in items)
                    action(item);
        }
    }
}