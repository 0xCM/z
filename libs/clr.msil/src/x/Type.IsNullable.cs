//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether a type is nullable
        /// </summary>
        /// <param name="t">The type to examine</param>
        [MethodImpl(Inline), Op]
        public static bool IsNullableType(this Type t)
            =>  (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
              | (t.IsGenericRef() && t.GetElementType().GetGenericTypeDefinition() == typeof(Nullable<>));

        /// <summary>
        /// Determine whether a type is a nullable type with a given underlying type
        /// </summary>
        /// <typeparam name="T">The underlying type</typeparam>
        /// <param name="t">The type to check</param>
        /// <returns>
        /// Returns true if t is both a nullable type and is of type T
        /// </returns>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static bool IsNullable<T>(this Type t)
            => t.IsNullableType() && Nullable.GetUnderlyingType(t) == typeof(T);

        [MethodImpl(Inline), Op]
        public static bool IsNullable(this Type subject, Type match)
            => subject.IsNullableType() && Nullable.GetUnderlyingType(subject) == match;
    }
}