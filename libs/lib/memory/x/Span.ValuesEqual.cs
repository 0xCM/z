//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial class XTend
    {
        /// <summary>
        /// Evaluates whether two spans have identical content
        /// </summary>
        /// <param name="a">The left span</param>
        /// <param name="b">The right span</param>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline),  Op, Closures(Closure)]
        public static bool ValuesEqual<T>(this ReadOnlySpan<T> a, ReadOnlySpan<T> b)
            where T : unmanaged, IEquatable<T>
        {
            var count = a.Length;
            if(count != b.Length)
                return false;

            for(var i=0; i<count; i++)
                if(! skip(a,i).Equals(skip(b,i)))
                    return false;
            return true;
        }

        /// <summary>
        /// Evaluates whether two spans have identical content
        /// </summary>
        /// <param name="a">The left span</param>
        /// <param name="b">The right span</param>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline),  Op, Closures(Closure)]
        public static bool ValuesEqual<T>(this Span<T> a, ReadOnlySpan<T> b)
            where T : unmanaged, IEquatable<T>
                => a.ReadOnly().ValuesEqual(b);
    }
}