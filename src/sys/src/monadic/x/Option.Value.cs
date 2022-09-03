//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    partial class XTend
    {
       /// <summary>
       /// Invokes an action if a nullable value type is valued
       /// </summary>
       /// <param name="src">The potential source value</param>
       /// <param name="f">The action to invoke over a realized value, if extant</param>
       /// <typeparam name="T">The potential value type</typeparam>
       [MethodImpl(Inline), Op, Closures(Closure)]
       public static void OnValue<T>(this T? src, Action<T> f)
            where T : struct
        {
            if(src.HasValue)
                f(src.Value);
        }

        /// <summary>
        /// Extracts the encapsluated value if present; otherwise reutrns the underlying value type default
        /// </summary>
        /// <param name="x">The optional value</param>
        /// <typeparam name="T">The value type</typeparam>
        [MethodImpl(Inline)]
        public static T ValueOrDefault<T>(this Option<T?> x, T? @default = null)
            where T : struct
                => x.ValueOrElse(() =>  @default ?? default(T)).Value;

        /// <summary>
        /// Transforms a nulluble value into an optional value
        /// </summary>
        /// <typeparam name="T">The underlying value type</typeparam>
        /// <param name="x">The potential value</param>
        [MethodImpl(Inline)]
        public static Option<T> ValueOrNone<T>(this T? x)
            where T : struct
                => x != null ? x.Value : Option<T>.None();
    }
}