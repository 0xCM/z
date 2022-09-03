//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using NK = NumericKind;

    partial class VK
    {
        /// <summary>
        /// Determines the number of bits covered by a k-kinded vector
        /// </summary>
        /// <param name="k">The type kine</param>
        [MethodImpl(Inline), Op]
        public static int width(NativeVectorKind k)
            => (ushort)k;

        /// <summary>
        /// Determines the number of bytes covered by a k-kinded type
        /// </summary>
        /// <param name="k">The type kine</param>
        [MethodImpl(Inline), Op]
        public static int size(NativeVectorKind kind)
            => width(kind)/8;

        /// <summary>
        /// Determines the component width of a k-kinded vector
        /// </summary>
        /// <param name="k">The vector kind</param>
        [MethodImpl(Inline), Op]
        public static int segwidth(NativeVectorKind k)
            => (byte)((uint)k >> 16);

        /// <summary>
        /// Determines whether a classified vector is defined over primal unsigned integer components
        /// </summary>
        /// <param name="k">The vector classifier</param>
        [MethodImpl(Inline), Op]
        public static bool unsigned(NativeVectorKind k)
            => (k & (NativeVectorKind)NK.Unsigned) != 0;

        /// <summary>
        /// Determines whether a classified vector is defined over primal signed integer components
        /// </summary>
        /// <param name="k">The vector classifier</param>
        [MethodImpl(Inline), Op]
        public static bool signed(NativeVectorKind k)
            => (k & (NativeVectorKind)NK.Signed) != 0;

        /// <summary>
        /// Determines whether a classified vector is defined over floating-point components
        /// </summary>
        /// <param name="k">The vector classifier</param>
        [MethodImpl(Inline), Op]
        public static bool floating(NativeVectorKind k)
            => (k & (NativeVectorKind)NK.Float) != 0;

        /// <summary>
        /// Determines whether a classified vector is defined over primal integer components
        /// </summary>
        /// <param name="k">The vector classifier</param>
        [MethodImpl(Inline), Op]
        public static bool integral(NativeVectorKind k)
            => signed(k) || unsigned(k);
    }
}