//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class VK
    {
        /// <summary>
        /// Returns true if a type is an open generic 128-bit intrinsic vector
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <param name="w">The vector width</param>
        [MethodImpl(Inline), Op]
        public static bool open(Type t, W128 w)
            => t.IsOpenGeneric() && test(t,w);

        /// <summary>
        /// Returns true if a type is an open generic 256-bit intrinsic vector
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <param name="w">The vector width</param>
        [MethodImpl(Inline), Op]
        public static bool open(Type t, W256 w)
            => t.IsOpenGeneric() && test(t,w);

        /// <summary>
        /// Returns true if a type is an open generic 512-bit intrinsic vector
        /// </summary>
        /// <param name="t">The type to examine</param>
        /// <param name="w">The vector width</param>
        [MethodImpl(Inline), Op]
        public static bool open(Type t, W512 w)
            => t.IsOpenGeneric() && test(t,w);
    }
}