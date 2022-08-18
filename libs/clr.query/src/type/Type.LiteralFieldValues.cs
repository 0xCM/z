//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    using static Root;

    partial class ClrQuery
    {
        /// <summary>
        /// Fetches the values of literal fields declared by a specified type that are of specified parametric type
        /// </summary>
        /// <param name="src">The source type</param>
        /// <param name="fields">The fields for which values are specified</param>
        /// <typeparam name="T">The literal field type</typeparam>
        [Op, Closures(Closure)]
        public static ReadOnlySpan<T> LiteralFieldValues<T>(this Type src, out ReadOnlySpan<FieldInfo> fields)
        {
            fields = src.LiteralFields(typeof(T));
            var count = fields.Length;
            var dst = new T[fields.Length];
            for(var i=0; i<count; i++)
                dst[i] = (T)fields[i].GetRawConstantValue();
            return dst;
        }

        /// <summary>
        /// Fetches the values of literal fields declared by a specified type that are of specified parametric type
        /// </summary>
        /// <param name="src">The source type</param>
        /// <param name="fields">The fields for which values are specified</param>
        /// <typeparam name="T">The literal field type</typeparam>
        [Op, Closures(Closure)]
        public static T[] LiteralFieldValues<T>(this Type src)
        {
            var fields = src.LiteralFields(typeof(T));
            var count = fields.Length;
            var dst = new T[fields.Length];
            for(var i=0; i<count; i++)
                dst[i] = (T)fields[i].GetRawConstantValue();
            return dst;
        }
    }
}