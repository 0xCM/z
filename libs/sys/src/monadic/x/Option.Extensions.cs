//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using System.Linq;

    using static Option;

    partial class XTend
    {
        /// <summary>
        /// Applies a map to a valued option; otherwise, raises an exception
        /// </summary>
        /// <param name="x">The optional value</param>
        /// <param name="f">The mapping function</param>
        /// <typeparam name="X">The source type</typeparam>
        /// <typeparam name="Y">The target type</typeparam>
        public static Y MapRequired<X,Y>(this Option<X> x, Func<X,Y> f)
            => f(x.Require());

        [MethodImpl(Inline)]
        public static IEnumerable<Option<T>> Condense<T>(this IEnumerable<IEnumerable<Option<T>>> options)
            => options.SelectMany(x => x);

        /// <summary>
        /// Extracts the encapsluated value if present; otherwise returns the default value of the type
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="x">The optional value</param>
        [MethodImpl(Inline)]
        public static T Value<T>(this Option<T> x)
            where T : struct => x.ValueOrDefault();

        [MethodImpl(Inline)]
        public static IReadOnlyList<P> Items<P>(this Option<P[]> x)
            => x.ValueOrElse(() => new P[]{});

        [MethodImpl(Inline)]
        public static IEnumerable<T> Items<T>(this Option<IEnumerable<T>> x, Action error = null)
        {

            if (x)
                return x.ValueOrDefault();
            else
            {
                error?.Invoke();
                return new T[] { };
            }
        }

        /// <summary>
        /// <summary>
        /// Selects the subsequence for which values exist, if any
        /// </summary>
        /// <typeparam name="T">The potential value type</typeparam>
        /// <param name="options">The sequence of options to examine</param>
        [MethodImpl(Inline)]
        public static IEnumerable<Option<T>> WhereNone<T>(this IEnumerable<Option<T>> options)
            => from option in options where option.IsNone() select option;

        /// <summary>
        /// Selects the subsequence for which values exist, if any
        /// </summary>
        /// <typeparam name="T">The potential value type</typeparam>
        /// <param name="options">The sequence of options to examine</param>
        [MethodImpl(Inline)]
        public static IEnumerable<Option<T>> WhereSome<T>(this IEnumerable<Option<T>> options)
            => from option in options where option.IsSome() select option;

        /// <summary>
        /// Returns true if an optioal value exists an a specified predicate over the value is satisfied
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="x">The value to examine</param>
        /// <param name="predicate">The adjudicating predicate</param>
        [MethodImpl(Inline)]
        public static bool Satisfies<T>(this Option<T> x, Predicate<T> predicate)
            => x.TryMap(y => predicate(y)).ValueOrDefault();

        /// <summary>
        /// Bifurcates a stream of optional values into the haves/have nots
        /// </summary>
        /// <typeparam name="T">The optional value type</typeparam>
        /// <param name="options">The stream of options to evaluate</param>
        public static (IEnumerable<Option<T>> Left, IEnumerable<T> Right) Split<T>(this IEnumerable<Option<T>> options)
            => (options.WhereNone(), options.WhereSome().Select(x => x.ValueOrDefault()));

        /// <summary>
        /// Evaluates to true iff all options have values
        /// </summary>
        /// <param name="options">The options to evaluate</param>
        public static bool All(params IOption[] options)
            => options.All(o => o.IsSome);

        /// <summary>
        /// Invokes an action when all supplied options have value
        /// </summary>
        /// <typeparam name="X1">The type of the first potential item</typeparam>
        /// <typeparam name="X2">The type of the second potential item</typeparam>
        /// <param name="x1">The first potential value</param>
        /// <param name="x2">The second potential value</param>
        /// <param name="f">The action to conditionally invoke</param>
        [MethodImpl(Inline)]
        public static void WhenAll<X1,X2>(Option<X1> x1, Option<X2> x2, Action<X1, X2> f)
        {
            if(All(x1,x2))
                f(x1.Require(), x2.Require());
        }

        /// <summary>
        /// Invokes the supplied action if all values exist
        /// </summary>
        /// <typeparam name="X1">The type of the first potential value</typeparam>
        /// <typeparam name="X2">The type of the second potential value</typeparam>
        /// <typeparam name="X3">The type of the third potential value</typeparam>
        /// <param name="x1">The first potential value</param>
        /// <param name="x2">The second potential value</param>
        /// <param name="x3">The third potential value</param>
        /// <param name="f">The action to conditionally invoke</param>
        [MethodImpl(Inline)]
        public static void WhenAll<X1, X2, X3>(Option<X1> x1, Option<X2> x2, Option<X3> x3, Action<X1, X2, X3> f)
        {
            if(All(x1,x2,x3))
                f(x1.Require(), x2.Require(), x3.Require());
        }

        static Option<Y> guard<X,Y>(X x, Func<X, bool> predicate, Func<X, Option<Y>> f)
            => predicate(x) ? f(x) : none<Y>();
    }
}