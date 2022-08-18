//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether a type has a public default constructor
        /// </summary>
        /// <param name="t">The type to examine</param>
        [MethodImpl(Inline), Op]
        public static bool HasDefaultPublicConstructor(this Type t)
            => t.GetConstructor(new Type[] { }) != null;

        /// <summary>
        /// Determines whether a type has a public default constructor
        /// </summary>
        /// <typeparam name="T">The type to examine</typeparam>
        public static bool HasDefaultPublicConstructor<T>()
            where T : class
                => typeof(T).GetConstructor(new Type[] { }) != null;
    }
}