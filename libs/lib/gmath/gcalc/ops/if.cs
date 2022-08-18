//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct gcalc
    {
        /// <summary>
        /// Branches an operator according to predicate evaluation outcome
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="test">The branch predicate</param>
        /// <param name="true">The operator to apply when the test is true</param>
        /// <param name="false">The operator to apply when the test is false</param>
        /// <typeparam name="S">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T @if<T>(in T src, ValuePredicate<T> test, ValueOperator<T> @true, ValueOperator<T> @false)
            where T : struct
                => test(src) ? @true(src) : @false(src);

        /// <summary>
        /// Branches an operator according to predicate evaluation outcome
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="test">The branch predicate</param>
        /// <param name="true">The operator to apply when the test is true</param>
        /// <param name="false">The operator to apply when the test is false</param>
        /// <typeparam name="S">The operand type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T @if<T>(in T src, ValuePredicate<T> test, ValueMap<T,T> @true, ValueMap<T,T> @false)
            where T : struct
                => @if<T,T>(src,test,@true,@false);

        /// <summary>
        /// Branches a projection as determined by a predicate
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="test">The branch predicate</param>
        /// <param name="true">The projection to apply when the test is true</param>
        /// <param name="false">The projection to apply when the test is false</param>
        /// <typeparam name="S">The source domain type</typeparam>
        /// <typeparam name="T">The target domain type</typeparam>
        [MethodImpl(Inline)]
        public static T @if<S,T>(in S src, ValuePredicate<S> test, ValueMap<S,T> @true, ValueMap<S,T> @false)
            where S : struct
            where T : struct
                => test(src) ? @true(src) : @false(src);
    }
}