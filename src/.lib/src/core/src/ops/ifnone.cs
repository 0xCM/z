//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Transforms an input, branching on nullity evaluation
        /// </summary>
        /// <param name="x">The input</param>
        /// <param name="null">The emitter to invoke if the input is null</param>
        /// <param name="else">The function to invoke if the input is not null</param>
        /// <typeparam name="X">The input type</typeparam>
        /// <typeparam name="Y">The output type</typeparam>
        [MethodImpl(Inline)]
        public static Y ifnone<X,Y>(X x, Func<Y> @null, Func<X,Y> @else)
            where X : class
                => x == null ? @null() : @else(x);

        /// <summary>
        /// Transforms an input value, branching on nullity evaluation
        /// </summary>
        /// <param name="x">The input</param>
        /// <param name="null">The emitter to invoke if the input is null</param>
        /// <param name="else">The optional function to invoke if the input is not null; if no
        /// function is provided, the default target type value will be returned</param>
        /// <typeparam name="X">The input type</typeparam>
        /// <typeparam name="Y">The output type</typeparam>
        [MethodImpl(Inline)]
        public static Y ifnone<X,Y>(X? x, Func<Y> @null, Func<X,Y> @else = null)
            where X : struct
            where Y : struct
                => !x.HasValue ? @null() : @else?.Invoke(x.Value) ?? default(Y);
    }
}