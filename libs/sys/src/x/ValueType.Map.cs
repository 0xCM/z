//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Projects a source value, if non-null, onto a target value; otherwise, returns the target's default value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="f">The projector</param>
        /// <typeparam name="S">The source value type</typeparam>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline)]
        public static T Map<S,T>(this S? src, Func<S,T> f)
            where S : struct
            where T : struct
                => src.HasValue ? f(src.Value) : default;

        /// <summary>
        /// Projects a source value, if non-null, onto a target value; otherwise, returns value raised by a caller-supplied emitter
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="some">The projector</param>
        /// <param name="none">The alternative emitter</param>
        /// <typeparam name="S">The source value type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T Map<S,T>(this S? src, Func<S,T> some, Func<T> none)
            where S : struct
                => src.HasValue ? some(src.Value) : none();

        [MethodImpl(Inline)]
        public static S MapValueOrDefault<T,S>(this T? x, Func<T,S> f, S @default = default(S))
            where T : struct
                => x != null ? f(x.Value) : @default;

        [MethodImpl(Inline)]
        public static S MapValueOrElse<T,S>(this T? x, Func<T,S> f, Func<S> @else)
            where T : struct
                => x != null ? f(x.Value) : @else();
    }
}