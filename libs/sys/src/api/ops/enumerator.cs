//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Options), Op, Closures(Closure)]
        public static IEnumerator<T> enumerator<T>(IEnumerable<T> src)
            => src.GetEnumerator();

        [MethodImpl(Options), Op, Closures(Closure)]
        public static bool next<T>(IEnumerator<T> src)
            => src.MoveNext();

        [MethodImpl(Options), Op, Closures(Closure)]
        public static T current<T>(IEnumerator<T> src)
            => src.Current;
    }
}