//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class sys
    {
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] array<T>(params T[] src)
            => src;

        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] array<T>(Span<T> src)
            => src.ToArray();

        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] array<T>(List<T> src)
            => src.ToArray();

        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] array<T>(IEnumerable<T> src)
            => src.ToArray();
    }
}