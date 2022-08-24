//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Immutable;


    partial class XTend
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ImmutableArray<T> EmptyIfDefault<T>(this ImmutableArray<T> array)
            => array.IsDefault ? ImmutableArray<T>.Empty : array;
    }
}