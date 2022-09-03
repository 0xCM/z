//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    partial class math
    {
        /// <summary>
        /// Returns true if the source value is greater than zero, false otherwise
        /// </summary>
        /// <param name="a">The value to inspect</param>
        [MethodImpl(Inline), Positive]
        public static bit positive(sbyte a)
            => a > 0;

        /// <summary>
        /// Returns true if the source value is greater than zero, false otherwise
        /// </summary>
        /// <param name="a">The value to inspect</param>
        [MethodImpl(Inline), Positive]
        public static bit positive(byte a)
            => a > 0;

        /// <summary>
        /// Returns true if the source value is greater than zero, false otherwise
        /// </summary>
        /// <param name="a">The value to inspect</param>
        [MethodImpl(Inline), Positive]
        public static bit positive(short a)
            => a > 0;

        /// <summary>
        /// Returns true if the source value is greater than zero, false otherwise
        /// </summary>
        /// <param name="a">The value to inspect</param>
        [MethodImpl(Inline), Positive]
        public static bit positive(ushort a)
            => a > 0;

        /// <summary>
        /// Returns true if the source value is greater than zero, false otherwise
        /// </summary>
        /// <param name="a">The value to inspect</param>
        [MethodImpl(Inline), Positive]
        public static bit positive(int a)
            => a > 0;

        /// <summary>
        /// Returns true if the source value is greater than zero, false otherwise
        /// </summary>
        /// <param name="a">The value to inspect</param>
        [MethodImpl(Inline), Positive]
        public static bit positive(uint a)
            => a > 0;

        /// <summary>
        /// Returns true if the source value is greater than zero, false otherwise
        /// </summary>
        /// <param name="a">The value to inspect</param>
        [MethodImpl(Inline), Positive]
        public static bit positive(long a)
            => a > 0;

        /// <summary>
        /// Returns true if the source value is greater than zero, false otherwise
        /// </summary>
        /// <param name="a">The value to inspect</param>
        [MethodImpl(Inline), Positive]
        public static bit positive(ulong a)
            => a > 0;
    }
}