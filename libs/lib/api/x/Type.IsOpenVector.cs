//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XApi
    {
        /// <summary>
        /// Returns true if a type is an open generic 512-bit intrinsic vector
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <param name="w">The vector width</param>
        [Op]
        public static bool IsOpenVector(this Type t, W128 w)
            => VK.open(t,w);

        /// <summary>
        /// Returns true if a type is an open generic 512-bit intrinsic vector
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <param name="w">The vector width</param>
        [Op]
        public static bool IsOpenVector(this Type t, W256 w)
            => VK.open(t,w);

        /// <summary>
        /// Returns true if a type is an open generic 512-bit intrinsic vector
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <param name="w">The vector width</param>
        [Op]
        public static bool IsOpenVector(this Type t, W512 w)
            => VK.open(t,w);
    }
}