//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Immutable;

    partial class XTend
    {
        public static ImmutableArray<T> AsImmutableOrNull<T>(this IEnumerable<T> items)
        {
            if (items == null)
                return default;

            return ImmutableArray.CreateRange<T>(items);
        }

        public static ImmutableArray<T> ToImmutableAndClear<T>(this ImmutableArray<T>.Builder builder)
        {
            if (builder.Capacity == builder.Count)
            {
                return builder.MoveToImmutable();
            }
            else
            {
                var result = builder.ToImmutable();
                builder.Clear();
                return result;
            }
        }
    }
}