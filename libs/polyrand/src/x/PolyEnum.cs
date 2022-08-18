//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    public static class PolyEnum
    {
        /// <summary>
        /// Produces a stream of values sampled from an enum
        /// </summary>
        /// <param name="src">The random source</param>
        /// <typeparam name="E">The enum type</typeparam>
        public static IEnumerable<E> EnumValues<E>(this IBoundSource src, Func<E,bool> filter)
            where E : unmanaged, Enum
        {
            var names = Enum.GetNames(typeof(E)).Mapi((index, name) => (index, name)).ToDictionary();
            var domain = Z0.Intervals.closed(0, names.Count);
            var stream = src.Stream(domain);

            while(true)
            {
                var name = names[stream.First()];
                var value = Enum.Parse<E>(name);
                if(filter != null)
                {
                    if(filter(value))
                        yield return value;
                }
                else
                    yield return value;
            }
        }

        /// <summary>
        /// Produces a stream of enum values enum
        /// </summary>
        /// <param name="src">The random source</param>
        /// <param name="exclusions">Enum literals to exclude</param>
        /// <typeparam name="E">The enum type</typeparam>
        public static IEnumerable<E> EnumValues<E>(this IBoundSource src, params E[] exclusions)
            where E : unmanaged, Enum
        {
            var excluded = exclusions.Select(x => x.ToString()).ToHashSet();
            var available = Enum.GetNames(typeof(E)).Where(n => !excluded.Contains(n)).ToArray();
            var names = available.Mapi((index, name) => (index, name)).ToDictionary();
            var stream = src.Stream(Z0.Intervals.closed(0, names.Count));
            var query = from item in stream select Enums.parse<E>(names[item]).Value;
            return query;
        }
    }
}