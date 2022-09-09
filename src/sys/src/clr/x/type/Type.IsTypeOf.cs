//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether a source type is predicated on a specified match type, including nullable wrappers, references and enums
        /// </summary>
        /// <typeparam name="T">The type to match</typeparam>
        /// <param name="candidate">The source type</param>
        /// <param name="match">The type to match</param>
        [Op]
        public static bool IsTypeOf(this Type candidate, Type match)
            => candidate.TEffective() == match
            || candidate.TEffective().IsNullable(match)
            || candidate.TEffective().IsEnum && candidate.TEffective().GetEnumUnderlyingType() == match;

        /// <summary>
        /// Determines whether a source type is predicated on a parametric type, including nullable wrappers, references and enums
        /// </summary>
        /// <param name="match">The source type</param>
        /// <typeparam name="T">The type to match</typeparam>

        [Op]
        public static bool IsTypeOf<T>(this Type match)
            => match.TEffective() == typeof(T)
            || match.TEffective().IsNullable<T>()
            || match.TEffective().IsEnum && match.TEffective().GetEnumUnderlyingType() == typeof(T);
    }
}