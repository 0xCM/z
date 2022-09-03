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
        /// Returns the first element of the sequence that satisifies the predicate, if any.
        /// </summary>
        /// <param name="src">The sequence to search</param>
        /// <param name="predicate">The predicate to satiisfy</param>
        /// <typeparam name="T">The element type</typeparam>
        public static Option<T> TryFind<T>(this IEnumerable<T> src, Func<T,bool> predicate)
            => src.FirstOrDefault(predicate);

        /// <summary>
        /// Retrieves the key-identified value if possible
        /// </summary>
        /// <typeparam name="K">The key</typeparam>
        /// <typeparam name="V">The type of value identified by the key</typeparam>
        /// <param name="subject">The collection to query</param>
        /// <param name="key">The key that identifies the value</param>
        public static Option<V> TryFind<K,V>(this Dictionary<K,V> subject, K key)
            => guard(key,
                k => k != null,
                k => subject.TryGetValue(k, out V value)
                    ? some(value)
                    : none<V>());

        /// <summary>
        /// Retrieves the key-identified value if possible
        /// </summary>
        /// <typeparam name="K">The key</typeparam>
        /// <typeparam name="V">The type of value identified by the key</typeparam>
        /// <param name="subject">The collection to query</param>
        /// <param name="key">The key that identifies the value</param>
        public static Option<V> TryFind<K,V>(this IReadOnlyDictionary<K,V> subject, K key)
                => key == null ? none<V>()
                : (subject.TryGetValue(key, out V value)
                ? some(value) : none<V>());

        /// <summary>
        /// Removes an element from the queue if one exists
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        /// <param name="q">the queue</param>
        public static Option<T> TryDequeue<T>(this ConcurrentQueue<T> q)
            => q.TryDequeue(out T next) ? some(next) : none<T>();

        /// <summary>
        /// Removes the key-identified value if possible
        /// </summary>
        /// <typeparam name="K">The key</typeparam>
        /// <typeparam name="V">The type of value identified by the key</typeparam>
        /// <param name="subject">The collection to query</param>
        /// <param name="key">The key that identifies the value</param>
        public static Option<V> TryRemove<K, V>(this ConcurrentDictionary<K,V> subject, K key)
            => guard(key, k => k != null,
                k => subject.TryRemove(k, out V value)
                    ? some(value)
                    : none<V>());

        /// <summary>
        /// A functional rendition of <see cref="ConcurrentBag{T}.TryTake(out T)"/>
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="source">The collection to search</param>
        public static Option<T> TryTake<T>(this ConcurrentBag<T> source)
            => (source.TryTake(out T element)) ? some(element) : none<T>();

        /// <summary>
        /// Returns a value if the source stream yeilds exactly one value; otherwise, returns none
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The stream element type</typeparam>
        public static Option<T> TryGetSingle<T>(this IEnumerable<T> src)
            => src.Count() == 1 ? src.Single() : none<T>();

        /// <summary>
        /// Returns a value if the source stream yeilds exactly one value that satisfied a predicate; otherwise, returns none
        /// </summary>
        /// <param name="stream">The stream to search</param>
        /// <param name="predicate">The predicate to match</param>
        /// <typeparam name="T">The stream item type</typeparam>
        public static Option<T> TryGetSingle<T>(this IEnumerable<T> stream, Func<T,bool> predicate)
        {
            var satisfied = stream.Where(predicate).ToList();
            if (satisfied.Count != 1)
                return none<T>();
            else
                return satisfied[0];
        }

        /// <summary>
        /// Returns the value of the first element of an optional array, if extant; otherwise, raises an exception
        /// </summary>
        /// <param name="src">The optional array</param>
        /// <typeparam name="P">The array element type</typeparam>
        public static P First<P>(this Option<P[]> src)
            => src.Items().First();

        /// <summary>
        /// Returns the value of the first element of an optional array, if extant; otherwise, returns a parametric default
        /// </summary>
        /// <param name="src">The optional array</param>
        /// <typeparam name="P">The array element type</typeparam>
        public static P FirstOrDefault<P>(this Option<P[]> x)
            => x.Items().FirstOrDefault();

        /// <summary>
        /// Searches for the first element in the stream that satisfies a predicate and returns the element if found; otherwise, returns None
        /// </summary>
        /// <typeparam name="X">The stream item type</typeparam>
        /// <param name="src">The stream to search</param>
        /// <param name="predicate">The predicate to match</param>
        public static Option<X> TryGetFirst<X>(this IEnumerable<X> src, Func<X,bool> predicate)
            => src.FirstOrDefault(predicate);

        /// <summary>
        /// Returns the the first realized value as a valued option, if extant, from a stream of potential values;
        /// otherwise, returns a non-valued option
        /// </summary>
        /// <param name="src">The potentials</param>
        /// <typeparam name="T">The potential value type</typeparam>
        public static Option<T> TryGetFirst<T>(this IEnumerable<Option<T>> src)
        {
            var o = src.Where(x => x.IsSome()).ToList();
            return o.Any() ? o.First() : none<T>();
        }

        public static Option<T> TryGetFirst<T>(this T[] src)
            => src.Length != 0 ? src[0] : Option.none<T>();


        /// Extracts the encapsulated values from a sequence of optional values (where Some)
        /// </summary>
        /// <typeparam name="T">The value type</typeparam>
        /// <param name="options">The options to examine</param>
        public static IEnumerable<T> Values<T>(this IEnumerable<Option<T>> options)
            => options.WhereSome().Select(x => x.ValueOrDefault());

        public static T SingleOrDefault<T>(this Option<IEnumerable<T>> x)
            => x.MapValueOrDefault(seq => seq.SingleOrDefault());

        public static T First<T>(this Option<IEnumerable<T>> x)
            => x.MapRequired(y => y.First());

        public static T FirstOrDefault<T>(this Option<IEnumerable<T>> x)
            => x.MapValueOrDefault(seq => seq.FirstOrDefault());

        public static T Single<T>(this Option<T> x)
            where T : IEnumerable<T>
                => x.MapRequired(z => z.Single());
    }
}