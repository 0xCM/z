//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static Option;

    partial class XTend
    {
        /// <summary>
        /// Lifts a nullable value type into the option monad
        /// </summary>
        /// <param name="src">The potential value</param>
        /// <typeparam name="T">The potential value type</typeparam>
        [MethodImpl(Inline)]
        public static Option<T> ToOption<T>(this T? src)
            where T : struct
                =>  src.HasValue ? src.Value : none<T>();

        /// <summary>
        /// Extracts a nulluable value from an option over a nullable value type
        /// </summary>
        /// <param name="src">The potential value</param>
        /// <typeparam name="T">The potential value type</typeparam>
        [MethodImpl(Inline)]
        public static T? ToNullable<T>(this Option<T> src)
            where T : struct
                => src.IsSome() ? new T?(src.ValueOrDefault()) : (T?)null;

        /// <summary>
        /// Lifts a type value to an option that is valued iff the source type is non-void
        /// </summary>
        /// <param name="src">The value to lift</param>
        [MethodImpl(Inline)]
        public static Option<Type> ToOption(this Type src)
            => src == typeof(void) ? none<Type>() : some(src);
    }
}