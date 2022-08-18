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
        /// Determines whether a type is a 128-bit intrinsic vector closed over a specified type
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Op]
        public static bool IsVector(this Type t, W128 w, Type tCell)
            => VK.test(t,w,tCell);

        /// <summary>
        /// Determines whether a type is a 256-bit intrinsic vector closed over a specified type
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Op]
        public static bool IsVector(this Type t, W256 w, Type tCell)
            => VK.test(t,w,tCell);

        /// <summary>
        /// Determines whether a type is a 512-bit intrinsic vector closed over a specified type
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Op]
        public static bool IsVector(this Type t, W512 w, Type tCell)
            => VK.test(t,w,tCell);

        /// <summary>
        /// Determines whether a type is a 128-bit intrinsic vector
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Op]
        public static bool IsVector(this Type t, W128 w)
            => VK.test(t,w);

        /// <summary>
        /// Determines whether a type is a 256-bit intrinsic vector
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Op]
        public static bool IsVector(this Type t, W256 w)
            => VK.test(t,w);

        /// <summary>
        /// Determines whether a type is a 512-bit intrinsic vector
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Op]
        public static bool IsVector(this Type t, W512 w)
            => VK.test(t,w);
    }
}