//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether a type implements a specified interface
        /// </summary>
        /// <param name="src">The type to examine</param>
        /// <param name="tInterface">The interface type to test</param>
        [Op]
        public static bool Reifies(this Type src, Type tInterface)
            => tInterface.IsInterface && src.Interfaces().Contains(tInterface);

        /// <summary>
        /// Determines whether a type implements a parametrically-specific interface
        /// </summary>
        /// <typeparam name="T">The interface type</typeparam>
        /// <param name="src">The type to examine</param>
        public static bool Reifies<T>(this Type src)
            => src.Reifies(typeof(T));
    }
}