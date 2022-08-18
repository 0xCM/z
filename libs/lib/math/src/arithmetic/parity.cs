//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Returns true if the test value is even by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit even(sbyte test)
            => (test & 1) == 0;

        /// <summary>
        /// Returns true if the test value is even by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit even(byte test)
            => (test & 1) == 0;

        /// <summary>
        /// Returns true if the test value is even by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit even(short test)
            => (test & 1) == 0;

        /// <summary>
        /// Returns true if the test value is even by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit even(int test)
            => (test & 1) == 0;

        /// <summary>
        /// Returns true if the test value is even by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit even(ushort test)
            => (test & 1) == 0;

        /// <summary>
        /// Returns true if the test value is even by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit even(uint test)
            => (test & 1) == 0;

        /// <summary>
        /// Returns true if the test value is even by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit even(long test)
            => (test & 1) == 0;

        /// <summary>
        /// Returns true if the test value is even by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit even(ulong test)
            => (test & 1) == 0;

        /// <summary>
        /// Returns true if the test value is odd by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit odd(sbyte test)
            => (test & 1) != 0;

        /// <summary>
        /// Returns true if the test value is odd by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit odd(byte test)
            => (test & 1) != 0;

        /// <summary>
        /// Returns true if the test value is odd by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit odd(short test)
            => (test & 1) != 0;

        /// <summary>
        /// Returns true if the test value is odd by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit odd(ushort test)
            => (test & 1) != 0;

        /// <summary>
        /// Returns true if the test value is odd by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit odd(int test)
            => (test & 1) != 0;

        /// <summary>
        /// Returns true if the test value is odd by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit odd(uint test)
            => (test & 1) != 0;

        /// <summary>
        /// Returns true if the test value is odd by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit odd(long test)
            => (test & 1) != 0;

        /// <summary>
        /// Returns true if the test value is odd by examining the least significant bit
        /// </summary>
        /// <param name="test">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit odd(ulong test)
            => (test & 1) != 0;
    }
}