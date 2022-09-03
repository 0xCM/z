//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XApi
    {
        /// <summary>
        /// Classifies a 128-bit vector
        /// </summary>
        /// <param name="w">The vector width</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vec128Kind<T> VectorKind<T>(this W128 w)
            where T : unmanaged
                => default;

        /// <summary>
        /// Classifies a 256-bit vector
        /// </summary>
        /// <param name="w">The vector width</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vec256Kind<T> VectorKind<T>(this W256 w)
            where T : unmanaged
                => default;

        /// <summary>
        /// Classifies a 512-bit vector
        /// </summary>
        /// <param name="w">The vector width</param>
        /// <typeparam name="T">The vector cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Vec512Kind<T> VectorKind<T>(this W512 w)
            where T : unmanaged
                => default;
    }
}